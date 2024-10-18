using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaySchedule_WeekSchedules_Id",
                table: "DaySchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_DaySchedule_WeekSchedules_WeekScheduleId",
                table: "DaySchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_DaySchedule_WeekSchedules_WeekScheduleId1",
                table: "DaySchedule");

            migrationBuilder.DropIndex(
                name: "IX_DaySchedule_WeekScheduleId1",
                table: "DaySchedule");

            migrationBuilder.DropColumn(
                name: "WeekScheduleId1",
                table: "DaySchedule");

            migrationBuilder.AlterColumn<int>(
                name: "WeekScheduleId",
                table: "DaySchedule",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DaySchedule",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_DaySchedule_WeekSchedules_WeekScheduleId",
                table: "DaySchedule",
                column: "WeekScheduleId",
                principalTable: "WeekSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaySchedule_WeekSchedules_WeekScheduleId",
                table: "DaySchedule");

            migrationBuilder.AlterColumn<int>(
                name: "WeekScheduleId",
                table: "DaySchedule",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DaySchedule",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "WeekScheduleId1",
                table: "DaySchedule",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DaySchedule_WeekScheduleId1",
                table: "DaySchedule",
                column: "WeekScheduleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DaySchedule_WeekSchedules_Id",
                table: "DaySchedule",
                column: "Id",
                principalTable: "WeekSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DaySchedule_WeekSchedules_WeekScheduleId",
                table: "DaySchedule",
                column: "WeekScheduleId",
                principalTable: "WeekSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DaySchedule_WeekSchedules_WeekScheduleId1",
                table: "DaySchedule",
                column: "WeekScheduleId1",
                principalTable: "WeekSchedules",
                principalColumn: "Id");
        }
    }
}
