﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinApp.Infrastructure.Migrations
{
    public partial class initialMigration : Migration
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                columns: new[] { "Id", "ConsumptionAmount", "ConsumptionTypeId", "CreatedAt", "Currency", "OccuredAt", "PaidAmount" },
                values: new object[,]
                {
                    { new Guid("e2094c53-d3f9-4962-a726-ce6807478a70"), 0m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 351, DateTimeKind.Local).AddTicks(6354), 0, new DateTime(2019, 7, 11, 22, 40, 9, 0, DateTimeKind.Unspecified), 62.87m },
                    { new Guid("4480ae0c-e574-48c6-bcdf-aef92c0d0fe1"), 171m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7678), 0, new DateTime(2020, 3, 13, 13, 55, 33, 0, DateTimeKind.Unspecified), 330m },
                    { new Guid("c488f798-78b8-4b01-bc90-dcab14c07ca7"), 120m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7715), 0, new DateTime(2020, 4, 15, 16, 35, 7, 0, DateTimeKind.Unspecified), 239.15m },
                    { new Guid("f56a8c0b-2c56-49ff-bb38-340540090031"), 43m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7732), 0, new DateTime(2020, 5, 13, 14, 19, 45, 0, DateTimeKind.Unspecified), 99.66m },
                    { new Guid("8b5f22d6-5714-4c66-8fea-90e2a088bbb0"), 26m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7762), 0, new DateTime(2020, 6, 15, 13, 13, 37, 0, DateTimeKind.Unspecified), 68m },
                    { new Guid("7d4583bb-ff0f-4e46-978d-51f2ff4e06ba"), 15m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7799), 0, new DateTime(2020, 7, 14, 16, 43, 26, 0, DateTimeKind.Unspecified), 47m },
                    { new Guid("e4a27d5d-62db-45a6-8be7-2b6350a7b4c6"), 14m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7832), 0, new DateTime(2020, 8, 14, 12, 18, 7, 0, DateTimeKind.Unspecified), 45m },
                    { new Guid("3b043286-8507-4700-98ac-b77fb3f4f84d"), 30m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7910), 0, new DateTime(2020, 9, 30, 15, 28, 29, 0, DateTimeKind.Unspecified), 77.55m },
                    { new Guid("0c0e217f-52a3-435d-8e1f-f4d274258914"), 19m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7925), 0, new DateTime(2020, 10, 21, 19, 46, 44, 0, DateTimeKind.Unspecified), 47.18m },
                    { new Guid("6b902a1f-c1af-49f5-98d3-35e26a1c3e0a"), 202m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7664), 0, new DateTime(2020, 2, 12, 15, 14, 11, 0, DateTimeKind.Unspecified), 388m },
                    { new Guid("b89d05b5-c976-494e-99ac-2d04abfeaff9"), 129m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7983), 0, new DateTime(2020, 11, 17, 15, 27, 21, 0, DateTimeKind.Unspecified), 240m },
                    { new Guid("667ce6e5-1ecd-4d86-9d7d-b2d03be781bd"), 193m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8025), 0, new DateTime(2021, 1, 18, 22, 35, 50, 0, DateTimeKind.Unspecified), 343m },
                    { new Guid("6e8f8248-093f-4bdc-ab49-28b153460132"), 231m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8044), 0, new DateTime(2021, 2, 16, 14, 13, 9, 0, DateTimeKind.Unspecified), 401.13m },
                    { new Guid("7774e1ff-1c01-4423-a954-0699eee76de5"), 176m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8111), 0, new DateTime(2021, 3, 17, 19, 36, 57, 0, DateTimeKind.Unspecified), 311m },
                    { new Guid("1bf588fa-ea43-459c-bcae-84c775ff2c86"), 140m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8124), 0, new DateTime(2021, 4, 16, 19, 9, 30, 0, DateTimeKind.Unspecified), 250m },
                    { new Guid("f2065da0-96f7-4441-9c8c-351ac2ea89ee"), 91m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8170), 0, new DateTime(2021, 5, 14, 6, 44, 10, 0, DateTimeKind.Unspecified), 193m },
                    { new Guid("572a554b-6f13-4d3d-9f0c-e458a448989b"), 29m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8183), 0, new DateTime(2021, 6, 16, 17, 38, 39, 0, DateTimeKind.Unspecified), 70.79m },
                    { new Guid("cd7fc464-cf6d-4814-8f97-0ceded261add"), 18m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8232), 0, new DateTime(2021, 7, 14, 20, 38, 44, 0, DateTimeKind.Unspecified), 51.97m },
                    { new Guid("a1ee9473-4e54-4577-8d61-a66dcd322516"), 18m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8256), 0, new DateTime(2021, 8, 17, 10, 8, 26, 0, DateTimeKind.Unspecified), 52.55m },
                    { new Guid("40135451-be5f-4f99-8dae-f89a60d2c3c8"), 156m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7996), 0, new DateTime(2020, 12, 17, 16, 49, 6, 0, DateTimeKind.Unspecified), 282.76m },
                    { new Guid("3bc5ecdf-1c7a-4b2d-b628-899750a7faa2"), 77m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8284), 0, new DateTime(2021, 10, 20, 17, 27, 53, 0, DateTimeKind.Unspecified), 168m },
                    { new Guid("42307af4-22a9-41d5-8c0d-33ae5c345b1f"), 180m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7650), 0, new DateTime(2020, 1, 14, 13, 50, 55, 0, DateTimeKind.Unspecified), 354m },
                    { new Guid("103e3f64-1b11-4e72-a792-a70169bb12b4"), 51m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7549), 0, new DateTime(2019, 11, 11, 11, 6, 50, 0, DateTimeKind.Unspecified), 138.58m },
                    { new Guid("3eb1a0a6-ec9e-46f2-855b-6496c41a2259"), 1m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7165), 0, new DateTime(2019, 9, 18, 17, 51, 53, 0, DateTimeKind.Unspecified), 171m },
                    { new Guid("36d40a9f-4617-4068-a95f-208e47088bba"), 286m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7575), 0, new DateTime(2019, 11, 19, 9, 36, 26, 0, DateTimeKind.Unspecified), 193.56m },
                    { new Guid("10e45622-a147-48e6-a1fd-5c865a09835a"), 405m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7626), 0, new DateTime(2020, 1, 9, 16, 37, 29, 0, DateTimeKind.Unspecified), 261.98m },
                    { new Guid("a0d0164e-3fb9-47e0-b6fe-db38ca60d36f"), 610m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7701), 0, new DateTime(2020, 3, 17, 13, 46, 23, 0, DateTimeKind.Unspecified), 409m },
                    { new Guid("be002e7d-6c59-435a-930f-f571a10fc031"), 411m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7746), 0, new DateTime(2020, 5, 13, 14, 22, 7, 0, DateTimeKind.Unspecified), 293.21m },
                    { new Guid("cd87bfd4-052f-4a99-9a9d-e820dc088ed2"), 376m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7775), 0, new DateTime(2020, 7, 14, 11, 43, 59, 0, DateTimeKind.Unspecified), 270m },
                    { new Guid("f817a815-c10a-4326-8306-5ec011f6d17a"), 381m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7873), 0, new DateTime(2020, 9, 9, 9, 20, 5, 0, DateTimeKind.Unspecified), 273.24m },
                    { new Guid("cfeaeb6c-f9e2-4cb5-a172-649553ec02c8"), 474m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7961), 0, new DateTime(2020, 11, 6, 7, 34, 13, 0, DateTimeKind.Unspecified), 332.81m },
                    { new Guid("1789555f-d37d-421c-923c-e15c2797810b"), 177m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7592), 0, new DateTime(2019, 12, 11, 14, 20, 24, 0, DateTimeKind.Unspecified), 348.87m },
                    { new Guid("1c01016f-45c6-4dc0-b347-7b54b847fb29"), 668m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8011), 0, new DateTime(2021, 1, 15, 21, 42, 42, 0, DateTimeKind.Unspecified), 490m },
                    { new Guid("2d5e7915-e9af-4090-b651-04030c4344f0"), 550m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8143), 0, new DateTime(2021, 5, 11, 22, 21, 8, 0, DateTimeKind.Unspecified), 410m },
                    { new Guid("257d973f-1d85-4237-90c9-6a4c33a585c4"), 321m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8203), 0, new DateTime(2021, 7, 12, 19, 21, 30, 0, DateTimeKind.Unspecified), 266.71m },
                    { new Guid("30fe4931-8c35-4aff-a877-811152b22b90"), 356m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8271), 0, new DateTime(2021, 9, 9, 21, 29, 21, 0, DateTimeKind.Unspecified), 285m },
                    { new Guid("4ca2b533-c097-42d2-afbf-babcabd4aa52"), 413m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8300), 0, new DateTime(2021, 11, 6, 15, 41, 24, 0, DateTimeKind.Unspecified), 321.84m },
                    { new Guid("9237c772-b038-44bb-8639-3ebd28b67acd"), 0m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(4816), 0, new DateTime(2019, 7, 12, 13, 4, 42, 0, DateTimeKind.Unspecified), 50.24m },
                    { new Guid("a6d7caa6-7a60-498c-9bfb-860fa72dcef7"), 3m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7040), 0, new DateTime(2019, 8, 13, 13, 9, 30, 0, DateTimeKind.Unspecified), 33.93m },
                    { new Guid("c9b3c49d-35d0-4783-9d6c-365c6cfadf63"), 9m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7142), 0, new DateTime(2019, 9, 13, 15, 24, 36, 0, DateTimeKind.Unspecified), 37.25m },
                    { new Guid("91f744dd-8842-4789-97b1-31a1b9480565"), 43m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(7477), 0, new DateTime(2019, 10, 15, 13, 7, 25, 0, DateTimeKind.Unspecified), 99m },
                    { new Guid("1eb36a4c-5ab3-4549-a0ed-c199937e0f2b"), 613m, new Guid("251fb0f9-1632-485b-9a10-22e901253c73"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8075), 0, new DateTime(2021, 3, 11, 17, 23, 40, 0, DateTimeKind.Unspecified), 452.38m }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "ConsumptionAmount", "ConsumptionTypeId", "CreatedAt", "Currency", "OccuredAt", "PaidAmount" },
                values: new object[] { new Guid("50e87df6-dc86-4562-8289-398d4bc5aa1a"), 20m, new Guid("f6eb3f75-7afb-4577-bf62-5ea66e69acd8"), new DateTime(2021, 11, 16, 22, 57, 40, 374, DateTimeKind.Local).AddTicks(8331), 0, new DateTime(2021, 9, 10, 15, 55, 44, 0, DateTimeKind.Unspecified), 58.35m });

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
