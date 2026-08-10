using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAssessment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePlanning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plannings",
                columns: table => new
                {
                    PlanningId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestCode = table.Column<int>(type: "integer", nullable: false),
                    CandidateToken = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAtServer = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedAtServer = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plannings", x => x.PlanningId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_RequestCode",
                table: "Plannings",
                column: "RequestCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plannings");
        }
    }
}
