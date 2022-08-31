﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Mentor",
                columns: table => new
                {
                    MentorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.MentorId);
                    table.ForeignKey(
                        name: "FK_Mentor_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intern",
                columns: table => new
                {
                    InternId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MentorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intern", x => x.InternId);
                    table.ForeignKey(
                        name: "FK_Intern_Mentor_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentor",
                        principalColumn: "MentorId");
                    table.ForeignKey(
                        name: "FK_Intern_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "PasswordHash", "PasswordSalt", "RefreshToken", "Role", "TokenCreated", "TokenExpires" },
                values: new object[,]
                {
                    { new Guid("1b630927-68ba-454f-bc60-6b0d9bacee97"), "2@gmail.com", new byte[] { 156, 64, 234, 199, 85, 124, 126, 24, 211, 28, 47, 154, 177, 69, 171, 86, 114, 149, 171, 219, 133, 132, 222, 51, 117, 2, 26, 169, 225, 213, 78, 190, 49, 169, 231, 87, 139, 161, 211, 77, 191, 160, 84, 100, 83, 186, 183, 238, 21, 239, 82, 177, 48, 136, 195, 154, 227, 205, 173, 234, 224, 204, 241, 84 }, new byte[] { 224, 95, 92, 31, 100, 99, 27, 198, 146, 162, 235, 198, 73, 252, 64, 4, 136, 41, 135, 31, 133, 252, 12, 148, 171, 247, 225, 29, 158, 213, 35, 164, 29, 119, 105, 27, 86, 32, 143, 195, 90, 12, 17, 203, 80, 131, 74, 156, 43, 64, 31, 86, 242, 30, 68, 92, 46, 120, 154, 30, 75, 51, 111, 52, 33, 81, 183, 52, 122, 154, 31, 225, 198, 223, 50, 125, 58, 216, 13, 152, 17, 0, 111, 155, 48, 161, 164, 142, 136, 54, 144, 246, 181, 27, 50, 72, 230, 103, 53, 106, 63, 199, 183, 103, 9, 16, 21, 3, 40, 62, 136, 10, 53, 32, 41, 251, 35, 210, 176, 166, 135, 249, 172, 67, 226, 145, 146, 146 }, "", "Mentor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("226840e2-b95a-474b-98c3-4ecae8606d5c"), "4@gmail.com", new byte[] { 126, 237, 156, 250, 130, 167, 110, 161, 222, 202, 87, 35, 224, 88, 37, 89, 49, 187, 100, 80, 167, 39, 77, 248, 59, 41, 244, 114, 210, 162, 234, 245, 135, 148, 117, 115, 203, 37, 209, 49, 144, 237, 36, 196, 45, 188, 40, 25, 103, 70, 58, 44, 14, 98, 195, 19, 199, 134, 170, 138, 150, 63, 48, 36 }, new byte[] { 72, 56, 61, 199, 8, 70, 255, 146, 229, 220, 62, 34, 89, 197, 13, 59, 18, 11, 200, 191, 148, 106, 81, 105, 15, 218, 59, 209, 73, 2, 252, 255, 204, 30, 95, 87, 112, 136, 93, 78, 215, 42, 173, 142, 213, 83, 124, 58, 111, 140, 185, 170, 207, 59, 148, 72, 237, 58, 43, 213, 225, 225, 52, 213, 42, 27, 102, 186, 129, 167, 201, 85, 48, 47, 111, 37, 44, 68, 47, 168, 9, 223, 35, 167, 97, 5, 22, 238, 8, 37, 189, 223, 135, 23, 2, 150, 57, 30, 162, 41, 130, 205, 2, 179, 113, 177, 220, 5, 244, 160, 108, 37, 53, 253, 213, 87, 142, 39, 38, 178, 45, 174, 139, 63, 205, 104, 176, 107 }, "", "Mentor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2764ee79-8086-46e0-81fa-b9c72bec1122"), "3@gmail.com", new byte[] { 139, 247, 237, 240, 164, 64, 112, 113, 76, 45, 70, 30, 242, 174, 42, 29, 23, 184, 58, 167, 178, 40, 43, 63, 89, 161, 140, 187, 19, 201, 66, 228, 143, 188, 227, 187, 58, 40, 44, 88, 70, 255, 126, 25, 58, 169, 245, 183, 167, 137, 196, 87, 167, 211, 111, 14, 86, 127, 23, 174, 68, 230, 126, 238 }, new byte[] { 199, 200, 101, 236, 162, 136, 246, 11, 37, 107, 18, 53, 206, 132, 161, 137, 123, 25, 16, 121, 143, 230, 129, 222, 190, 143, 49, 125, 9, 52, 247, 63, 235, 130, 201, 67, 121, 47, 16, 203, 59, 29, 248, 138, 46, 149, 0, 44, 165, 13, 118, 129, 130, 41, 254, 4, 129, 100, 107, 236, 138, 225, 176, 112, 131, 222, 246, 106, 88, 218, 172, 12, 74, 6, 97, 136, 243, 238, 47, 50, 106, 219, 243, 123, 206, 80, 45, 104, 83, 193, 100, 2, 95, 167, 223, 209, 206, 79, 71, 90, 180, 137, 128, 241, 16, 101, 251, 115, 26, 208, 27, 241, 160, 97, 8, 159, 206, 67, 12, 192, 146, 238, 32, 129, 222, 32, 150, 237 }, "", "Mentor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7b8b54ef-22a1-4e94-aec3-b773648abde4"), "admin@milsat.com", new byte[] { 77, 98, 205, 42, 250, 3, 186, 17, 110, 209, 185, 234, 134, 165, 30, 26, 4, 228, 215, 28, 174, 250, 116, 85, 193, 134, 236, 201, 230, 81, 191, 145, 44, 25, 124, 247, 211, 91, 111, 170, 137, 107, 191, 104, 107, 231, 220, 182, 197, 106, 185, 227, 127, 57, 231, 46, 28, 22, 143, 81, 105, 188, 2, 26 }, new byte[] { 201, 163, 153, 77, 67, 164, 140, 129, 245, 170, 152, 9, 156, 202, 13, 77, 138, 108, 38, 235, 3, 26, 158, 123, 203, 191, 192, 50, 164, 9, 101, 14, 118, 11, 105, 61, 179, 224, 152, 106, 43, 124, 245, 84, 167, 228, 165, 205, 98, 39, 196, 175, 246, 164, 229, 81, 246, 134, 133, 136, 215, 228, 164, 239, 232, 47, 1, 99, 216, 19, 105, 124, 19, 246, 89, 6, 122, 249, 237, 114, 84, 1, 132, 53, 138, 15, 231, 241, 5, 180, 95, 223, 193, 2, 176, 199, 214, 229, 161, 41, 74, 111, 150, 115, 217, 79, 183, 164, 87, 197, 121, 254, 64, 191, 85, 64, 161, 254, 185, 172, 126, 50, 141, 43, 161, 109, 38, 80 }, "", "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7e54e98d-1a6e-4347-ab76-270973c55558"), "1@gmail.com", new byte[] { 137, 239, 53, 197, 207, 168, 35, 206, 197, 134, 133, 133, 52, 150, 130, 131, 132, 41, 108, 118, 64, 79, 224, 204, 6, 159, 210, 246, 214, 176, 98, 107, 7, 83, 11, 249, 163, 45, 67, 37, 247, 16, 191, 227, 11, 56, 79, 147, 187, 88, 159, 54, 246, 167, 11, 199, 13, 66, 217, 34, 152, 251, 70, 79 }, new byte[] { 2, 253, 106, 58, 101, 78, 144, 115, 81, 37, 245, 176, 123, 134, 75, 149, 103, 223, 110, 120, 127, 36, 88, 108, 149, 133, 50, 4, 106, 204, 73, 183, 84, 43, 196, 247, 12, 167, 67, 52, 162, 189, 199, 181, 2, 183, 139, 81, 122, 2, 77, 71, 28, 91, 98, 104, 72, 69, 142, 78, 18, 151, 49, 62, 236, 156, 230, 189, 57, 59, 8, 40, 129, 34, 48, 39, 130, 168, 173, 110, 21, 194, 38, 144, 208, 212, 46, 168, 132, 147, 45, 198, 254, 75, 67, 8, 164, 13, 103, 207, 48, 62, 183, 182, 147, 74, 131, 57, 206, 10, 206, 145, 85, 12, 10, 248, 140, 24, 27, 253, 212, 169, 197, 65, 234, 98, 238, 233 }, "", "Mentor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7e75d009-e5d6-4a08-9032-ce5e63acd4b2"), "5@gmail.com", new byte[] { 55, 88, 203, 159, 34, 38, 71, 25, 7, 142, 43, 18, 131, 16, 81, 96, 209, 239, 214, 87, 107, 206, 11, 159, 94, 32, 87, 1, 65, 28, 192, 143, 16, 192, 0, 199, 27, 103, 218, 97, 43, 66, 102, 58, 174, 133, 214, 143, 109, 81, 167, 129, 254, 123, 231, 196, 243, 210, 37, 154, 12, 183, 147, 105 }, new byte[] { 254, 94, 224, 188, 129, 31, 96, 188, 246, 86, 214, 37, 78, 99, 193, 90, 145, 250, 32, 21, 162, 167, 87, 200, 211, 23, 72, 247, 78, 32, 15, 251, 149, 48, 140, 136, 54, 193, 84, 222, 40, 228, 175, 152, 25, 181, 34, 222, 177, 16, 238, 206, 104, 102, 174, 101, 160, 247, 6, 52, 247, 183, 193, 53, 39, 218, 137, 183, 65, 233, 194, 74, 88, 77, 116, 126, 172, 141, 200, 37, 82, 178, 180, 25, 104, 45, 149, 242, 135, 82, 87, 146, 69, 112, 10, 53, 226, 191, 12, 10, 60, 132, 149, 123, 175, 250, 83, 237, 125, 221, 249, 232, 60, 49, 63, 53, 242, 25, 184, 54, 24, 159, 217, 79, 26, 65, 183, 176 }, "", "Mentor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f66fb936-e44f-4b5e-ac33-ad3ae2fc2073"), "0@gmail.com", new byte[] { 21, 85, 254, 54, 127, 19, 142, 89, 247, 215, 28, 63, 2, 191, 74, 99, 100, 196, 179, 231, 63, 107, 231, 96, 8, 41, 61, 60, 34, 153, 195, 250, 96, 12, 53, 245, 151, 221, 123, 46, 155, 227, 110, 209, 114, 176, 35, 155, 225, 57, 159, 218, 247, 28, 41, 252, 53, 12, 171, 132, 76, 137, 37, 133 }, new byte[] { 52, 181, 81, 22, 47, 156, 233, 151, 172, 76, 22, 101, 200, 225, 248, 91, 77, 72, 132, 32, 221, 249, 34, 156, 97, 204, 59, 253, 106, 104, 166, 141, 149, 225, 89, 45, 58, 107, 64, 13, 229, 190, 61, 84, 69, 11, 62, 98, 159, 220, 121, 3, 172, 246, 218, 28, 84, 149, 194, 57, 153, 180, 74, 211, 249, 48, 209, 105, 22, 87, 228, 252, 175, 26, 239, 50, 175, 28, 23, 185, 164, 3, 15, 204, 12, 75, 89, 75, 74, 120, 46, 98, 92, 90, 108, 140, 81, 118, 21, 114, 32, 92, 26, 223, 59, 44, 245, 62, 138, 58, 210, 195, 39, 154, 113, 184, 29, 230, 129, 173, 39, 112, 97, 224, 231, 165, 61, 19 }, "", "Mentor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "MentorId", "CreatedOn", "Department", "FirstName", "LastName", "PhoneNumber", "Status", "UserId" },
                values: new object[,]
                {
                    { new Guid("1c730269-3f9a-424b-ab9c-21a252f4e3be"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sodiq", "Agboola", "string", 0, new Guid("f66fb936-e44f-4b5e-ac33-ad3ae2fc2073") },
                    { new Guid("86cc5464-fa6d-4c7f-8c71-384db5bb81e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Elon", "Musk", "string", 0, new Guid("7e75d009-e5d6-4a08-9032-ce5e63acd4b2") },
                    { new Guid("b610e3ee-89b6-4eba-820a-a9c99b9feffb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Ayodeji", "Smart", "string", 0, new Guid("2764ee79-8086-46e0-81fa-b9c72bec1122") },
                    { new Guid("c9bd4e63-0e80-4503-8f5e-54da75983800"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Meenat", "Victoria", "string", 0, new Guid("1b630927-68ba-454f-bc60-6b0d9bacee97") },
                    { new Guid("d8b0b0df-64ec-4747-8d37-1bd76660e2e9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Emmanuel", "Victor", "string", 0, new Guid("7e54e98d-1a6e-4347-ab76-270973c55558") },
                    { new Guid("f482d588-b60c-4c3b-8fe5-a34255f52c2c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Michael", "Smith", "string", 0, new Guid("226840e2-b95a-474b-98c3-4ecae8606d5c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intern_MentorId",
                table: "Intern",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Intern_UserId",
                table: "Intern",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentor_UserId",
                table: "Mentor",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intern");

            migrationBuilder.DropTable(
                name: "Mentor");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
