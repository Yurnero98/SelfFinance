using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfFinance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TransactionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "FinancialOperations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTypes_UserId",
                table: "TransactionTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialOperations_UserId",
                table: "FinancialOperations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialOperations_User_UserId",
                table: "FinancialOperations",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionTypes_User_UserId",
                table: "TransactionTypes",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialOperations_User_UserId",
                table: "FinancialOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionTypes_User_UserId",
                table: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_TransactionTypes_UserId",
                table: "TransactionTypes");

            migrationBuilder.DropIndex(
                name: "IX_FinancialOperations_UserId",
                table: "FinancialOperations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FinancialOperations");
        }
    }
}
