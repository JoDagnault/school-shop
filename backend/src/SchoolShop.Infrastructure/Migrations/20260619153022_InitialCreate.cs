using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolShop.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "SupplyLists",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                SchoolName = table.Column<string>(type: "text", nullable: false),
                Grade = table.Column<string>(type: "text", nullable: false),
                AcademicYearStart = table.Column<uint>(type: "bigint", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SupplyLists", supplyList => supplyList.Id);
            });

        migrationBuilder.CreateTable(
            name: "SupplyListItemEntity",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                SupplyListId = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                Quantity = table.Column<uint>(type: "bigint", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SupplyListItemEntity", item => item.Id);
                table.ForeignKey(
                    name: "FK_SupplyListItemEntity_SupplyLists_SupplyListId",
                    column: item => item.SupplyListId,
                    principalTable: "SupplyLists",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_SupplyListItemEntity_SupplyListId",
            table: "SupplyListItemEntity",
            column: "SupplyListId");

        migrationBuilder.CreateIndex(
            name: "IX_SupplyLists_SchoolName_Grade_AcademicYearStart",
            table: "SupplyLists",
            columns: ["SchoolName", "Grade", "AcademicYearStart"],
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "SupplyListItemEntity");

        migrationBuilder.DropTable(
            name: "SupplyLists");
    }
}
