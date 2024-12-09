using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IndexMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Slot_MasterId",
                table: "Slot");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_Availability_EndTime",
                table: "Slot",
                columns: new[] { "Availability", "EndTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Slot_MasterId_EndTime",
                table: "Slot",
                columns: new[] { "MasterId", "EndTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceType",
                table: "Service",
                column: "ServiceType");

            migrationBuilder.CreateIndex(
                name: "IX_DaySchedule_DayOfWeek",
                table: "DaySchedule",
                column: "DayOfWeek");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Id_Status",
                table: "Appointments",
                columns: new[] { "Id", "Status" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Slot_Availability_EndTime",
                table: "Slot");

            migrationBuilder.DropIndex(
                name: "IX_Slot_MasterId_EndTime",
                table: "Slot");

            migrationBuilder.DropIndex(
                name: "IX_Service_ServiceType",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_DaySchedule_DayOfWeek",
                table: "DaySchedule");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_Id_Status",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_MasterId",
                table: "Slot",
                column: "MasterId");
        }
    }
}
