using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentHouse.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ChefId = table.Column<Guid>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    MaxAmountOfGuests = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_Students_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealGuestEntity",
                columns: table => new
                {
                    MealId = table.Column<Guid>(nullable: false),
                    GuestId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealGuestEntity", x => new { x.MealId, x.GuestId });
                    table.ForeignKey(
                        name: "FK_MealGuestEntity_Students_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealGuestEntity_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "EMail", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("6f1e369b-29ce-4d43-b027-3756f03899a1"), new DateTimeOffset(new DateTime(2018, 12, 12, 10, 44, 37, 710, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Abbey@gmail.com", "Abbey", "0612345678" },
                    { new Guid("8f6dcad1-c920-411c-9d00-c6b3a841cd88"), new DateTimeOffset(new DateTime(2018, 12, 12, 10, 44, 37, 711, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Dolly@gmail.com", "Dolly", "0613354975" },
                    { new Guid("635158c3-e28e-46fd-808e-c18b1722392c"), new DateTimeOffset(new DateTime(2018, 12, 12, 10, 44, 37, 711, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Twila@gmail.com", "Twila", "0632164994" },
                    { new Guid("9902719d-959c-4f28-b3f9-c5c8217df377"), new DateTimeOffset(new DateTime(2018, 12, 12, 10, 44, 37, 711, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Ahmad@gmail.com", "Ahmad", "0634986134" }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "ChefId", "CreatedAt", "DateTime", "Description", "MaxAmountOfGuests", "Name", "Price" },
                values: new object[] { new Guid("e59e07df-cf1c-412c-b7b3-e216ecf1facf"), new Guid("6f1e369b-29ce-4d43-b027-3756f03899a1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2018, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delicious pasta from Italy!", 5, "Macaroni", 3.0 });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "ChefId", "CreatedAt", "DateTime", "Description", "MaxAmountOfGuests", "Name", "Price" },
                values: new object[] { new Guid("b6296516-9b2a-4f17-bc15-5e70d397051a"), new Guid("8f6dcad1-c920-411c-9d00-c6b3a841cd88"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2018, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic schnitzel from Germany", 5, "Schnitzel", 4.5 });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "ChefId", "CreatedAt", "DateTime", "Description", "MaxAmountOfGuests", "Name", "Price" },
                values: new object[] { new Guid("58067c81-ac5e-40b5-afbf-f73bc2d333e5"), new Guid("8f6dcad1-c920-411c-9d00-c6b3a841cd88"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2018, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Japanese dish with raw fish", 3, "Sushi", 5.0 });

            migrationBuilder.InsertData(
                table: "MealGuestEntity",
                columns: new[] { "MealId", "GuestId" },
                values: new object[,]
                {
                    { new Guid("e59e07df-cf1c-412c-b7b3-e216ecf1facf"), new Guid("8f6dcad1-c920-411c-9d00-c6b3a841cd88") },
                    { new Guid("e59e07df-cf1c-412c-b7b3-e216ecf1facf"), new Guid("635158c3-e28e-46fd-808e-c18b1722392c") },
                    { new Guid("b6296516-9b2a-4f17-bc15-5e70d397051a"), new Guid("9902719d-959c-4f28-b3f9-c5c8217df377") },
                    { new Guid("b6296516-9b2a-4f17-bc15-5e70d397051a"), new Guid("635158c3-e28e-46fd-808e-c18b1722392c") },
                    { new Guid("58067c81-ac5e-40b5-afbf-f73bc2d333e5"), new Guid("9902719d-959c-4f28-b3f9-c5c8217df377") },
                    { new Guid("58067c81-ac5e-40b5-afbf-f73bc2d333e5"), new Guid("6f1e369b-29ce-4d43-b027-3756f03899a1") },
                    { new Guid("58067c81-ac5e-40b5-afbf-f73bc2d333e5"), new Guid("635158c3-e28e-46fd-808e-c18b1722392c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealGuestEntity_GuestId",
                table: "MealGuestEntity",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_ChefId",
                table: "Meals",
                column: "ChefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealGuestEntity");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
