using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Backend5.Migrations
{
    public partial class addAnaalysis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analyses",
                columns: table => new
                {
                    AnalysisId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyses", x => new { x.AnalysisId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_Analyses_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalysisLabs",
                columns: table => new
                {
                    AnalysisId = table.Column<int>(nullable: false),
                    LabId = table.Column<int>(nullable: false),
                    AnalysisId1 = table.Column<int>(nullable: true),
                    AnalysisPatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisLabs", x => new { x.AnalysisId, x.LabId });
                    table.ForeignKey(
                        name: "FK_AnalysisLabs_Labs_LabId",
                        column: x => x.LabId,
                        principalTable: "Labs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalysisLabs_Analyses_AnalysisId1_AnalysisPatientId",
                        columns: x => new { x.AnalysisId1, x.AnalysisPatientId },
                        principalTable: "Analyses",
                        principalColumns: new[] { "AnalysisId", "PatientId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_PatientId",
                table: "Analyses",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisLabs_LabId",
                table: "AnalysisLabs",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisLabs_AnalysisId1_AnalysisPatientId",
                table: "AnalysisLabs",
                columns: new[] { "AnalysisId1", "AnalysisPatientId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysisLabs");

            migrationBuilder.DropTable(
                name: "Analyses");
        }
    }
}
