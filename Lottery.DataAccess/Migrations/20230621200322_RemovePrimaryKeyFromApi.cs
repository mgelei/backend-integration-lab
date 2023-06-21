using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lottery.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemovePrimaryKeyFromApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PublicId",
                table: "DrawHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DrawHistory_PublicId",
                table: "DrawHistory",
                column: "PublicId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DrawHistory_PublicId",
                table: "DrawHistory");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "DrawHistory");
        }
    }
}
