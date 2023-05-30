#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace ThingMan.Infra.SqlDB.Migrations.ThingMan;

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
                Id = table.Column<string>("TEXT", nullable: false),
                Name = table.Column<string>("TEXT", nullable: false),
                Type = table.Column<int>("INTEGER", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_PropertyDef", x => x.Id); });

        migrationBuilder.CreateTable(
            "ThingDefs",
            table => new
            {
                Id = table.Column<string>("TEXT", nullable: false),
                Name = table.Column<string>("TEXT", nullable: false),
                UserId = table.Column<string>("TEXT", nullable: false),
                PropertyDef1Id = table.Column<string>("TEXT", nullable: true),
                PropertyDef2Id = table.Column<string>("TEXT", nullable: true),
                PropertyDef3Id = table.Column<string>("TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ThingDefs", x => x.Id);
                table.ForeignKey(
                    "FK_ThingDefs_PropertyDef_PropertyDef1Id",
                    x => x.PropertyDef1Id,
                    "PropertyDef",
                    "Id");
                table.ForeignKey(
                    "FK_ThingDefs_PropertyDef_PropertyDef2Id",
                    x => x.PropertyDef2Id,
                    "PropertyDef",
                    "Id");
                table.ForeignKey(
                    "FK_ThingDefs_PropertyDef_PropertyDef3Id",
                    x => x.PropertyDef3Id,
                    "PropertyDef",
                    "Id");
            });

        migrationBuilder.CreateTable(
            "NotificationDef",
            table => new
            {
                Id = table.Column<string>("TEXT", nullable: false),
                Type = table.Column<int>("INTEGER", nullable: false),
                IsActive = table.Column<bool>("INTEGER", nullable: false),
                UserId = table.Column<string>("TEXT", nullable: true),
                ThingDefId = table.Column<string>("TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_NotificationDef", x => x.Id);
                table.ForeignKey(
                    "FK_NotificationDef_ThingDefs_ThingDefId",
                    x => x.ThingDefId,
                    "ThingDefs",
                    "Id");
            });

        migrationBuilder.CreateTable(
            "StatusDef",
            table => new
            {
                Id = table.Column<string>("TEXT", nullable: false),
                Name = table.Column<string>("TEXT", nullable: false),
                ThingDefId = table.Column<string>("TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StatusDef", x => x.Id);
                table.ForeignKey(
                    "FK_StatusDef_ThingDefs_ThingDefId",
                    x => x.ThingDefId,
                    "ThingDefs",
                    "Id");
            });

        migrationBuilder.CreateIndex(
            "IX_NotificationDef_ThingDefId",
            "NotificationDef",
            "ThingDefId");

        migrationBuilder.CreateIndex(
            "IX_StatusDef_ThingDefId",
            "StatusDef",
            "ThingDefId");

        migrationBuilder.CreateIndex(
            "IX_ThingDefs_PropertyDef1Id",
            "ThingDefs",
            "PropertyDef1Id");

        migrationBuilder.CreateIndex(
            "IX_ThingDefs_PropertyDef2Id",
            "ThingDefs",
            "PropertyDef2Id");

        migrationBuilder.CreateIndex(
            "IX_ThingDefs_PropertyDef3Id",
            "ThingDefs",
            "PropertyDef3Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "NotificationDef");

        migrationBuilder.DropTable(
            "StatusDef");

        migrationBuilder.DropTable(
            "ThingDefs");

        migrationBuilder.DropTable(
            "PropertyDef");
    }
}