﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MilsatInternAPI.Data;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    [DbContext(typeof(MilsatInternAPIContext))]
    [Migration("20220921223312_fresh")]
    partial class fresh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MilsatInternAPI.Models.Intern", b =>
                {
                    b.Property<Guid>("InternId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CourseOfStudy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("MentorId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("InternId");

                    b.HasIndex("MentorId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Intern");
                });

            modelBuilder.Entity("MilsatInternAPI.Models.Mentor", b =>
                {
                    b.Property<Guid>("MentorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("MentorId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Mentor");

                    b.HasData(
                        new
                        {
                            MentorId = new Guid("f2146949-f4fc-4bef-9f3f-5ae25bdb10ef"),
                            CreatedOn = new DateTime(2022, 9, 21, 22, 33, 12, 356, DateTimeKind.Utc).AddTicks(2549),
                            Status = 0,
                            UserId = new Guid("5f93be38-ecd8-4db8-8d58-12f1fc2a6460")
                        },
                        new
                        {
                            MentorId = new Guid("c15f3664-828b-4094-b884-388b221a78c0"),
                            CreatedOn = new DateTime(2022, 9, 21, 22, 33, 12, 356, DateTimeKind.Utc).AddTicks(2555),
                            Status = 0,
                            UserId = new Guid("399976fe-cc8e-447e-b35c-388b11f59894")
                        });
                });

            modelBuilder.Entity("MilsatInternAPI.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("5f93be38-ecd8-4db8-8d58-12f1fc2a6460"),
                            Bio = "",
                            Department = 1,
                            Email = "mentor1@gmail.com",
                            FirstName = "Sodiq",
                            LastName = "Agboola",
                            PasswordHash = new byte[] { 15, 37, 186, 70, 217, 120, 220, 247, 255, 126, 19, 177, 5, 1, 110, 218, 61, 93, 54, 32, 247, 99, 138, 128, 11, 88, 26, 149, 21, 213, 33, 185, 52, 61, 174, 79, 226, 96, 188, 89, 159, 141, 211, 139, 40, 20, 236, 243, 228, 212, 119, 60, 239, 230, 121, 187, 12, 69, 14, 42, 4, 82, 100, 121 },
                            PasswordSalt = new byte[] { 130, 164, 39, 45, 52, 132, 93, 26, 43, 238, 11, 62, 25, 63, 131, 235, 42, 50, 39, 101, 35, 178, 71, 236, 19, 81, 0, 148, 180, 84, 170, 52, 224, 237, 126, 167, 75, 124, 19, 133, 31, 132, 99, 32, 81, 175, 252, 24, 206, 66, 83, 148, 75, 129, 112, 184, 186, 210, 245, 221, 6, 113, 70, 98, 139, 129, 65, 247, 45, 164, 15, 102, 150, 231, 52, 199, 161, 248, 54, 151, 64, 255, 59, 239, 22, 179, 86, 104, 58, 186, 132, 85, 2, 18, 159, 115, 134, 154, 93, 73, 114, 223, 118, 247, 249, 82, 230, 196, 29, 44, 239, 61, 37, 67, 179, 225, 121, 138, 243, 130, 52, 167, 23, 35, 16, 93, 2, 163 },
                            PhoneNumber = "string",
                            ProfilePicture = "",
                            Role = 2,
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            UserId = new Guid("399976fe-cc8e-447e-b35c-388b11f59894"),
                            Bio = "",
                            Department = 1,
                            Email = "mentor2@gmail.com",
                            FirstName = "Sodiq",
                            LastName = "Agboola",
                            PasswordHash = new byte[] { 127, 68, 21, 186, 73, 89, 67, 254, 143, 90, 220, 47, 199, 165, 153, 157, 49, 37, 40, 162, 118, 207, 149, 138, 158, 43, 250, 227, 4, 239, 242, 101, 135, 58, 3, 40, 215, 219, 94, 93, 33, 41, 45, 4, 13, 89, 237, 14, 156, 134, 88, 163, 239, 145, 2, 225, 178, 47, 109, 145, 3, 96, 22, 45 },
                            PasswordSalt = new byte[] { 59, 139, 95, 74, 50, 23, 77, 201, 64, 251, 39, 232, 14, 226, 161, 3, 195, 124, 219, 171, 82, 85, 227, 220, 101, 153, 255, 53, 218, 195, 236, 158, 70, 43, 66, 220, 195, 166, 120, 143, 233, 162, 6, 82, 229, 40, 164, 68, 222, 157, 206, 239, 140, 93, 84, 56, 46, 48, 155, 229, 172, 49, 170, 45, 91, 240, 84, 237, 78, 232, 214, 223, 160, 144, 140, 9, 205, 237, 150, 207, 246, 104, 24, 10, 202, 105, 224, 61, 206, 179, 138, 26, 174, 9, 227, 170, 175, 198, 115, 250, 74, 202, 88, 235, 26, 76, 82, 119, 213, 98, 238, 232, 181, 237, 184, 252, 133, 115, 55, 2, 71, 118, 113, 49, 87, 100, 57, 75 },
                            PhoneNumber = "string",
                            ProfilePicture = "",
                            Role = 2,
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            UserId = new Guid("26c33cb2-52e5-4eaf-92e4-bf8bfda54b78"),
                            Bio = "",
                            Department = 6,
                            Email = "admin@milsat.com",
                            FirstName = "admin",
                            LastName = "admin",
                            PasswordHash = new byte[] { 90, 97, 122, 29, 183, 83, 5, 95, 200, 219, 0, 45, 188, 231, 179, 55, 102, 135, 39, 236, 162, 255, 204, 235, 75, 26, 0, 100, 131, 202, 176, 216, 120, 14, 165, 115, 29, 187, 178, 117, 152, 49, 40, 20, 211, 112, 85, 167, 164, 51, 125, 236, 255, 11, 219, 76, 56, 174, 140, 74, 64, 156, 28, 18 },
                            PasswordSalt = new byte[] { 172, 111, 228, 36, 200, 60, 81, 255, 141, 11, 65, 184, 207, 143, 136, 222, 62, 22, 234, 69, 88, 112, 64, 193, 82, 157, 98, 169, 29, 137, 171, 28, 226, 124, 41, 87, 31, 98, 75, 65, 56, 87, 36, 252, 21, 9, 135, 145, 177, 153, 116, 38, 123, 66, 28, 250, 134, 122, 199, 8, 137, 8, 246, 3, 222, 86, 149, 85, 165, 127, 127, 211, 114, 170, 183, 123, 167, 147, 3, 142, 175, 231, 162, 114, 223, 167, 229, 17, 39, 163, 234, 42, 138, 89, 53, 239, 124, 49, 232, 11, 192, 101, 143, 83, 10, 61, 186, 29, 25, 206, 37, 239, 8, 83, 0, 223, 132, 115, 32, 118, 186, 220, 130, 241, 183, 63, 72, 181 },
                            PhoneNumber = "home",
                            ProfilePicture = "",
                            Role = 0,
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
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