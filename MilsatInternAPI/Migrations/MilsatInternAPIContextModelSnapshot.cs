﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MilsatInternAPI.Data;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    [DbContext(typeof(MilsatInternAPIContext))]
    partial class MilsatInternAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MilsatInternAPI.Models.Intern", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseOfStudy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MentorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("MentorId");

                    b.ToTable("Intern");
                });

            modelBuilder.Entity("MilsatInternAPI.Models.Mentor", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Mentor");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("890a8ccb-5d03-4f3f-8cc6-f2cc1a2464e7"),
                            CreatedOn = new DateTime(2022, 10, 10, 8, 21, 33, 686, DateTimeKind.Utc).AddTicks(694),
                            Status = 0
                        },
                        new
                        {
                            UserId = new Guid("bb288c10-9fe3-4145-be70-5087422d34a7"),
                            CreatedOn = new DateTime(2022, 10, 10, 8, 21, 33, 686, DateTimeKind.Utc).AddTicks(697),
                            Status = 0
                        });
                });

            modelBuilder.Entity("MilsatInternAPI.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("PasswordTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("890a8ccb-5d03-4f3f-8cc6-f2cc1a2464e7"),
                            Bio = "",
                            Department = 0,
                            Email = "mentor1@gmail.com",
                            FullName = "Sodiq Agboola",
                            Gender = 0,
                            PasswordHash = new byte[] { 36, 135, 96, 87, 74, 255, 201, 187, 133, 57, 234, 101, 18, 157, 218, 63, 226, 17, 104, 96, 58, 83, 130, 185, 168, 151, 192, 230, 100, 186, 232, 138, 53, 91, 77, 138, 143, 250, 9, 3, 78, 153, 143, 205, 195, 24, 8, 95, 77, 149, 204, 125, 47, 1, 177, 207, 243, 106, 12, 51, 58, 147, 37, 228 },
                            PasswordSalt = new byte[] { 122, 146, 185, 27, 84, 146, 99, 87, 81, 160, 70, 35, 102, 64, 216, 62, 135, 202, 50, 5, 51, 58, 212, 141, 74, 135, 228, 236, 108, 247, 93, 9, 8, 190, 227, 15, 25, 151, 9, 192, 44, 172, 56, 148, 222, 2, 19, 158, 210, 234, 242, 32, 135, 215, 247, 74, 247, 91, 30, 83, 8, 226, 95, 194, 193, 71, 86, 45, 249, 49, 113, 162, 204, 59, 213, 245, 88, 80, 162, 247, 101, 61, 244, 76, 192, 72, 119, 18, 136, 43, 2, 217, 37, 36, 130, 161, 136, 15, 10, 112, 135, 131, 196, 34, 65, 11, 198, 212, 115, 116, 183, 222, 43, 56, 96, 170, 0, 65, 56, 241, 191, 53, 220, 204, 144, 71, 121, 61 },
                            PasswordTokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PhoneNumber = "passwords",
                            ProfilePicture = "",
                            Role = 1,
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isDeleted = false
                        },
                        new
                        {
                            UserId = new Guid("bb288c10-9fe3-4145-be70-5087422d34a7"),
                            Bio = "",
                            Department = 0,
                            Email = "mentor2@gmail.com",
                            FullName = "Sodiq Agboola",
                            Gender = 0,
                            PasswordHash = new byte[] { 162, 80, 156, 88, 112, 236, 8, 148, 95, 109, 191, 187, 105, 125, 6, 123, 138, 80, 16, 17, 0, 111, 217, 223, 201, 176, 214, 40, 181, 31, 52, 249, 32, 103, 117, 40, 83, 93, 104, 255, 168, 9, 140, 159, 177, 85, 151, 12, 148, 133, 119, 94, 254, 73, 25, 209, 217, 32, 139, 254, 204, 40, 188, 210 },
                            PasswordSalt = new byte[] { 156, 237, 200, 126, 12, 89, 20, 81, 239, 90, 40, 111, 202, 122, 158, 253, 209, 211, 127, 135, 63, 85, 127, 73, 74, 128, 241, 111, 183, 43, 102, 34, 6, 136, 182, 140, 53, 190, 210, 227, 128, 17, 30, 95, 30, 148, 100, 1, 186, 32, 186, 164, 55, 102, 91, 127, 207, 86, 102, 92, 182, 212, 109, 86, 105, 146, 37, 245, 132, 121, 93, 179, 104, 215, 51, 85, 106, 178, 86, 222, 230, 167, 127, 119, 57, 217, 149, 82, 24, 56, 137, 142, 241, 252, 159, 73, 191, 102, 199, 96, 30, 48, 93, 152, 45, 141, 48, 138, 66, 103, 173, 39, 142, 68, 224, 141, 250, 27, 195, 127, 99, 121, 47, 13, 188, 150, 151, 62 },
                            PasswordTokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PhoneNumber = "passwords",
                            ProfilePicture = "",
                            Role = 1,
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isDeleted = false
                        },
                        new
                        {
                            UserId = new Guid("b8f3b2bf-b648-435f-8255-49d591e51012"),
                            Bio = "",
                            Department = 5,
                            Email = "admin@milsat.com",
                            FullName = "Admin",
                            Gender = 0,
                            PasswordHash = new byte[] { 24, 212, 204, 36, 80, 165, 62, 248, 41, 214, 200, 71, 123, 194, 253, 125, 206, 178, 119, 21, 158, 24, 231, 29, 188, 155, 143, 62, 200, 54, 199, 23, 151, 54, 149, 91, 83, 232, 131, 109, 194, 212, 8, 69, 200, 13, 76, 155, 203, 21, 62, 209, 108, 195, 76, 127, 151, 140, 25, 1, 81, 169, 73, 12 },
                            PasswordSalt = new byte[] { 44, 224, 119, 133, 36, 123, 75, 249, 219, 71, 61, 199, 115, 176, 194, 53, 144, 106, 82, 180, 251, 200, 1, 35, 164, 173, 41, 235, 137, 71, 102, 14, 53, 83, 70, 137, 113, 216, 98, 124, 208, 57, 15, 39, 245, 203, 66, 153, 20, 170, 119, 194, 245, 143, 21, 84, 174, 226, 116, 227, 119, 191, 66, 192, 76, 152, 200, 218, 8, 78, 210, 119, 54, 59, 226, 104, 174, 61, 80, 129, 83, 76, 249, 47, 252, 23, 22, 86, 149, 122, 188, 32, 220, 211, 13, 46, 200, 107, 152, 170, 54, 48, 99, 146, 24, 32, 164, 181, 14, 134, 83, 183, 12, 27, 45, 160, 123, 121, 24, 211, 65, 206, 6, 108, 198, 210, 215, 4 },
                            PasswordTokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PhoneNumber = "datasolutions",
                            ProfilePicture = "",
                            Role = 0,
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("MilsatInternAPI.Models.Intern", b =>
                {
                    b.HasOne("MilsatInternAPI.Models.Mentor", "Mentor")
                        .WithMany("Interns")
                        .HasForeignKey("MentorId");

                    b.HasOne("MilsatInternAPI.Models.User", "User")
                        .WithOne("Intern")
                        .HasForeignKey("MilsatInternAPI.Models.Intern", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mentor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MilsatInternAPI.Models.Mentor", b =>
                {
                    b.HasOne("MilsatInternAPI.Models.User", "User")
                        .WithOne("Mentor")
                        .HasForeignKey("MilsatInternAPI.Models.Mentor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MilsatInternAPI.Models.Mentor", b =>
                {
                    b.Navigation("Interns");
                });

            modelBuilder.Entity("MilsatInternAPI.Models.User", b =>
                {
                    b.Navigation("Intern")
                        .IsRequired();

                    b.Navigation("Mentor")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
