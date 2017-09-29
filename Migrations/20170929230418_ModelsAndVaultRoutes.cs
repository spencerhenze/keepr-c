using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace keepr.Migrations
{
    public partial class ModelsAndVaultRoutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VaultId",
                table: "Keeps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vaults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaults", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Keeps_VaultId",
                table: "Keeps",
                column: "VaultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keeps_Vaults_VaultId",
                table: "Keeps",
                column: "VaultId",
                principalTable: "Vaults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keeps_Vaults_VaultId",
                table: "Keeps");

            migrationBuilder.DropTable(
                name: "Vaults");

            migrationBuilder.DropIndex(
                name: "IX_Keeps_VaultId",
                table: "Keeps");

            migrationBuilder.DropColumn(
                name: "VaultId",
                table: "Keeps");
        }
    }
}
