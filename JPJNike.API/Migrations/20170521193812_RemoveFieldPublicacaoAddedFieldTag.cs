using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JPJNike.API.Migrations
{
    public partial class RemoveFieldPublicacaoAddedFieldTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publicacao",
                table: "BlogPosts");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "BlogPosts",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "BlogPosts");

            migrationBuilder.AddColumn<DateTime>(
                name: "Publicacao",
                table: "BlogPosts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
