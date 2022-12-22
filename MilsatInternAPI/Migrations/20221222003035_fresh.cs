using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilsatInternAPI.Migrations
{
    public partial class fresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bio = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfilePicture = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "longblob", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "longblob", nullable: false),
                    RefreshToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordResetToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordTokenExpires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mentor",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Mentor_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Intern",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CourseOfStudy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Institution = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    MentorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intern", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Intern_Mentor_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentor",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Intern_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordResetToken", "PasswordSalt", "PasswordTokenExpires", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires", "isDeleted" },
                values: new object[] { new Guid("83f75ab4-c696-4957-9ad0-32ff0fe7ae46"), "", 0, "mentor2@gmail.com", "Sodiq Agboola", 0, new byte[] { 148, 219, 42, 142, 20, 0, 198, 209, 8, 204, 164, 106, 68, 222, 42, 79, 75, 13, 55, 253, 24, 157, 119, 170, 66, 228, 52, 16, 75, 117, 200, 105, 168, 148, 221, 92, 62, 72, 97, 88, 200, 140, 218, 74, 247, 254, 239, 30, 46, 66, 121, 131, 76, 246, 16, 128, 112, 202, 81, 108, 78, 171, 243, 194 }, null, new byte[] { 99, 217, 26, 16, 163, 17, 182, 214, 32, 38, 255, 107, 6, 158, 104, 247, 113, 177, 17, 40, 38, 26, 199, 110, 242, 246, 212, 35, 153, 121, 106, 247, 96, 33, 33, 182, 241, 183, 118, 102, 211, 147, 39, 251, 185, 159, 214, 34, 143, 133, 104, 108, 18, 132, 219, 68, 223, 118, 218, 81, 127, 97, 166, 175, 130, 246, 193, 99, 204, 53, 229, 195, 76, 112, 252, 188, 6, 200, 19, 37, 191, 13, 88, 202, 27, 186, 209, 214, 110, 191, 92, 7, 49, 248, 197, 26, 154, 205, 166, 4, 16, 97, 68, 0, 164, 190, 41, 65, 192, 29, 67, 75, 225, 17, 94, 19, 184, 248, 251, 57, 19, 170, 115, 216, 37, 207, 244, 49 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "passwords", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordResetToken", "PasswordSalt", "PasswordTokenExpires", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires", "isDeleted" },
                values: new object[] { new Guid("98d22c64-dc0d-4fd5-934c-87c6d01990b2"), "", 0, "mentor1@gmail.com", "Sodiq Agboola", 0, new byte[] { 252, 83, 227, 25, 193, 60, 209, 48, 170, 56, 55, 38, 137, 6, 166, 47, 202, 22, 248, 132, 167, 192, 130, 227, 199, 190, 8, 126, 105, 240, 33, 20, 172, 44, 54, 63, 209, 50, 31, 112, 231, 144, 225, 48, 232, 16, 1, 84, 70, 250, 52, 36, 18, 175, 109, 17, 35, 128, 40, 73, 149, 241, 39, 50 }, null, new byte[] { 238, 178, 180, 150, 94, 138, 28, 122, 124, 31, 49, 193, 231, 182, 108, 38, 143, 223, 188, 237, 206, 45, 214, 43, 161, 101, 79, 167, 229, 40, 187, 200, 234, 206, 96, 28, 222, 134, 180, 47, 147, 132, 102, 210, 4, 152, 147, 191, 100, 138, 197, 248, 87, 32, 196, 17, 159, 139, 48, 79, 202, 55, 52, 5, 216, 19, 104, 22, 135, 146, 160, 139, 156, 219, 13, 200, 242, 160, 242, 131, 203, 182, 3, 157, 95, 114, 230, 216, 208, 219, 91, 129, 225, 241, 63, 159, 195, 107, 55, 26, 121, 92, 246, 92, 10, 207, 38, 65, 226, 233, 186, 43, 42, 153, 19, 103, 195, 53, 10, 247, 181, 235, 236, 45, 209, 221, 26, 196 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "passwords", "", null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "Department", "Email", "FullName", "Gender", "PasswordHash", "PasswordResetToken", "PasswordSalt", "PasswordTokenExpires", "PhoneNumber", "ProfilePicture", "RefreshToken", "Role", "TokenCreated", "TokenExpires", "isDeleted" },
                values: new object[] { new Guid("9bc02df4-d3b9-4f3a-9949-13c21f76990e"), "", 5, "admin@milsat.com", "Admin", 0, new byte[] { 190, 76, 133, 224, 53, 129, 250, 89, 32, 161, 178, 133, 129, 22, 34, 152, 200, 207, 70, 133, 21, 116, 80, 141, 135, 239, 88, 154, 122, 159, 120, 80, 255, 139, 129, 133, 18, 24, 118, 99, 212, 10, 149, 171, 146, 114, 15, 133, 34, 180, 77, 3, 7, 114, 229, 75, 102, 227, 3, 195, 129, 24, 180, 23 }, null, new byte[] { 33, 164, 102, 3, 212, 160, 180, 223, 8, 126, 168, 251, 75, 20, 23, 75, 92, 174, 15, 116, 215, 163, 153, 194, 29, 217, 98, 23, 91, 121, 74, 201, 179, 152, 227, 212, 224, 72, 34, 8, 80, 44, 85, 57, 224, 35, 39, 68, 23, 15, 113, 27, 64, 167, 59, 22, 220, 143, 4, 194, 96, 39, 173, 92, 225, 170, 168, 210, 40, 45, 23, 53, 102, 140, 155, 31, 112, 35, 220, 222, 62, 157, 178, 102, 38, 128, 188, 214, 217, 30, 49, 10, 32, 189, 234, 9, 27, 154, 188, 204, 122, 169, 143, 156, 132, 161, 57, 186, 95, 225, 106, 37, 106, 69, 237, 220, 171, 132, 187, 55, 217, 137, 180, 14, 151, 141, 90, 80 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "datasolutions", "", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("83f75ab4-c696-4957-9ad0-32ff0fe7ae46"), new DateTime(2022, 12, 22, 0, 30, 35, 79, DateTimeKind.Utc).AddTicks(8443), 0 });

            migrationBuilder.InsertData(
                table: "Mentor",
                columns: new[] { "UserId", "CreatedOn", "Status" },
                values: new object[] { new Guid("98d22c64-dc0d-4fd5-934c-87c6d01990b2"), new DateTime(2022, 12, 22, 0, 30, 35, 79, DateTimeKind.Utc).AddTicks(8441), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Intern_MentorId",
                table: "Intern",
                column: "MentorId");
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
