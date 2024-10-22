using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Cars_CarId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Slots_SlotId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_CustomerId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_DaySchedule_WeekSchedules_WeekScheduleId",
                table: "DaySchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Slots_Users_MasterId",
                table: "Slots");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Services_ServiceId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "WeekSchedules");

            migrationBuilder.DropIndex(
                name: "IX_DaySchedule_WeekScheduleId",
                table: "DaySchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ServiceId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slots",
                table: "Slots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "WeekScheduleId",
                table: "DaySchedule");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Slots",
                newName: "Slot");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Car");

            migrationBuilder.RenameIndex(
                name: "IX_Slots_MasterId",
                table: "Slot",
                newName: "IX_Slot_MasterId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CustomerId",
                table: "Car",
                newName: "IX_Car_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slot",
                table: "Slot",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Service_MasterId",
                table: "Service",
                column: "MasterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Car_CarId",
                table: "Appointments",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Service_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Slot_SlotId",
                table: "Appointments",
                column: "SlotId",
                principalTable: "Slot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_User_CustomerId",
                table: "Car",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_User_MasterId",
                table: "Service",
                column: "MasterId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slot_User_MasterId",
                table: "Slot",
                column: "MasterId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Car_CarId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Service_ServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Slot_SlotId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_User_CustomerId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_User_MasterId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Slot_User_MasterId",
                table: "Slot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slot",
                table: "Slot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_MasterId",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Slot",
                newName: "Slots");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Cars");

            migrationBuilder.RenameIndex(
                name: "IX_Slot_MasterId",
                table: "Slots",
                newName: "IX_Slots_MasterId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_CustomerId",
                table: "Cars",
                newName: "IX_Cars_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "WeekScheduleId",
                table: "DaySchedule",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slots",
                table: "Slots",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "WeekSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekSchedules", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaySchedule_WeekScheduleId",
                table: "DaySchedule",
                column: "WeekScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ServiceId",
                table: "Users",
                column: "ServiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Cars_CarId",
                table: "Appointments",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Slots_SlotId",
                table: "Appointments",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_CustomerId",
                table: "Cars",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DaySchedule_WeekSchedules_WeekScheduleId",
                table: "DaySchedule",
                column: "WeekScheduleId",
                principalTable: "WeekSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slots_Users_MasterId",
                table: "Slots",
                column: "MasterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Services_ServiceId",
                table: "Users",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }
    }
}
