using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAssessment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTipeDataRequestCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Expectations_PlanningId",
                table: "Expectations");

            migrationBuilder.AddColumn<Guid>(
                name: "RequestCode",
                table: "Plannings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_RequestCode",
                table: "Plannings",
                column: "RequestCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Plannings_RequestCode",
                table: "Plannings");

            migrationBuilder.DropColumn(
                name: "RequestCode",
                table: "Plannings");

            migrationBuilder.CreateIndex(
                name: "IX_Expectations_PlanningId",
                table: "Expectations",
                column: "PlanningId");
        }
    }
}
