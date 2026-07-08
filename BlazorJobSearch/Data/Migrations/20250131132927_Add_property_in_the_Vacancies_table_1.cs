using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorJobSearch.Migrations
{
    /// <inheritdoc />
    public partial class Add_property_in_the_Vacancies_table_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Salary",
                table: "Vacancies",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Vacancies");
        }
    }
}
