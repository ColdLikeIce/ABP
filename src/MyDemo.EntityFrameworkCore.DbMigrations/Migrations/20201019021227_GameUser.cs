using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDemo.Migrations
{
    public partial class GameUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppGameUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 18, nullable: true),
                    PassWord = table.Column<string>(maxLength: 18, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    ThirdOpenId = table.Column<string>(nullable: true),
                    ThirdToken = table.Column<string>(nullable: true),
                    IsThirdConfirmed = table.Column<bool>(nullable: false),
                    Port = table.Column<string>(nullable: true),
                    Lang = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    RegisterTime = table.Column<DateTime>(nullable: false),
                    LoginTime = table.Column<DateTime>(nullable: false),
                    IsForbidden = table.Column<bool>(nullable: false),
                    ErrCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppGameUsers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppGameUsers");
        }
    }
}
