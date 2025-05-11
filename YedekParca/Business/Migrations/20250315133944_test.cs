using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace YedekParca.WebAPI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelTanimlari",
                columns: table => new
                {
                    ModelID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelName = table.Column<string>(type: "text", nullable: true),
                    MotorName = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTanimlari", x => x.ModelID);
                });

            migrationBuilder.CreateTable(
                name: "YedekParcalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaterialCode = table.Column<string>(type: "text", nullable: true),
                    MaterialName = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YedekParcalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StokDetaylar",
                columns: table => new
                {
                    StokID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StokMRK = table.Column<int>(type: "integer", nullable: false),
                    StokIzm = table.Column<int>(type: "integer", nullable: false),
                    StokAnk = table.Column<int>(type: "integer", nullable: false),
                    StokAdn = table.Column<int>(type: "integer", nullable: false),
                    StokErz = table.Column<int>(type: "integer", nullable: false),
                    ModelID = table.Column<int>(type: "integer", nullable: false),
                    YedekParcasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokDetaylar", x => x.StokID);
                    table.ForeignKey(
                        name: "FK_StokDetaylar_YedekParcalar_YedekParcasId",
                        column: x => x.YedekParcasId,
                        principalTable: "YedekParcalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YedekParcaModel",
                columns: table => new
                {
                    YedekParcasId = table.Column<int>(type: "integer", nullable: false),
                    ModelID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YedekParcaModel", x => new { x.YedekParcasId, x.ModelID });
                    table.ForeignKey(
                        name: "FK_YedekParcaModel_ModelTanimlari_ModelID",
                        column: x => x.ModelID,
                        principalTable: "ModelTanimlari",
                        principalColumn: "ModelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YedekParcaModel_YedekParcalar_YedekParcasId",
                        column: x => x.YedekParcasId,
                        principalTable: "YedekParcalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ModelTanimlari",
                columns: new[] { "ModelID", "ModelName", "MotorName", "Year" },
                values: new object[,]
                {
                    { 1, "JUMPER-3", "2.2 HDI", "06-" },
                    { 2, "207/308/C4/MINI", "1.6 EP6", "07-" },
                    { 3, "407/607", "BM", "97-" },
                    { 4, "BOXER-3", "2.2 HDI", "06-" }
                });

            migrationBuilder.InsertData(
                table: "YedekParcalar",
                columns: new[] { "Id", "MaterialCode", "MaterialName", "Price" },
                values: new object[,]
                {
                    { 1, "0249.E9", "ÜST KAPAK CONTA", 1114.78f },
                    { 2, "0249.F4", "KÜLBÜTÖR KAPAK CONTASI", 837.47f }
                });

            migrationBuilder.InsertData(
                table: "StokDetaylar",
                columns: new[] { "StokID", "ModelID", "StokAdn", "StokAnk", "StokErz", "StokIzm", "StokMRK", "YedekParcasId" },
                values: new object[,]
                {
                    { 1, 1, 8, 1, 1, 1, 0, 1 },
                    { 2, 2, 13, 1, 11, 0, 18, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StokDetaylar_YedekParcasId",
                table: "StokDetaylar",
                column: "YedekParcasId");

            migrationBuilder.CreateIndex(
                name: "IX_YedekParcaModel_ModelID",
                table: "YedekParcaModel",
                column: "ModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StokDetaylar");

            migrationBuilder.DropTable(
                name: "YedekParcaModel");

            migrationBuilder.DropTable(
                name: "ModelTanimlari");

            migrationBuilder.DropTable(
                name: "YedekParcalar");
        }
    }
}
