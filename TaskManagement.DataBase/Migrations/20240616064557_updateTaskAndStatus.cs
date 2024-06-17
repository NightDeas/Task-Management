using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class updateTaskAndStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusTask");

            migrationBuilder.DropIndex(
                name: "IX_HistoryChanges_TaskId",
                table: "HistoryChanges");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryChanges_TaskId",
                table: "HistoryChanges",
                column: "TaskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Status_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Status_StatusId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_HistoryChanges_TaskId",
                table: "HistoryChanges");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Tasks");

            migrationBuilder.CreateTable(
                name: "StatusTask",
                columns: table => new
                {
                    StatusesId = table.Column<int>(type: "int", nullable: false),
                    TasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTask", x => new { x.StatusesId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_StatusTask_Status_StatusesId",
                        column: x => x.StatusesId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatusTask_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryChanges_TaskId",
                table: "HistoryChanges",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTask_TasksId",
                table: "StatusTask",
                column: "TasksId");
        }
    }
}
