using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class Quotsend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { new Guid("add3f7db-1191-44a9-af14-4d6c43384771"), "Pophet Muhammad (SAW)", new DateTime(2021, 11, 6, 17, 49, 34, 602, DateTimeKind.Local).AddTicks(1309), "When a thing distrubs the peace of your hurt give it up" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { new Guid("e8ae0d48-69e6-4d85-80c1-5e4308c4cf45"), "Ernest Hemingway", new DateTime(2021, 11, 6, 17, 49, 34, 603, DateTimeKind.Local).AddTicks(5457), "In order to write about life first you must live it." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { new Guid("c00eac12-5046-428f-b619-9b15b578a2f7"), "Albert Einstein", new DateTime(2021, 11, 6, 17, 49, 34, 603, DateTimeKind.Local).AddTicks(5484), "Genius is 1% talent and 99% percent hard work..." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { new Guid("108eaa30-1f39-4e6c-8155-8802b018be03"), "Will Smith", new DateTime(2021, 11, 6, 17, 49, 34, 603, DateTimeKind.Local).AddTicks(5488), "Money and success don’t change people; they merely amplify what is already there." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { new Guid("a3b9d1d5-8f64-4eea-bffa-1e27b967b3c9"), "stoicism", new DateTime(2021, 11, 6, 17, 49, 34, 603, DateTimeKind.Local).AddTicks(5492), "Memento mori" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
