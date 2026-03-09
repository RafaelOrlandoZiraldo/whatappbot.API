using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace whatappbot.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhatsAppId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConversationStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoActual = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatosTemporales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaInteraccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChatUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversationStates_ChatUsers_ChatUserId",
                        column: x => x.ChatUserId,
                        principalTable: "ChatUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_WhatsAppId",
                table: "ChatUsers",
                column: "WhatsAppId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConversationStates_ChatUserId",
                table: "ConversationStates",
                column: "ChatUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversationStates");

            migrationBuilder.DropTable(
                name: "ChatUsers");
        }
    }
}
