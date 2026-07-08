using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorJobSearch.Migrations
{
    /// <inheritdoc />
    public partial class Add_properties_in_the_Messages_table_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "To",
                table: "Messages",
                newName: "ToId");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Messages",
                newName: "FromId");

            migrationBuilder.AddColumn<int>(
                name: "EmployerId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobCandidateId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_EmployerId",
                table: "Messages",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_JobCandidateId",
                table: "Messages",
                column: "JobCandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Employers_EmployerId",
                table: "Messages",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_JobCandidates_JobCandidateId",
                table: "Messages",
                column: "JobCandidateId",
                principalTable: "JobCandidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Employers_EmployerId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_JobCandidates_JobCandidateId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_EmployerId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_JobCandidateId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "EmployerId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "JobCandidateId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ToId",
                table: "Messages",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "FromId",
                table: "Messages",
                newName: "From");
        }
    }
}
