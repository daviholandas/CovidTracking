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
                    ActiveCases = table.Column<string>(type: "varchar(125)", nullable: true),
                    NewCases = table.Column<string>(type: "varchar(125)", nullable: true),
                    NewDeaths = table.Column<string>(type: "varchar(125)", nullable: true),
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
                    { new Guid("4beb7a7a-31c5-4e0c-ace1-507c4296c6ab"), "BR", 0, "Brazil" },
                    { new Guid("aace90ec-b6d7-454f-b2aa-d595e8d46e9e"), "JP", 0, "Japan" },
                    { new Guid("b54cb09f-1b50-45c8-be78-0e21115b2b26"), "NL", 0, "Netherlands" },
                    { new Guid("fa22824b-5270-4d6d-b460-5321fc771548"), "NG", 0, "Nigeria" },
                    { new Guid("70117276-b71d-419a-88c5-fcf3d403d11d"), "AU", 0, "Australia" },
                    { new Guid("cb3131af-6829-47ec-85cb-5a438af7c01f"), "W", 0, "World" }
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
