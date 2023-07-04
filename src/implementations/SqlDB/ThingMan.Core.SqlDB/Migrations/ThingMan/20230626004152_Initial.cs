#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace ThingMan.Core.SqlDB.Migrations.ThingMan;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "PropertyDef",
            table => new
            {
                Id = table.Column<Guid>("TEXT", nullable: false),
                Name = table.Column<string>("TEXT", nullable: false),
                Type = table.Column<string>("TEXT", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_PropertyDef", x => x.Id); });

        migrationBuilder.CreateTable(
            "ThingDef",
            table => new
            {
                Id = table.Column<string>("TEXT", nullable: false),
                Name = table.Column<string>("TEXT", nullable: false),
                PropertyDef1Id = table.Column<Guid>("TEXT", nullable: true),
                PropertyDef2Id = table.Column<Guid>("TEXT", nullable: true),
                PropertyDef3Id = table.Column<Guid>("TEXT", nullable: true),
                PropertyDef4Id = table.Column<Guid>("TEXT", nullable: true),
                PropertyDef5Id = table.Column<Guid>("TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ThingDef", x => x.Id);
                table.ForeignKey(
                    "FK_ThingDef_PropertyDef_PropertyDef1Id",
                    x => x.PropertyDef1Id,
                    "PropertyDef",
                    "Id");
                table.ForeignKey(
                    "FK_ThingDef_PropertyDef_PropertyDef2Id",
                    x => x.PropertyDef2Id,
                    "PropertyDef",
                    "Id");
                table.ForeignKey(
                    "FK_ThingDef_PropertyDef_PropertyDef3Id",
                    x => x.PropertyDef3Id,
                    "PropertyDef",
                    "Id");
                table.ForeignKey(
                    "FK_ThingDef_PropertyDef_PropertyDef4Id",
                    x => x.PropertyDef4Id,
                    "PropertyDef",
                    "Id");
                table.ForeignKey(
                    "FK_ThingDef_PropertyDef_PropertyDef5Id",
                    x => x.PropertyDef5Id,
                    "PropertyDef",
                    "Id");
            });

        migrationBuilder.CreateTable(
            "StatusDef",
            table => new
            {
                Id = table.Column<Guid>("TEXT", nullable: false),
                Name = table.Column<string>("TEXT", nullable: false),
                ThingDefEntityId = table.Column<string>("TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StatusDef", x => x.Id);
                table.ForeignKey(
                    "FK_StatusDef_ThingDef_ThingDefEntityId",
                    x => x.ThingDefEntityId,
                    "ThingDef",
                    "Id");
            });

        migrationBuilder.CreateIndex(
            "IX_StatusDef_ThingDefEntityId",
            "StatusDef",
            "ThingDefEntityId");

        migrationBuilder.CreateIndex(
            "IX_ThingDef_PropertyDef1Id",
            "ThingDef",
            "PropertyDef1Id");

        migrationBuilder.CreateIndex(
            "IX_ThingDef_PropertyDef2Id",
            "ThingDef",
            "PropertyDef2Id");

        migrationBuilder.CreateIndex(
            "IX_ThingDef_PropertyDef3Id",
            "ThingDef",
            "PropertyDef3Id");

        migrationBuilder.CreateIndex(
            "IX_ThingDef_PropertyDef4Id",
            "ThingDef",
            "PropertyDef4Id");

        migrationBuilder.CreateIndex(
            "IX_ThingDef_PropertyDef5Id",
            "ThingDef",
            "PropertyDef5Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "StatusDef");

        migrationBuilder.DropTable(
            "ThingDef");

        migrationBuilder.DropTable(
            "PropertyDef");
    }
}