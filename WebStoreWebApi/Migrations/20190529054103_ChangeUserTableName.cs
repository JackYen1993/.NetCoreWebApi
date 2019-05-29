using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStoreWebApi.Migrations
{
    public partial class ChangeUserTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_Users_UserId",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPaymentMethods_Users_UserId",
                table: "UserPaymentMethods");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserPaymentMethods_UserId",
                table: "UserPaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreUserId",
                table: "UserPaymentMethods",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreUserId",
                table: "UserAddresses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StoreUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    LoginId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cellphone = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentMethods_StoreUserId",
                table: "UserPaymentMethods",
                column: "StoreUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_StoreUserId",
                table: "UserAddresses",
                column: "StoreUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_StoreUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "StoreUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_StoreUsers_StoreUserId",
                table: "UserAddresses",
                column: "StoreUserId",
                principalTable: "StoreUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPaymentMethods_StoreUsers_StoreUserId",
                table: "UserPaymentMethods",
                column: "StoreUserId",
                principalTable: "StoreUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_StoreUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_StoreUsers_StoreUserId",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPaymentMethods_StoreUsers_StoreUserId",
                table: "UserPaymentMethods");

            migrationBuilder.DropTable(
                name: "StoreUsers");

            migrationBuilder.DropIndex(
                name: "IX_UserPaymentMethods_StoreUserId",
                table: "UserPaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_UserAddresses_StoreUserId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "StoreUserId",
                table: "UserPaymentMethods");

            migrationBuilder.DropColumn(
                name: "StoreUserId",
                table: "UserAddresses");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cellphone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LoginId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentMethods_UserId",
                table: "UserPaymentMethods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_Users_UserId",
                table: "UserAddresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPaymentMethods_Users_UserId",
                table: "UserPaymentMethods",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
