using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Memberships_MemberId",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_MemberId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MemberId_PlanId",
                table: "Memberships",
                columns: new[] { "MemberId", "PlanId" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MemberId_SessionId",
                table: "Bookings",
                columns: new[] { "MemberId", "SessionId" },
                unique: true,
                filter: "[IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Memberships_MemberId_PlanId",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_MemberId_SessionId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MemberId",
                table: "Memberships",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MemberId",
                table: "Bookings",
                column: "MemberId");
        }
    }
}
