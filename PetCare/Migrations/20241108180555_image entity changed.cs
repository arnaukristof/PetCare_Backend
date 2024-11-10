using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCare.Migrations
{
    /// <inheritdoc />
    public partial class imageentitychanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageTitle",
                table: "Images",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ImageData",
                table: "Images",
                newName: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Images",
                newName: "ImageTitle");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Images",
                newName: "ImageData");
        }
    }
}
