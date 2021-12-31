using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class NewMIg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Identification = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccountCode = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    ClienId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AccountCode", "ClientId", "Identification", "LastName", "Name" },
                values: new object[] { new Guid("e3d05112-fae7-4e44-8e49-3824f80fdeb0"), 2551, null, true, "Boluevna", "Olucha" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AccountCode", "ClientId", "Identification", "LastName", "Name" },
                values: new object[] { new Guid("1b2369f3-626f-43bb-b1e8-2aee11ac47d5"), 2883, null, true, "holova", "Anora" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientId",
                table: "Clients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_ClientId",
                table: "Wallet",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
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
    }
}
