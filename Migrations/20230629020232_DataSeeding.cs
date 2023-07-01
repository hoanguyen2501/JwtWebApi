﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtWebApi.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 1, "Hoang", "Nguyen Ba", new byte[] { 12, 240, 208, 168, 73, 39, 203, 139, 29, 147, 170, 196, 145, 25, 17, 95, 96, 183, 246, 87, 25, 127, 246, 148, 31, 6, 105, 73, 38, 186, 87, 10, 119, 121, 135, 246, 189, 25, 33, 203, 215, 7, 25, 120, 63, 131, 223, 29, 218, 142, 190, 70, 178, 135, 147, 12, 186, 41, 48, 171, 192, 177, 139, 125 }, new byte[] { 159, 5, 232, 192, 85, 129, 164, 146, 36, 23, 207, 224, 236, 139, 115, 96, 107, 52, 231, 160, 221, 101, 249, 38, 48, 241, 223, 25, 22, 63, 67, 133, 142, 230, 211, 27, 36, 31, 124, 12, 92, 121, 35, 245, 170, 208, 107, 90, 181, 214, 243, 202, 249, 55, 245, 15, 117, 161, 86, 236, 223, 52, 48, 171, 136, 33, 40, 111, 8, 49, 100, 211, 83, 26, 191, 37, 92, 153, 212, 118, 126, 88, 97, 149, 9, 140, 237, 5, 104, 211, 206, 26, 14, 138, 190, 87, 142, 197, 97, 86, 244, 195, 180, 68, 176, 170, 165, 3, 155, 12, 248, 5, 10, 53, 2, 82, 55, 222, 14, 178, 233, 74, 234, 19, 106, 108, 31, 66 }, 1, "hnb" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 2, "Hoang", "Nguyen Ba", new byte[] { 12, 240, 208, 168, 73, 39, 203, 139, 29, 147, 170, 196, 145, 25, 17, 95, 96, 183, 246, 87, 25, 127, 246, 148, 31, 6, 105, 73, 38, 186, 87, 10, 119, 121, 135, 246, 189, 25, 33, 203, 215, 7, 25, 120, 63, 131, 223, 29, 218, 142, 190, 70, 178, 135, 147, 12, 186, 41, 48, 171, 192, 177, 139, 125 }, new byte[] { 159, 5, 232, 192, 85, 129, 164, 146, 36, 23, 207, 224, 236, 139, 115, 96, 107, 52, 231, 160, 221, 101, 249, 38, 48, 241, 223, 25, 22, 63, 67, 133, 142, 230, 211, 27, 36, 31, 124, 12, 92, 121, 35, 245, 170, 208, 107, 90, 181, 214, 243, 202, 249, 55, 245, 15, 117, 161, 86, 236, 223, 52, 48, 171, 136, 33, 40, 111, 8, 49, 100, 211, 83, 26, 191, 37, 92, 153, 212, 118, 126, 88, 97, 149, 9, 140, 237, 5, 104, 211, 206, 26, 14, 138, 190, 87, 142, 197, 97, 86, 244, 195, 180, 68, 176, 170, 165, 3, 155, 12, 248, 5, 10, 53, 2, 82, 55, 222, 14, 178, 233, 74, 234, 19, 106, 108, 31, 66 }, 2, "nbh" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}