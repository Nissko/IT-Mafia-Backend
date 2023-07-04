using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
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
                name: "MafiaCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ContactPhone = table.Column<string>(type: "text", nullable: false),
                    BusinessType = table.Column<string>(type: "text", nullable: false),
                    MafiaFamilyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MafiaCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MafiaCompanies_MafiaFamilies_MafiaFamilyId",
                        column: x => x.MafiaFamilyId,
                        principalTable: "MafiaFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Birthday = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    MafiaFamilyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MafiaMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MafiaMembers_MafiaFamilies_MafiaFamilyId",
                        column: x => x.MafiaFamilyId,
                        principalTable: "MafiaFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Revenue = table.Column<string>(type: "text", nullable: false),
                    Expense = table.Column<string>(type: "text", nullable: false),
                    NetIncome = table.Column<string>(type: "text", nullable: false),
                    FamilyDonate = table.Column<string>(type: "text", nullable: false),
                    MafiaCompanyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialReports_MafiaCompanies_MafiaCompanyId",
                        column: x => x.MafiaCompanyId,
                        principalTable: "MafiaCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "MafiaMembers");

            migrationBuilder.DropTable(
                name: "MafiaCompanies");

            migrationBuilder.DropTable(
                name: "MafiaFamilies");
        }
    }
}
