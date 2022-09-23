﻿using MilsatInternAPI.Enums;
using MilsatInternAPI.Models;

namespace MilsatInternAPI.ViewModels.Mentors
{
    public class MentorResponseDTO
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public GenderType Gender { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public DepartmentType Department { get; set; }
        //public MentorStatus Status { get; set; }

        public List<Guid>? InternUserIDs { get; set; }
    }
}

