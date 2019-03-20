using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspTravelerApp.Migrations
{
    public partial class AddingSegments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TripId = table.Column<int>(nullable: true),
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
                        name: "FK_Segments_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Segments_TripId",
                table: "Segments",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Segments");
        }
    }
}
