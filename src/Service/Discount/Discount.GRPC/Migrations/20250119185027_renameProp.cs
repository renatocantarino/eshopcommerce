using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Discount.GRPC.Migrations
{
    /// <inheritdoc />
    public partial class renameProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ammount",
                table: "Coupons",
                newName: "Amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Coupons",
                newName: "ammount");
        }
    }
}
