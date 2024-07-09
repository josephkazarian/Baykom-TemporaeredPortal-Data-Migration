using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Migration.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSkript_Info_FeldHinzugefuegt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MigrationSkript_Info",
                table: "Rktos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MigrationSkript_Info",
                table: "Organisationsbeauftragtens",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MigrationSkript_Info",
                table: "Kdnrs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MigrationSkript_Info",
                table: "Abrufberechtigtes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MigrationSkript_Info",
                table: "Rktos");

            migrationBuilder.DropColumn(
                name: "MigrationSkript_Info",
                table: "Organisationsbeauftragtens");

            migrationBuilder.DropColumn(
                name: "MigrationSkript_Info",
                table: "Kdnrs");

            migrationBuilder.DropColumn(
                name: "MigrationSkript_Info",
                table: "Abrufberechtigtes");
        }
    }
}
