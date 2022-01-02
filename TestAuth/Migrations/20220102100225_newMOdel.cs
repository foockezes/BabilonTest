using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAuth.Migrations
{
    public partial class newMOdel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("099bf65c-48cd-479d-be1f-c60509d905bb"));

            migrationBuilder.DropColumn(
                name: "Usercode",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identification = table.Column<bool>(type: "bit", nullable: false),
                    AccountCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "RoleId" },
                values: new object[] { new Guid("1d64272e-c4e1-4aba-a620-9f7d93abb82e"), "admin", "admin", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1d64272e-c4e1-4aba-a620-9f7d93abb82e"));

            migrationBuilder.AddColumn<int>(
                name: "Usercode",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "RoleId", "Usercode" },
                values: new object[] { new Guid("099bf65c-48cd-479d-be1f-c60509d905bb"), "admin", "admin", 1, 0 });
        }
    }
}
