using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data_Migration.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abrufberechtigtes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    istVerarbeitet = table.Column<bool>(type: "boolean", nullable: false),
                    UUID = table.Column<string>(type: "text", nullable: false),
                    AB_gruppe = table.Column<string>(type: "text", nullable: false),
                    adresse = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Info_AB = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abrufberechtigtes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kdnrs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    istVerarbeitet = table.Column<bool>(type: "boolean", nullable: false),
                    RV_Los = table.Column<string>(type: "text", nullable: false),
                    Kunden_Nr_AB_rel = table.Column<string>(type: "text", nullable: false),
                    UUID = table.Column<string>(type: "text", nullable: false),
                    Anrede = table.Column<string>(type: "text", nullable: false),
                    Name_des_Unternehmens = table.Column<string>(type: "text", nullable: false),
                    zusaetzlicher_Text = table.Column<string>(type: "text", nullable: false),
                    Rechtsform = table.Column<string>(type: "text", nullable: false),
                    Hausnr = table.Column<string>(type: "text", nullable: false),
                    PLZ = table.Column<string>(type: "text", nullable: false),
                    Ort = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kdnrs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organisationsbeauftragtens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    istVerarbeitet = table.Column<bool>(type: "boolean", nullable: false),
                    UUID = table.Column<string>(type: "text", nullable: false),
                    Abteilung_Zentraler_Asp = table.Column<string>(type: "text", nullable: false),
                    Anrede_Zentraler_Asp = table.Column<string>(type: "text", nullable: false),
                    Titel_Zentraler_Asp = table.Column<string>(type: "text", nullable: false),
                    Name_Zentraler_Asp = table.Column<string>(type: "text", nullable: false),
                    Email_Zentraler_Asp = table.Column<string>(type: "text", nullable: false),
                    Telefon_Zentraler_Asp = table.Column<string>(type: "text", nullable: false),
                    Mobilfunknummer = table.Column<string>(type: "text", nullable: false),
                    Funktions_postfach = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisationsbeauftragtens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rktos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    istVerarbeitet = table.Column<bool>(type: "boolean", nullable: false),
                    Kunden_NrAB_rel = table.Column<string>(type: "text", nullable: false),
                    Rechungskonto_2017 = table.Column<string>(type: "text", nullable: false),
                    Rechnungskonto_2024 = table.Column<string>(type: "text", nullable: false),
                    InfoRKTO = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rktos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abrufberechtigtes");

            migrationBuilder.DropTable(
                name: "Kdnrs");

            migrationBuilder.DropTable(
                name: "Organisationsbeauftragtens");

            migrationBuilder.DropTable(
                name: "Rktos");
        }
    }
}
