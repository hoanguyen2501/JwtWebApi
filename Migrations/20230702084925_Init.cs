using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace JwtWebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true),
                    LastName = table.Column<string>(type: "longtext", nullable: true),
                    Username = table.Column<string>(type: "longtext", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "longblob", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 1, "Hoang", "Nguyen Ba", new byte[] { 93, 137, 0, 72, 54, 89, 76, 145, 109, 173, 22, 3, 185, 70, 60, 69, 207, 120, 122, 49, 225, 200, 159, 49, 56, 18, 93, 122, 177, 191, 74, 7, 210, 167, 217, 161, 188, 99, 21, 69, 221, 58, 159, 113, 66, 92, 190, 228, 148, 166, 148, 61, 234, 254, 204, 29, 77, 140, 35, 90, 9, 65, 241, 201 }, new byte[] { 4, 131, 83, 162, 217, 75, 77, 204, 8, 133, 209, 117, 216, 201, 221, 170, 245, 123, 160, 156, 166, 187, 149, 89, 120, 162, 159, 132, 73, 34, 63, 182, 77, 42, 207, 204, 115, 143, 118, 250, 136, 149, 251, 193, 78, 89, 140, 110, 62, 24, 160, 39, 163, 6, 70, 138, 65, 247, 90, 97, 157, 176, 11, 8, 240, 14, 18, 168, 56, 7, 48, 23, 187, 65, 226, 219, 176, 179, 52, 189, 210, 122, 111, 235, 90, 9, 67, 53, 188, 132, 178, 92, 127, 65, 68, 212, 58, 179, 230, 187, 41, 47, 114, 112, 217, 60, 145, 75, 194, 236, 35, 143, 41, 22, 100, 45, 147, 231, 222, 199, 30, 106, 25, 27, 31, 35, 223, 215 }, 1, "hnb" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 2, "Hoang", "Nguyen Ba", new byte[] { 93, 137, 0, 72, 54, 89, 76, 145, 109, 173, 22, 3, 185, 70, 60, 69, 207, 120, 122, 49, 225, 200, 159, 49, 56, 18, 93, 122, 177, 191, 74, 7, 210, 167, 217, 161, 188, 99, 21, 69, 221, 58, 159, 113, 66, 92, 190, 228, 148, 166, 148, 61, 234, 254, 204, 29, 77, 140, 35, 90, 9, 65, 241, 201 }, new byte[] { 4, 131, 83, 162, 217, 75, 77, 204, 8, 133, 209, 117, 216, 201, 221, 170, 245, 123, 160, 156, 166, 187, 149, 89, 120, 162, 159, 132, 73, 34, 63, 182, 77, 42, 207, 204, 115, 143, 118, 250, 136, 149, 251, 193, 78, 89, 140, 110, 62, 24, 160, 39, 163, 6, 70, 138, 65, 247, 90, 97, 157, 176, 11, 8, 240, 14, 18, 168, 56, 7, 48, 23, 187, 65, 226, 219, 176, 179, 52, 189, 210, 122, 111, 235, 90, 9, 67, 53, 188, 132, 178, 92, 127, 65, 68, 212, 58, 179, 230, 187, 41, 47, 114, 112, 217, 60, 145, 75, 194, 236, 35, 143, 41, 22, 100, 45, 147, 231, 222, 199, 30, 106, 25, 27, 31, 35, 223, 215 }, 2, "nbh" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
