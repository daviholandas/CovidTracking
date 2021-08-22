using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoxTI.Challenge.CovidTracking.WebApi.Data.Migrations
{
    public partial class ChangeActiveStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("4beb7a7a-31c5-4e0c-ace1-507c4296c6ab"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("70117276-b71d-419a-88c5-fcf3d403d11d"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("aace90ec-b6d7-454f-b2aa-d595e8d46e9e"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("b54cb09f-1b50-45c8-be78-0e21115b2b26"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("cb3131af-6829-47ec-85cb-5a438af7c01f"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("fa22824b-5270-4d6d-b460-5321fc771548"));

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Abbreviation", "ActiveStatus", "Name" },
                values: new object[,]
                {
                    { new Guid("f5f6ccc7-f4ca-4464-a19d-e34f91c449ba"), "BR", 1, "Brazil" },
                    { new Guid("67a45522-526a-465f-b561-dc324cfebc3d"), "JP", 1, "Japan" },
                    { new Guid("dab860dc-cfe8-4aea-835a-9cc598c357fd"), "NL", 1, "Netherlands" },
                    { new Guid("4ad0e2a6-6ddb-4cd1-badc-ca7e4882d59d"), "NG", 1, "Nigeria" },
                    { new Guid("47db3c74-ddf8-46c1-ab01-a1400b47cf5f"), "AU", 1, "Australia" },
                    { new Guid("43cd6707-0e21-41cd-b345-489799f51205"), "W", 1, "World" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("43cd6707-0e21-41cd-b345-489799f51205"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("47db3c74-ddf8-46c1-ab01-a1400b47cf5f"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("4ad0e2a6-6ddb-4cd1-badc-ca7e4882d59d"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("67a45522-526a-465f-b561-dc324cfebc3d"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("dab860dc-cfe8-4aea-835a-9cc598c357fd"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("f5f6ccc7-f4ca-4464-a19d-e34f91c449ba"));

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
        }
    }
}
