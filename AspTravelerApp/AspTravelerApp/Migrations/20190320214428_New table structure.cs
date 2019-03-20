using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspTravelerApp.Migrations
{
    public partial class Newtablestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TripID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ReservationID = table.Column<string>(nullable: true),
                    ReservationLocation = table.Column<string>(nullable: true),
                    DepartureAddress = table.Column<string>(nullable: true),
                    ArrivalAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Segments_Trips_TripID",
                        column: x => x.TripID,
                        principalTable: "Trips",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Segments_TripID",
                table: "Segments",
                column: "TripID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
