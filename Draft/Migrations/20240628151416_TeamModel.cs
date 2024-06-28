using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Draft.Migrations
{
    /// <inheritdoc />
    public partial class TeamModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalkeeperId = table.Column<int>(type: "int", nullable: true),
                    Deffender1Id = table.Column<int>(type: "int", nullable: true),
                    Deffender2Id = table.Column<int>(type: "int", nullable: true),
                    Deffender3Id = table.Column<int>(type: "int", nullable: true),
                    Deffender4Id = table.Column<int>(type: "int", nullable: true),
                    Midfielder1Id = table.Column<int>(type: "int", nullable: true),
                    Midfielder2Id = table.Column<int>(type: "int", nullable: true),
                    Midfielder3Id = table.Column<int>(type: "int", nullable: true),
                    Midfielder4Id = table.Column<int>(type: "int", nullable: true),
                    Forward1Id = table.Column<int>(type: "int", nullable: true),
                    Forward2Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Deffender1Id",
                        column: x => x.Deffender1Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Deffender2Id",
                        column: x => x.Deffender2Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Deffender3Id",
                        column: x => x.Deffender3Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Deffender4Id",
                        column: x => x.Deffender4Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Forward1Id",
                        column: x => x.Forward1Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Forward2Id",
                        column: x => x.Forward2Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_GoalkeeperId",
                        column: x => x.GoalkeeperId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Midfielder1Id",
                        column: x => x.Midfielder1Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Midfielder2Id",
                        column: x => x.Midfielder2Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Midfielder3Id",
                        column: x => x.Midfielder3Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Midfielder4Id",
                        column: x => x.Midfielder4Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId",
                unique: true,
                filter: "[TeamId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Deffender1Id",
                table: "Teams",
                column: "Deffender1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Deffender2Id",
                table: "Teams",
                column: "Deffender2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Deffender3Id",
                table: "Teams",
                column: "Deffender3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Deffender4Id",
                table: "Teams",
                column: "Deffender4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Forward1Id",
                table: "Teams",
                column: "Forward1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Forward2Id",
                table: "Teams",
                column: "Forward2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GoalkeeperId",
                table: "Teams",
                column: "GoalkeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Midfielder1Id",
                table: "Teams",
                column: "Midfielder1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Midfielder2Id",
                table: "Teams",
                column: "Midfielder2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Midfielder3Id",
                table: "Teams",
                column: "Midfielder3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Midfielder4Id",
                table: "Teams",
                column: "Midfielder4Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeamId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Users");
        }
    }
}
