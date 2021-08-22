using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoxTI.Challenge.CovidTracking.WebApi.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(125)", nullable: true),
                    Abbreviation = table.Column<string>(type: "varchar(125)", nullable: true),
                    ActiveStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveCases = table.Column<double>(type: "float", nullable: false),
                    NewCases = table.Column<double>(type: "float", nullable: false),
                    NewDeaths = table.Column<double>(type: "float", nullable: false),
                    TotalCases = table.Column<double>(type: "float", nullable: false),
                    TotalDeaths = table.Column<double>(type: "float", nullable: false),
                    TotalRecovered = table.Column<double>(type: "float", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Abbreviation", "ActiveStatus", "Name" },
                values: new object[,]
                {
                    { new Guid("a692679d-78c3-4787-ab5e-811921e2688d"), "BR", 1, "Brazil" },
                    { new Guid("cb250c26-6683-4e58-b86b-96f947d73d9d"), "JP", 1, "Japan" },
                    { new Guid("78418662-981c-4127-a203-bb11d7e8cef6"), "NL", 1, "Netherlands" },
                    { new Guid("9fbc47c5-f5a8-4363-8452-0325be5256f7"), "NG", 1, "Nigeria" },
                    { new Guid("46832224-7952-4a10-84d9-ac855df6d8bb"), "AU", 1, "Australia" },
                    { new Guid("49bce409-009b-4c1b-93d1-4fcca7023521"), "W", 1, "World" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_LocationId",
                table: "Reports",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
