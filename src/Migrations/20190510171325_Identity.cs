﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace src.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<string>(nullable: false),
                AccessFailedCount = table.Column<int>(nullable: false),
                ConcurrencyStamp = table.Column<string>(nullable: true),
                Email = table.Column<string>(nullable: true),
                EmailConfirmed = table.Column<bool>(nullable: false),
                LockoutEnabled = table.Column<bool>(nullable: false),
                LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                NormalizedEmail = table.Column<string>(nullable: true),
                NormalizedUserName = table.Column<string>(nullable: true),
                PasswordHash = table.Column<string>(nullable: true),
                PhoneNumber = table.Column<string>(nullable: true),
                PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                SecurityStamp = table.Column<string>(nullable: true),
                TwoFactorEnabled = table.Column<bool>(nullable: false),
                UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
