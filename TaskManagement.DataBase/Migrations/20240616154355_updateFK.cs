using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class updateFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryChanges_Status_StatusId",
                table: "HistoryChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryChanges_Tasks_TaskId",
                table: "HistoryChanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryChanges",
                table: "HistoryChanges");

            migrationBuilder.DropIndex(
                name: "IX_HistoryChanges_StatusId",
                table: "HistoryChanges");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Statuses");

            migrationBuilder.RenameTable(
                name: "HistoryChanges",
                newName: "HistoryChangeStatusTask");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryChanges_TaskId",
                table: "HistoryChangeStatusTask",
                newName: "IX_HistoryChangeStatusTask_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryChangeStatusTask",
                table: "HistoryChangeStatusTask",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_HistoryChangeStatusTask_StatusId",
                table: "HistoryChangeStatusTask",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryChangeStatusTask_Statuses_StatusId",
                table: "HistoryChangeStatusTask",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryChangeStatusTask_Tasks_TaskId",
                table: "HistoryChangeStatusTask",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryChangeStatusTask_Statuses_StatusId",
                table: "HistoryChangeStatusTask");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryChangeStatusTask_Tasks_TaskId",
                table: "HistoryChangeStatusTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryChangeStatusTask",
                table: "HistoryChangeStatusTask");

            migrationBuilder.DropIndex(
                name: "IX_HistoryChangeStatusTask_StatusId",
                table: "HistoryChangeStatusTask");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Status");

            migrationBuilder.RenameTable(
                name: "HistoryChangeStatusTask",
                newName: "HistoryChanges");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryChangeStatusTask_TaskId",
                table: "HistoryChanges",
                newName: "IX_HistoryChanges_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryChanges",
                table: "HistoryChanges",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "HistoryChanges",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_HistoryChanges_StatusId",
                table: "HistoryChanges",
                column: "StatusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryChanges_Status_StatusId",
                table: "HistoryChanges",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryChanges_Tasks_TaskId",
                table: "HistoryChanges",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
