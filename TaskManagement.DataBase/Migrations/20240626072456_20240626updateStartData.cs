using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class _20240626updateStartData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(8799),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 25, 20, 33, 9, 318, DateTimeKind.Local).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(1994, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2017, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(1990, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(1984, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(1994, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "HistoryChangeStatusTask",
                columns: new[] { "Id", "Date", "StatusId", "TaskId" },
                values: new object[] { 6, new DateTime(1986, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Project#1");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Project#2");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Project#3");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Project#4");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Project#5");

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 6, false, "Project#6" },
                    { 7, false, "Project#7" },
                    { 8, false, "Project#8" },
                    { 9, false, "Project#9" },
                    { 10, false, "Project#10" }
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Deadline", "Description", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(8799), new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description#1", new DateTime(2024, 7, 6, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9808), "Task#1", 6, new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9806), 64 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Deadline", "Description", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(8799), new DateTime(1975, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description#2", new DateTime(2024, 7, 3, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9840), "Task#2", 7, new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9839), 59 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Deadline", "Description", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(8799), new DateTime(2014, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description#3", new DateTime(2024, 6, 27, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9863), "Task#3", 5, new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9862), 61 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Deadline", "Description", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(8799), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description#4", new DateTime(2024, 6, 28, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9909), "Task#4", 2, new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9909), 59 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Deadline", "Description", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(8799), new DateTime(1995, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description#5", new DateTime(2024, 7, 1, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9933), "Task#5", 4, new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9932), 53 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Deadline", "Description", "EndDate", "Name", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(8799), new DateTime(2000, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description#6", new DateTime(2024, 6, 28, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9957), "Task#6", new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9957), 66 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Deadline", "Deleted", "Description", "EndDate", "Name", "ProjectId", "StartDate", "Updated", "UserId" },
                values: new object[,]
                {
                    { 7, new DateTime(1973, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#7", new DateTime(2024, 7, 8, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9981), "Task#7", 4, new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(9980), null, 52 },
                    { 9, new DateTime(1997, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#9", new DateTime(2024, 7, 7, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(30), "Task#9", 1, new DateTime(2024, 6, 26, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(29), null, 69 },
                    { 12, new DateTime(1992, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#12", new DateTime(2024, 6, 28, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(104), "Task#12", 2, new DateTime(2024, 6, 26, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(103), null, 71 },
                    { 13, new DateTime(2008, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#13", new DateTime(2024, 7, 13, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(128), "Task#13", 1, new DateTime(2024, 6, 26, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(127), null, 74 },
                    { 14, new DateTime(2013, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#14", new DateTime(2024, 6, 27, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(150), "Task#14", 1, new DateTime(2024, 6, 26, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(149), null, 66 },
                    { 15, new DateTime(1994, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#15", new DateTime(2024, 7, 5, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(173), "Task#15", 2, new DateTime(2024, 6, 26, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(173), null, 72 },
                    { 16, new DateTime(2003, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#16", new DateTime(2024, 7, 8, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(199), "Task#16", 3, new DateTime(2024, 6, 26, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(198), null, 74 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Иван", "Иванов", "log1", "pas1", "Максимович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Максим", "Буранов", "log2", "pas2", "Максимович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Иван", "Гримов", "log3", "pas3", "Никитович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Даниил", "Ивашкин", "log4", "pas4", "Александрович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Юрий", "Куколович", "log5", "pas5", "Петрович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Алексей", "Буранов", "log6", "pas6", "Иванович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Максим", "Александров", "log7", "pas7", "Петрович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Григорий", "Петров", "log8", "pas8", "Никитович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Григорий", "Сидоров", "log9", "pas9", "Иванович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Григорий", "Иванов", "log10", "pas10", "Сергеевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Юрий", "Серлов", "log11", "pas11", "Юрьевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Максим", "Печкин", "log12", "pas12", "Александрович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Сергей", "Петров", "log13", "pas13", "Даниилович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Петр", "Сидоров", "log14", "pas14", "Владиславович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Александр", "Печкин", "log15", "pas15", "Максимович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Алексей", "Александров", "log16", "pas16", "Даниилович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Петр", "Куколович", "log17", "pas17", "Юрьевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Юрий", "Сидоров", "log18", "pas18", "Григорьевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Максим", "Ивашкин", "log19", "pas19", "Сергеевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Владислав", "Печкин", "log20", "pas20", "Владиславович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Иван", "Печкин", "log21", "pas21", "Владиславович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Сергей", "Иванов", "log22", "pas22", "Сергеевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Юрий", "Петров", "log23", "pas23", "Петрович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Максим", "Петров", "log24", "pas24", "Иванович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Иван", "Александров", "log25", "pas25", "Сергеевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Григорий", "Куколович", "log26", "pas26", "Даниилович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Иван", "Александров", "log27", "pas27", "Петрович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Владислав", "Печкин", "log28", "pas28", "Никитович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Даниил", "Александров", "log29", "pas29", "Александрович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Максим", "Гримов", "log30", "pas30", "Владиславович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Владислав", "Сидоров", "log31", "pas31", "Максимович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Сергей", "Иванов", "log32", "pas32", "Даниилович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Максим", "Печкин", "log33", "pas33", "Иванович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Иван", "Петров", "log34", "pas34", "Максимович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Иван", "Александров", "log35", "pas35", "Иванович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Григорий", "Харизматов", "log36", "pas36", "Юрьевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Владислав", "Буранов", "log37", "pas37", "Иванович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Юрий", "Гримов", "log38", "pas38", "Никитович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Петр", "Буранов", "log39", "pas39", "Петрович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Владислав", "Иванов", "log40", "pas40", "Петрович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Даниил", "Куколович", "log41", "pas41", "Никитович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Сергей", "Харизматов", "log42", "pas42", "Владиславович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Юрий", "Буранов", "log43", "pas43", "Даниилович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Алексей", "Харизматов", "log44", "pas44", "Владиславович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Максим", "Куколович", "log45", "pas45", "Сергеевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Григорий", "Александров", "log46", "pas46", "Сергеевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Максим", "Ивашкин", "log47", "pas47", "Никитович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Владислав", "Петров", "log48", "pas48", "Максимович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Даниил", "Петров", "log49", "pas49", "Даниилович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Владислав", "Куколович", "log50", "pas50", "Владиславович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Максим", "Буранов", "log51", "pas51", "Сергеевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Алексей", "Ивашкин", "log52", "pas52", "Владиславович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Владислав", "Ивашкин", "log53", "pas53", "Александрович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Александр", "Александров", "log54", "pas54", "Максимович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Даниил", "Куколович", "log55", "pas55", "Иванович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Петр", "Сидоров", "log56", "pas56", "Петрович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Петр", "Куколович", "log57", "pas57", "Даниилович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Александр", "Куколович", "log58", "pas58", "Никитович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Александр", "Харизматов", "log59", "pas59", "Алексеевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Петр", "Буранов", "log60", "pas60", "Никитович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Владислав", "Печкин", "log61", "pas61", "Алексеевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Сергей", "Харизматов", "log62", "pas62", "Максимович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Григорий", "Куколович", "log63", "pas63", "Сергеевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Даниил", "Печкин", "log64", "pas64", "Григорьевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Сергей", "Серлов", "log65", "pas65", "Иванович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Григорий", "Сидоров", "log66", "pas66", "Григорьевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Петр", "Буранов", "log67", "pas67", "Максимович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Алексей", "Гримов", "log68", "pas68", "Даниилович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Владислав", "Иванов", "log69", "pas69", "Владиславович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Петр", "Сидоров", "log70", "pas70", "Алексеевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Никита", "Сидоров", "log71", "pas71", "Юрьевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Юрий", "Иванов", "log72", "pas72", "Никитович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Максим", "Серлов", "log73", "pas73", "Юрьевич" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Александр", "Харизматов", "log74", "pas74", "Даниилович" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "Даниил", "Иванов", "log75", "pas75", "Максимович" });

            migrationBuilder.InsertData(
                table: "HistoryChangeStatusTask",
                columns: new[] { "Id", "Date", "StatusId", "TaskId" },
                values: new object[,]
                {
                    { 7, new DateTime(2009, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 7 },
                    { 9, new DateTime(1980, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 12, new DateTime(1985, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 12 },
                    { 13, new DateTime(1976, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 13 },
                    { 14, new DateTime(1978, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 14 },
                    { 15, new DateTime(2001, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 15 },
                    { 16, new DateTime(1995, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 16 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Deadline", "Deleted", "Description", "EndDate", "Name", "ProjectId", "StartDate", "Updated", "UserId" },
                values: new object[,]
                {
                    { 8, new DateTime(2006, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#8", new DateTime(2024, 7, 10, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(7), "Task#8", 9, new DateTime(2024, 6, 26, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(7), null, 55 },
                    { 10, new DateTime(1998, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#10", new DateTime(2024, 7, 4, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(55), "Task#10", 7, new DateTime(2024, 6, 26, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(54), null, 58 },
                    { 11, new DateTime(2018, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#11", new DateTime(2024, 7, 4, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(78), "Task#11", 7, new DateTime(2024, 6, 26, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(77), null, 70 },
                    { 17, new DateTime(2008, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#17", new DateTime(2024, 7, 2, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(223), "Task#17", 8, new DateTime(2024, 6, 26, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(222), null, 65 },
                    { 18, new DateTime(1999, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#18", new DateTime(2024, 6, 30, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(248), "Task#18", 6, new DateTime(2024, 6, 26, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(247), null, 60 },
                    { 19, new DateTime(2009, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Description#19", new DateTime(2024, 7, 10, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(277), "Task#19", 7, new DateTime(2024, 6, 26, 10, 24, 56, 520, DateTimeKind.Local).AddTicks(276), null, 55 }
                });

            migrationBuilder.InsertData(
                table: "HistoryChangeStatusTask",
                columns: new[] { "Id", "Date", "StatusId", "TaskId" },
                values: new object[,]
                {
                    { 8, new DateTime(1993, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8 },
                    { 10, new DateTime(2003, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 11, new DateTime(2003, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 11 },
                    { 17, new DateTime(1993, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 17 },
                    { 18, new DateTime(1975, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 18 },
                    { 19, new DateTime(2000, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 19 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 25, 20, 33, 9, 318, DateTimeKind.Local).AddTicks(35),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 26, 10, 24, 56, 519, DateTimeKind.Local).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), 4 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), 3 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Project1");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Project2");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Project3");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Project4");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Project5");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Deadline", "Description", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 6, 25, 20, 33, 9, 318, DateTimeKind.Local).AddTicks(35), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), "desc1", null, "name1", 1, null, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Deadline", "Description", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 6, 25, 20, 33, 9, 318, DateTimeKind.Local).AddTicks(35), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), "desc1", null, "name1", 1, null, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Deadline", "Description", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 6, 25, 20, 33, 9, 318, DateTimeKind.Local).AddTicks(35), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), "desc1", null, "name1", 1, null, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Deadline", "Description", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 6, 25, 20, 33, 9, 318, DateTimeKind.Local).AddTicks(35), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), "desc1", null, "name1", 1, null, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Deadline", "Description", "EndDate", "Name", "ProjectId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 6, 25, 20, 33, 9, 318, DateTimeKind.Local).AddTicks(35), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), "desc1", null, "name1", 1, null, 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Deadline", "Description", "EndDate", "Name", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 6, 25, 20, 33, 9, 318, DateTimeKind.Local).AddTicks(35), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), "desc1", null, "name1", null, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName0", "LastName0", "Login1", "Password1", "Patronymic0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName1", "LastName1", "Login2", "Password2", "Patronymic1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName2", "LastName2", "Login3", "Password3", "Patronymic2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName3", "LastName3", "Login4", "Password4", "Patronymic3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName4", "LastName4", "Login5", "Password5", "Patronymic4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName5", "LastName5", "Login6", "Password6", "Patronymic5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName6", "LastName6", "Login7", "Password7", "Patronymic6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName7", "LastName7", "Login8", "Password8", "Patronymic7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName8", "LastName8", "Login9", "Password9", "Patronymic8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName9", "LastName9", "Login10", "Password10", "Patronymic9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName10", "LastName10", "Login11", "Password11", "Patronymic10" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName11", "LastName11", "Login12", "Password12", "Patronymic11" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName12", "LastName12", "Login13", "Password13", "Patronymic12" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName13", "LastName13", "Login14", "Password14", "Patronymic13" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName14", "LastName14", "Login15", "Password15", "Patronymic14" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName15", "LastName15", "Login16", "Password16", "Patronymic15" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName16", "LastName16", "Login17", "Password17", "Patronymic16" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName17", "LastName17", "Login18", "Password18", "Patronymic17" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName18", "LastName18", "Login19", "Password19", "Patronymic18" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName19", "LastName19", "Login20", "Password20", "Patronymic19" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName20", "LastName20", "Login21", "Password21", "Patronymic20" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName21", "LastName21", "Login22", "Password22", "Patronymic21" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName22", "LastName22", "Login23", "Password23", "Patronymic22" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName23", "LastName23", "Login24", "Password24", "Patronymic23" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName24", "LastName24", "Login25", "Password25", "Patronymic24" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName0", "LastName0", "Login26", "Password26", "Patronymic0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName1", "LastName1", "Login27", "Password27", "Patronymic1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName2", "LastName2", "Login28", "Password28", "Patronymic2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName3", "LastName3", "Login29", "Password29", "Patronymic3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName4", "LastName4", "Login30", "Password30", "Patronymic4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName5", "LastName5", "Login31", "Password31", "Patronymic5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName6", "LastName6", "Login32", "Password32", "Patronymic6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName7", "LastName7", "Login33", "Password33", "Patronymic7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName8", "LastName8", "Login34", "Password34", "Patronymic8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName9", "LastName9", "Login35", "Password35", "Patronymic9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName10", "LastName10", "Login36", "Password36", "Patronymic10" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName11", "LastName11", "Login37", "Password37", "Patronymic11" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName12", "LastName12", "Login38", "Password38", "Patronymic12" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName13", "LastName13", "Login39", "Password39", "Patronymic13" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName14", "LastName14", "Login40", "Password40", "Patronymic14" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName15", "LastName15", "Login41", "Password41", "Patronymic15" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName16", "LastName16", "Login42", "Password42", "Patronymic16" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName17", "LastName17", "Login43", "Password43", "Patronymic17" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName18", "LastName18", "Login44", "Password44", "Patronymic18" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName19", "LastName19", "Login45", "Password45", "Patronymic19" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName20", "LastName20", "Login46", "Password46", "Patronymic20" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName21", "LastName21", "Login47", "Password47", "Patronymic21" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName22", "LastName22", "Login48", "Password48", "Patronymic22" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName23", "LastName23", "Login49", "Password49", "Patronymic23" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName24", "LastName24", "Login50", "Password50", "Patronymic24" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName0", "LastName0", "Login51", "Password51", "Patronymic0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName1", "LastName1", "Login52", "Password52", "Patronymic1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName2", "LastName2", "Login53", "Password53", "Patronymic2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName3", "LastName3", "Login54", "Password54", "Patronymic3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName4", "LastName4", "Login55", "Password55", "Patronymic4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName5", "LastName5", "Login56", "Password56", "Patronymic5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName6", "LastName6", "Login57", "Password57", "Patronymic6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName7", "LastName7", "Login58", "Password58", "Patronymic7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName8", "LastName8", "Login59", "Password59", "Patronymic8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName9", "LastName9", "Login60", "Password60", "Patronymic9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName10", "LastName10", "Login61", "Password61", "Patronymic10" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName11", "LastName11", "Login62", "Password62", "Patronymic11" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName12", "LastName12", "Login63", "Password63", "Patronymic12" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName13", "LastName13", "Login64", "Password64", "Patronymic13" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName14", "LastName14", "Login65", "Password65", "Patronymic14" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName15", "LastName15", "Login66", "Password66", "Patronymic15" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName16", "LastName16", "Login67", "Password67", "Patronymic16" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName17", "LastName17", "Login68", "Password68", "Patronymic17" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName18", "LastName18", "Login69", "Password69", "Patronymic18" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName19", "LastName19", "Login70", "Password70", "Patronymic19" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName20", "LastName20", "Login71", "Password71", "Patronymic20" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName21", "LastName21", "Login72", "Password72", "Patronymic21" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName22", "LastName22", "Login73", "Password73", "Patronymic22" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName23", "LastName23", "Login74", "Password74", "Patronymic23" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "FirstName24", "LastName24", "Login75", "Password75", "Patronymic24" });
        }
    }
}
