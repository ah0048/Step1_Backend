using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Step1_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addinginterval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subscription",
                table: "Reservations",
                newName: "subscriptionPlan");

            migrationBuilder.AddColumn<int>(
                name: "subscriptionInterval",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subscriptionInterval",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "subscriptionPlan",
                table: "Reservations",
                newName: "Subscription");
        }
    }
}
