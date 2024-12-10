using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTeam.Migrations
{
    /// <inheritdoc />
    public partial class migracijanova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "privatnitrenerid",
                table: "VideoTrening",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "privatnitrenerid",
                table: "Termin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "produktid",
                table: "PlanIshrane",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VideoTrening_privatnitrenerid",
                table: "VideoTrening",
                column: "privatnitrenerid");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_privatnitrenerid",
                table: "Termin",
                column: "privatnitrenerid");

            migrationBuilder.CreateIndex(
                name: "IX_PlanIshrane_produktid",
                table: "PlanIshrane",
                column: "produktid");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanIshrane_Produkt_produktid",
                table: "PlanIshrane",
                column: "produktid",
                principalTable: "Produkt",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_PrivatniTrener_privatnitrenerid",
                table: "Termin",
                column: "privatnitrenerid",
                principalTable: "PrivatniTrener",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoTrening_PrivatniTrener_privatnitrenerid",
                table: "VideoTrening",
                column: "privatnitrenerid",
                principalTable: "PrivatniTrener",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanIshrane_Produkt_produktid",
                table: "PlanIshrane");

            migrationBuilder.DropForeignKey(
                name: "FK_Termin_PrivatniTrener_privatnitrenerid",
                table: "Termin");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoTrening_PrivatniTrener_privatnitrenerid",
                table: "VideoTrening");

            migrationBuilder.DropIndex(
                name: "IX_VideoTrening_privatnitrenerid",
                table: "VideoTrening");

            migrationBuilder.DropIndex(
                name: "IX_Termin_privatnitrenerid",
                table: "Termin");

            migrationBuilder.DropIndex(
                name: "IX_PlanIshrane_produktid",
                table: "PlanIshrane");

            migrationBuilder.DropColumn(
                name: "privatnitrenerid",
                table: "VideoTrening");

            migrationBuilder.DropColumn(
                name: "privatnitrenerid",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "produktid",
                table: "PlanIshrane");
        }
    }
}
