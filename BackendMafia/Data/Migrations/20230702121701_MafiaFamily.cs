using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackendMafia.Data.Migrations
{
    /// <inheritdoc />
    public partial class MafiaFamily : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MafiaFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MafiaFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MafiaMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Phone = table.Column<int>(type: "integer", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    MafiaFamiliesId = table.Column<int>(type: "integer", nullable: false),
                    MafiaFamilyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MafiaMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MafiaMembers_MafiaFamilies_MafiaFamilyId",
                        column: x => x.MafiaFamilyId,
                        principalTable: "MafiaFamilies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MafiaCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ContactPhone = table.Column<string>(type: "text", nullable: false),
                    BusinessType = table.Column<string>(type: "text", nullable: false),
                    MafiaFamiliesId = table.Column<int>(type: "integer", nullable: false),
                    MafiaMembersId = table.Column<int>(type: "integer", nullable: false),
                    MafiaFamilyId = table.Column<int>(type: "integer", nullable: true),
                    MafiaMemberId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MafiaCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MafiaCompanies_MafiaFamilies_MafiaFamilyId",
                        column: x => x.MafiaFamilyId,
                        principalTable: "MafiaFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MafiaCompanies_MafiaMembers_MafiaMemberId",
                        column: x => x.MafiaMemberId,
                        principalTable: "MafiaMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FinancialReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Revenue = table.Column<int>(type: "integer", nullable: false),
                    Expense = table.Column<int>(type: "integer", nullable: false),
                    NetIncome = table.Column<int>(type: "integer", nullable: false),
                    FamilyDonate = table.Column<int>(type: "integer", nullable: false),
                    CompaniesId = table.Column<int>(type: "integer", nullable: false),
                    MafiaCompanyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialReports_MafiaCompanies_MafiaCompanyId",
                        column: x => x.MafiaCompanyId,
                        principalTable: "MafiaCompanies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialReports_MafiaCompanyId",
                table: "FinancialReports",
                column: "MafiaCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MafiaCompanies_MafiaFamilyId",
                table: "MafiaCompanies",
                column: "MafiaFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_MafiaCompanies_MafiaMemberId",
                table: "MafiaCompanies",
                column: "MafiaMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MafiaMembers_MafiaFamilyId",
                table: "MafiaMembers",
                column: "MafiaFamilyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialReports");

            migrationBuilder.DropTable(
                name: "MafiaCompanies");

            migrationBuilder.DropTable(
                name: "MafiaMembers");

            migrationBuilder.DropTable(
                name: "MafiaFamilies");
        }
    }
}
