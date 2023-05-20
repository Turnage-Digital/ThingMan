using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThingMan.Infra.SqlDB.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyDef",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDef", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThingDefs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyDef1Id = table.Column<string>(type: "TEXT", nullable: true),
                    PropertyDef2Id = table.Column<string>(type: "TEXT", nullable: true),
                    PropertyDef3Id = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingDefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThingDefs_PropertyDef_PropertyDef1Id",
                        column: x => x.PropertyDef1Id,
                        principalTable: "PropertyDef",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThingDefs_PropertyDef_PropertyDef2Id",
                        column: x => x.PropertyDef2Id,
                        principalTable: "PropertyDef",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThingDefs_PropertyDef_PropertyDef3Id",
                        column: x => x.PropertyDef3Id,
                        principalTable: "PropertyDef",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationDef",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    ThingDefId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationDef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationDef_ThingDefs_ThingDefId",
                        column: x => x.ThingDefId,
                        principalTable: "ThingDefs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatusDef",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ThingDefId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusDef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusDef_ThingDefs_ThingDefId",
                        column: x => x.ThingDefId,
                        principalTable: "ThingDefs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationDef_ThingDefId",
                table: "NotificationDef",
                column: "ThingDefId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusDef_ThingDefId",
                table: "StatusDef",
                column: "ThingDefId");

            migrationBuilder.CreateIndex(
                name: "IX_ThingDefs_PropertyDef1Id",
                table: "ThingDefs",
                column: "PropertyDef1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThingDefs_PropertyDef2Id",
                table: "ThingDefs",
                column: "PropertyDef2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThingDefs_PropertyDef3Id",
                table: "ThingDefs",
                column: "PropertyDef3Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationDef");

            migrationBuilder.DropTable(
                name: "StatusDef");

            migrationBuilder.DropTable(
                name: "ThingDefs");

            migrationBuilder.DropTable(
                name: "PropertyDef");
        }
    }
}
