﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MilsatInternAPI.Data;
using MilsatInternAPI.Interfaces;
using MilsatInternAPI.Models;
using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Interns;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MilsatInternAPI.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly IConfiguration _configuration;
        private readonly IAsyncRepository<User> _User;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public AuthenticationService(
            IConfiguration configuration, IAsyncRepository<User> user,
            ILogger<AuthenticationService> logger, IHttpContextAccessor httpContext)
        {
            _configuration = configuration;
            _logger = logger;
            _User = user;
            _httpContext = httpContext;
        }
        public async Task<AuthResponseDTO> Login(UserDTO request)
        {
            var user = await _User.GetAll().Where(x => x.Email == request.Email).FirstOrDefaultAsync();
            if (user == null)
            {
                return new AuthResponseDTO()
                {
                    Message = "Either the email or password is incorrect"
                };
            }
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new AuthResponseDTO()
                {
                    Message = "Either the email or password is incorrect"
                };
            }
            string token = CreateToken(user);
            var refreshToken = CreateRefreshToken();
            await SetRefreshToken(refreshToken, user);

            return new AuthResponseDTO {
                Success = true,
                Token = token,
                RefreshToken = refreshToken.Token,
                TokenExpires = refreshToken.Expires
            };
        }

        public async Task<AuthResponseDTO> RefreshToken()
        {
            var refreshToken = _httpContext?.HttpContext?.Request.Cookies["refreshToken"];
            var user = await _User.GetAll().Where(u => u.RefreshToken == refreshToken).FirstOrDefaultAsync();
            if(user == null)
            {
                return new AuthResponseDTO { Message = "Invalid Refresh Token" };
            }
            else if(user.TokenExpires < DateTime.UtcNow)
            {
                return new AuthResponseDTO { Message = "Token Expired." };
            }

            string token = CreateToken(user);
            var newRefreshToken = CreateRefreshToken();
            await SetRefreshToken(newRefreshToken, user);
            return new AuthResponseDTO
            {
                Success = true,
                Token = token,
                RefreshToken = newRefreshToken.Token,
                TokenExpires = newRefreshToken.Expires
            };
        }

        public User RegisterPassword(User user, string defaultPassword)
        {
            CreatePasswordHash(defaultPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return user;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private RefreshToken CreateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now,
            };
            return refreshToken;
        }

        private async Task SetRefreshToken(RefreshToken refreshToken, User user)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires
            };

            _httpContext?.HttpContext?.Response
                .Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

            user.RefreshToken = refreshToken.Token;
            user.TokenCreated = refreshToken.Created;
            user.TokenExpires = refreshToken.Expires;

            await _User.UpdateAsync(user);
        }
    }
}