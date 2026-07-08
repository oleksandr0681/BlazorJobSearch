using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorJobSearch.Migrations
{
    /// <inheritdoc />
    public partial class Add_properties_in_the_JobCandidates_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "JobCandidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "JobCandidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Job",
                table: "JobCandidates");

            migrationBuilder.DropColumn(
                name: "Sector",
                table: "JobCandidates");
        }
    }
}
