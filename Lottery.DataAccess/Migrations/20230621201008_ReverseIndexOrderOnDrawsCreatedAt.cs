using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lottery.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReverseIndexOrderOnDrawsCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DrawHistory_CreatedAt",
                table: "DrawHistory");

            migrationBuilder.CreateIndex(
                name: "IX_DrawHistory_CreatedAt",
                table: "DrawHistory",
                column: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DrawHistory_CreatedAt",
                table: "DrawHistory");

            migrationBuilder.CreateIndex(
                name: "IX_DrawHistory_CreatedAt",
                table: "DrawHistory",
                column: "CreatedAt",
                descending: new bool[0]);
        }
    }
}
