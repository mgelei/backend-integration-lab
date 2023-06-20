using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lottery.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Draws_CreatedAt_Index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DrawHistory_CreatedAt",
                table: "DrawHistory",
                column: "CreatedAt",
                descending: new bool[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DrawHistory_CreatedAt",
                table: "DrawHistory");
        }
    }
}
