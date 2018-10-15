using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalonAplikacija.Data.Migrations
{
    public partial class SalonRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Saloons_SaloonId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Saloons_SaloonId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Saloons");

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    SaloonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 150, nullable: false),
                    Phone = table.Column<string>(maxLength: 150, nullable: false),
                    Mobile = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    Website = table.Column<string>(maxLength: 50, nullable: true),
                    OpeningTime = table.Column<DateTime>(nullable: false),
                    ClosingTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.SaloonId);
                    table.ForeignKey(
                        name: "FK_Salons_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salons_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salons_CityId",
                table: "Salons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Salons_CountryId",
                table: "Salons",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Salons_SaloonId",
                table: "Appointments",
                column: "SaloonId",
                principalTable: "Salons",
                principalColumn: "SaloonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Salons_SaloonId",
                table: "Services",
                column: "SaloonId",
                principalTable: "Salons",
                principalColumn: "SaloonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Salons_SaloonId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Salons_SaloonId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Salons");

            migrationBuilder.CreateTable(
                name: "Saloons",
                columns: table => new
                {
                    SaloonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 150, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    ClosingTime = table.Column<DateTime>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Mobile = table.Column<string>(maxLength: 150, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OpeningTime = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(maxLength: 150, nullable: false),
                    Website = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saloons", x => x.SaloonId);
                    table.ForeignKey(
                        name: "FK_Saloons_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Saloons_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Saloons_CityId",
                table: "Saloons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Saloons_CountryId",
                table: "Saloons",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Saloons_SaloonId",
                table: "Appointments",
                column: "SaloonId",
                principalTable: "Saloons",
                principalColumn: "SaloonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Saloons_SaloonId",
                table: "Services",
                column: "SaloonId",
                principalTable: "Saloons",
                principalColumn: "SaloonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
