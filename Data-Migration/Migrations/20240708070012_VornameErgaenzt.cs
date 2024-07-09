using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Migration.Migrations
{
    /// <inheritdoc />
    public partial class VornameErgaenzt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Vorname_zentraler_Asp",
                table: "Organisationsbeauftragtens",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vorname_zentraler_Asp",
                table: "Organisationsbeauftragtens");
        }
    }
}
