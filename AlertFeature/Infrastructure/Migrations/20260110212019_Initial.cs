using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlertCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVisibleToNormalUsers = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdminUser = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "AlertInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlertEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlertCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertInfo_AlertCategory_AlertCategoryId",
                        column: x => x.AlertCategoryId,
                        principalTable: "AlertCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlertId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceInfo_AlertInfo_AlertId",
                        column: x => x.AlertId,
                        principalTable: "AlertInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReleaseInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlertId = table.Column<int>(type: "int", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseInfo_AlertInfo_AlertId",
                        column: x => x.AlertId,
                        principalTable: "AlertInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAlertHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastSeenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlertId = table.Column<int>(type: "int", nullable: false),
                    UsersEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAlertHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAlertHistory_AlertInfo_AlertId",
                        column: x => x.AlertId,
                        principalTable: "AlertInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAlertHistory_Users_UsersEmail",
                        column: x => x.UsersEmail,
                        principalTable: "Users",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertInfo_AlertCategoryId",
                table: "AlertInfo",
                column: "AlertCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceInfo_AlertId",
                table: "MaintenanceInfo",
                column: "AlertId",
                unique: true,
                filter: "[AlertId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseInfo_AlertId",
                table: "ReleaseInfo",
                column: "AlertId",
                unique: true,
                filter: "[AlertId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserAlertHistory_AlertId",
                table: "UserAlertHistory",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAlertHistory_UsersEmail",
                table: "UserAlertHistory",
                column: "UsersEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceInfo");

            migrationBuilder.DropTable(
                name: "ReleaseInfo");

            migrationBuilder.DropTable(
                name: "UserAlertHistory");

            migrationBuilder.DropTable(
                name: "AlertInfo");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AlertCategory");
        }
    }
}
