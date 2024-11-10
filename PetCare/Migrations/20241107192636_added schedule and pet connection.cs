using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCare.Migrations
{
    /// <inheritdoc />
    public partial class addedscheduleandpetconnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Schedules_PetId",
                table: "Schedules",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Pets_PetId",
                table: "Schedules",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Pets_PetId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_PetId",
                table: "Schedules");
        }
    }
}
