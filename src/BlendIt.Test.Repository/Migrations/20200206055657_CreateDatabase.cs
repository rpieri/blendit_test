using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlendIt.Test.Repository.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(type: "varchar(50)", nullable: false),
                    removed = table.Column<bool>(nullable: false),
                    name = table.Column<string>(type: "varchar(150)", nullable: false),
                    registration = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("idTeacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(type: "varchar(50)", nullable: false),
                    removed = table.Column<bool>(nullable: false),
                    email = table.Column<string>(type: "varchar(250)", nullable: false),
                    password = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
