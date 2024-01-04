﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JsonWebToken.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JWTUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JWTUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "JWTUser",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "1111", "Adir" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JWTUser");
        }
    }
}
