using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThingMan.Core.SqlDB.Migrations.ThingMan
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDef", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThingDef",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyDef1Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    PropertyDef2Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    PropertyDef3Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    PropertyDef4Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    PropertyDef5Id = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingDef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThingDef_PropertyDef_PropertyDef1Id",
                        column: x => x.PropertyDef1Id,
                        principalTable: "PropertyDef",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThingDef_PropertyDef_PropertyDef2Id",
                        column: x => x.PropertyDef2Id,
                        principalTable: "PropertyDef",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThingDef_PropertyDef_PropertyDef3Id",
                        column: x => x.PropertyDef3Id,
                        principalTable: "PropertyDef",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThingDef_PropertyDef_PropertyDef4Id",
                        column: x => x.PropertyDef4Id,
                        principalTable: "PropertyDef",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThingDef_PropertyDef_PropertyDef5Id",
                        column: x => x.PropertyDef5Id,
                        principalTable: "PropertyDef",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatusDef",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ThingDefEntityId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusDef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusDef_ThingDef_ThingDefEntityId",
                        column: x => x.ThingDefEntityId,
                        principalTable: "ThingDef",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatusDef_ThingDefEntityId",
                table: "StatusDef",
                column: "ThingDefEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ThingDef_PropertyDef1Id",
                table: "ThingDef",
                column: "PropertyDef1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThingDef_PropertyDef2Id",
                table: "ThingDef",
                column: "PropertyDef2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThingDef_PropertyDef3Id",
                table: "ThingDef",
                column: "PropertyDef3Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThingDef_PropertyDef4Id",
                table: "ThingDef",
                column: "PropertyDef4Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThingDef_PropertyDef5Id",
                table: "ThingDef",
                column: "PropertyDef5Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusDef");

            migrationBuilder.DropTable(
                name: "ThingDef");

            migrationBuilder.DropTable(
                name: "PropertyDef");
        }
    }
}
