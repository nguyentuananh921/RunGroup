using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunGroupWebAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class updateCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "County",
                schema: "Data",
                table: "Cities",
                newName: "Country");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                schema: "Data",
                table: "Cities",
                newName: "County");
        }
    }
}
