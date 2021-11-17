using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinApp.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumptionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccuredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    ConsumptionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConsumptionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_ConsumptionTypes_ConsumptionTypeId",
                        column: x => x.ConsumptionTypeId,
                        principalTable: "ConsumptionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConsumptionTypes",
                columns: new[] { "Id", "Name", "Unit" },
                values: new object[] { new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), "Prąd", 0 });

            migrationBuilder.InsertData(
                table: "ConsumptionTypes",
                columns: new[] { "Id", "Name", "Unit" },
                values: new object[] { new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), "Gaz", 2 });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "ConsumptionAmount", "ConsumptionTypeId", "Currency", "OccuredAt", "PaidAmount" },
                values: new object[,]
                {
                    { new Guid("34ffaa48-6360-497b-b867-ac2f6b693640"), 0m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2019, 7, 11, 22, 40, 9, 0, DateTimeKind.Unspecified), 62.87m },
                    { new Guid("cbcc050c-1484-4abd-9243-2a27e770cf6a"), 171m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2020, 3, 13, 13, 55, 33, 0, DateTimeKind.Unspecified), 330m },
                    { new Guid("e1c7bf28-e2ca-4236-9640-8e3504750035"), 120m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2020, 4, 15, 16, 35, 7, 0, DateTimeKind.Unspecified), 239.15m },
                    { new Guid("1a500f66-c37f-4daa-bbbd-c036f361cb9c"), 43m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2020, 5, 13, 14, 19, 45, 0, DateTimeKind.Unspecified), 99.66m },
                    { new Guid("b9456062-69b2-40fa-9d0b-925a1718b5e9"), 26m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2020, 6, 15, 13, 13, 37, 0, DateTimeKind.Unspecified), 68m },
                    { new Guid("b7ed462b-4f84-4c41-b4c4-d5740ff8e4bd"), 15m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2020, 7, 14, 16, 43, 26, 0, DateTimeKind.Unspecified), 47m },
                    { new Guid("6ff3a26a-ac30-4fbd-bf45-c379d9db1fec"), 14m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2020, 8, 14, 12, 18, 7, 0, DateTimeKind.Unspecified), 45m },
                    { new Guid("a7b4dc45-6cb3-4acc-889a-7df3fba917b4"), 30m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2020, 9, 30, 15, 28, 29, 0, DateTimeKind.Unspecified), 77.55m },
                    { new Guid("a4826401-699e-432b-b00c-4f8d0f60664b"), 19m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2020, 10, 21, 19, 46, 44, 0, DateTimeKind.Unspecified), 47.18m },
                    { new Guid("baad5864-c4d4-4fed-a285-1c4db878b383"), 202m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2020, 2, 12, 15, 14, 11, 0, DateTimeKind.Unspecified), 388m },
                    { new Guid("50391362-fb6c-4405-bf97-4c93aa7e68c9"), 129m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2020, 11, 17, 15, 27, 21, 0, DateTimeKind.Unspecified), 240m },
                    { new Guid("d9401f91-fb2f-4a97-be1c-e23d6209b504"), 193m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2021, 1, 18, 22, 35, 50, 0, DateTimeKind.Unspecified), 343m },
                    { new Guid("20b3d9bb-9ee9-4225-9256-6aeef4ff97cb"), 231m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2021, 2, 16, 14, 13, 9, 0, DateTimeKind.Unspecified), 401.13m },
                    { new Guid("84a7f889-6a0f-4490-816d-49f7f5a78f7b"), 176m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2021, 3, 17, 19, 36, 57, 0, DateTimeKind.Unspecified), 311m },
                    { new Guid("03521164-0078-4460-a67f-f1090a69175d"), 140m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2021, 4, 16, 19, 9, 30, 0, DateTimeKind.Unspecified), 250m },
                    { new Guid("a30e1da9-b224-4dc6-96e3-1d11097a7aaf"), 91m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2021, 5, 14, 6, 44, 10, 0, DateTimeKind.Unspecified), 193m },
                    { new Guid("f20f871f-7a29-4d53-a9f8-8e2c820b03b0"), 29m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2021, 6, 16, 17, 38, 39, 0, DateTimeKind.Unspecified), 70.79m },
                    { new Guid("c9839961-250d-4466-a8d2-c15d99d3d4a6"), 18m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2021, 7, 14, 20, 38, 44, 0, DateTimeKind.Unspecified), 51.97m },
                    { new Guid("3bda594f-42ac-4bec-8776-d2b4e30c0239"), 18m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2021, 8, 17, 10, 8, 26, 0, DateTimeKind.Unspecified), 52.55m },
                    { new Guid("e84a6509-db2c-4fee-a501-469bc669ccf2"), 156m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2020, 12, 17, 16, 49, 6, 0, DateTimeKind.Unspecified), 282.76m },
                    { new Guid("12b2b2b6-716a-4e99-afe3-717e46019189"), 77m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2021, 10, 20, 17, 27, 53, 0, DateTimeKind.Unspecified), 168m },
                    { new Guid("75cade6a-c043-437e-b169-eb94bf095cec"), 180m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2020, 1, 14, 13, 50, 55, 0, DateTimeKind.Unspecified), 354m },
                    { new Guid("50f7b846-1128-41ef-898e-ac9bf1d83cd3"), 51m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2019, 11, 11, 11, 6, 50, 0, DateTimeKind.Unspecified), 138.58m },
                    { new Guid("8eef8277-2229-44cf-aed1-2fb97fa7819b"), 1m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2019, 9, 18, 17, 51, 53, 0, DateTimeKind.Unspecified), 171m },
                    { new Guid("fc45d6e8-1757-45df-b9a2-46d577d0c744"), 286m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2019, 11, 19, 9, 36, 26, 0, DateTimeKind.Unspecified), 193.56m },
                    { new Guid("a730afa3-d92f-4ccf-907a-bb289df7458e"), 405m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2020, 1, 9, 16, 37, 29, 0, DateTimeKind.Unspecified), 261.98m },
                    { new Guid("666543c3-f846-4812-903b-ba0ca62525af"), 610m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2020, 3, 17, 13, 46, 23, 0, DateTimeKind.Unspecified), 409m },
                    { new Guid("a6da7dbc-8f6d-4cd4-a77f-35d42308753f"), 411m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2020, 5, 13, 14, 22, 7, 0, DateTimeKind.Unspecified), 293.21m },
                    { new Guid("26b2170a-b7dd-40ad-b8ed-8820477ed6af"), 376m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2020, 7, 14, 11, 43, 59, 0, DateTimeKind.Unspecified), 270m },
                    { new Guid("c25e1d5e-565b-4d35-8fd1-6cc64aac5b81"), 381m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2020, 9, 9, 9, 20, 5, 0, DateTimeKind.Unspecified), 273.24m },
                    { new Guid("42a90b5a-dcc8-4721-a807-a1d9a91f5226"), 474m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2020, 11, 6, 7, 34, 13, 0, DateTimeKind.Unspecified), 332.81m },
                    { new Guid("02db7075-a2c5-41c0-94aa-768b844505bf"), 177m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2019, 12, 11, 14, 20, 24, 0, DateTimeKind.Unspecified), 348.87m },
                    { new Guid("53e43706-aac5-4275-8ac8-f5f6333db376"), 668m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2021, 1, 15, 21, 42, 42, 0, DateTimeKind.Unspecified), 490m },
                    { new Guid("35a865b6-384a-4edd-bf1a-80d8d7b14319"), 550m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2021, 5, 11, 22, 21, 8, 0, DateTimeKind.Unspecified), 410m },
                    { new Guid("ccb2afe8-e510-463f-9626-9b09d273f478"), 321m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2021, 7, 12, 19, 21, 30, 0, DateTimeKind.Unspecified), 266.71m },
                    { new Guid("e2003171-5d9e-4089-855c-3e39fb8040e1"), 356m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2021, 9, 9, 21, 29, 21, 0, DateTimeKind.Unspecified), 285m },
                    { new Guid("e0a6f37a-7539-446d-9f24-e4c1da22efcf"), 413m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2021, 11, 6, 15, 41, 24, 0, DateTimeKind.Unspecified), 321.84m },
                    { new Guid("97ba7f32-d0fa-4c1c-a616-e8e9be68ebde"), 0m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2019, 7, 12, 13, 4, 42, 0, DateTimeKind.Unspecified), 50.24m },
                    { new Guid("bbffd8b4-e8cf-4544-87f6-83da15320664"), 3m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2019, 8, 13, 13, 9, 30, 0, DateTimeKind.Unspecified), 33.93m },
                    { new Guid("b8c4a25c-61ce-4983-ae6c-ac8a3586135c"), 9m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2019, 9, 13, 15, 24, 36, 0, DateTimeKind.Unspecified), 37.25m },
                    { new Guid("82cee8ab-9417-4827-81c7-dc8abc330f5b"), 43m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2019, 10, 15, 13, 7, 25, 0, DateTimeKind.Unspecified), 99m },
                    { new Guid("d8f07521-f606-435a-86b2-abe93aa7489e"), 613m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), 0, new DateTime(2021, 3, 11, 17, 23, 40, 0, DateTimeKind.Unspecified), 452.38m }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "ConsumptionAmount", "ConsumptionTypeId", "Currency", "OccuredAt", "PaidAmount" },
                values: new object[] { new Guid("9bc4cc22-d850-4d17-b9e0-ee12eaee9bcc"), 20m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), 0, new DateTime(2021, 9, 10, 15, 55, 44, 0, DateTimeKind.Unspecified), 58.35m });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ConsumptionTypeId",
                table: "Expenses",
                column: "ConsumptionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "ConsumptionTypes");
        }
    }
}
