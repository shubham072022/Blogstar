﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogStar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IsPublishedAddedToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Posts");
        }
    }
}
