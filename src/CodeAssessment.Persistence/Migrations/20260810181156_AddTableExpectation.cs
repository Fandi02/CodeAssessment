using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAssessment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableExpectation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Plannings_RequestCode",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "RequestCode",
                table: "Plannings");

            migrationBuilder.AddColumn<string>(
                name: "Slot",
                table: "Plannings",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Expectations",
                columns: table => new
                {
                    PlanningId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpectationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Slot = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAtServer = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedAtServer = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expectations", x => x.PlanningId);
                    table.ForeignKey(
                        name: "FK_Expectations_Plannings_PlanningId",
                        column: x => x.PlanningId,
                        principalTable: "Plannings",
                        principalColumn: "PlanningId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expectations_PlanningId",
                table: "Expectations",
                column: "PlanningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expectations");

            migrationBuilder.DropColumn(
                name: "Slot",
                table: "Plannings");

            migrationBuilder.AddColumn<int>(
                name: "RequestCode",
                table: "Plannings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_RequestCode",
                table: "Plannings",
                column: "RequestCode",
                unique: true);
        }
    }
}
