using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PegassusBooking.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class appDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "Duration",
                table: "Appointments",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
