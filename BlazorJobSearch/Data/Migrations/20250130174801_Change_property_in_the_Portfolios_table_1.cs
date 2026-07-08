using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorJobSearch.Migrations
{
    /// <inheritdoc />
    public partial class Change_property_in_the_Portfolios_table_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Portfolios_JobCandidateId",
                table: "Portfolios");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_JobCandidateId",
                table: "Portfolios",
                column: "JobCandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Portfolios_JobCandidateId",
                table: "Portfolios");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_JobCandidateId",
                table: "Portfolios",
                column: "JobCandidateId",
                unique: true);
        }
    }
}
