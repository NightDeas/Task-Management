using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class updateStartData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 4,
                column: "StatusId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 5,
                column: "StatusId",
                value: 3);

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
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic", "RoleId" },
                values: new object[] { "FirstName1", "LastName1", "Login2", "Password2", "Patronymic1", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic", "RoleId" },
                values: new object[] { "FirstName2", "LastName2", "Login3", "Password3", "Patronymic2", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Login", "Password", "Patronymic", "RoleId" },
                values: new object[,]
                {
                    { 4, "FirstName3", "LastName3", "Login4", "Password4", "Patronymic3", 1 },
                    { 5, "FirstName4", "LastName4", "Login5", "Password5", "Patronymic4", 1 },
                    { 6, "FirstName5", "LastName5", "Login6", "Password6", "Patronymic5", 1 },
                    { 7, "FirstName6", "LastName6", "Login7", "Password7", "Patronymic6", 1 },
                    { 8, "FirstName7", "LastName7", "Login8", "Password8", "Patronymic7", 1 },
                    { 9, "FirstName8", "LastName8", "Login9", "Password9", "Patronymic8", 1 },
                    { 10, "FirstName9", "LastName9", "Login10", "Password10", "Patronymic9", 1 },
                    { 11, "FirstName10", "LastName10", "Login11", "Password11", "Patronymic10", 1 },
                    { 12, "FirstName11", "LastName11", "Login12", "Password12", "Patronymic11", 1 },
                    { 13, "FirstName12", "LastName12", "Login13", "Password13", "Patronymic12", 1 },
                    { 14, "FirstName13", "LastName13", "Login14", "Password14", "Patronymic13", 1 },
                    { 15, "FirstName14", "LastName14", "Login15", "Password15", "Patronymic14", 1 },
                    { 16, "FirstName15", "LastName15", "Login16", "Password16", "Patronymic15", 1 },
                    { 17, "FirstName16", "LastName16", "Login17", "Password17", "Patronymic16", 1 },
                    { 18, "FirstName17", "LastName17", "Login18", "Password18", "Patronymic17", 1 },
                    { 19, "FirstName18", "LastName18", "Login19", "Password19", "Patronymic18", 1 },
                    { 20, "FirstName19", "LastName19", "Login20", "Password20", "Patronymic19", 1 },
                    { 21, "FirstName20", "LastName20", "Login21", "Password21", "Patronymic20", 1 },
                    { 22, "FirstName21", "LastName21", "Login22", "Password22", "Patronymic21", 1 },
                    { 23, "FirstName22", "LastName22", "Login23", "Password23", "Patronymic22", 1 },
                    { 24, "FirstName23", "LastName23", "Login24", "Password24", "Patronymic23", 1 },
                    { 25, "FirstName24", "LastName24", "Login25", "Password25", "Patronymic24", 1 },
                    { 26, "FirstName0", "LastName0", "Login26", "Password26", "Patronymic0", 2 },
                    { 27, "FirstName1", "LastName1", "Login27", "Password27", "Patronymic1", 2 },
                    { 28, "FirstName2", "LastName2", "Login28", "Password28", "Patronymic2", 2 },
                    { 29, "FirstName3", "LastName3", "Login29", "Password29", "Patronymic3", 2 },
                    { 30, "FirstName4", "LastName4", "Login30", "Password30", "Patronymic4", 2 },
                    { 31, "FirstName5", "LastName5", "Login31", "Password31", "Patronymic5", 2 },
                    { 32, "FirstName6", "LastName6", "Login32", "Password32", "Patronymic6", 2 },
                    { 33, "FirstName7", "LastName7", "Login33", "Password33", "Patronymic7", 2 },
                    { 34, "FirstName8", "LastName8", "Login34", "Password34", "Patronymic8", 2 },
                    { 35, "FirstName9", "LastName9", "Login35", "Password35", "Patronymic9", 2 },
                    { 36, "FirstName10", "LastName10", "Login36", "Password36", "Patronymic10", 2 },
                    { 37, "FirstName11", "LastName11", "Login37", "Password37", "Patronymic11", 2 },
                    { 38, "FirstName12", "LastName12", "Login38", "Password38", "Patronymic12", 2 },
                    { 39, "FirstName13", "LastName13", "Login39", "Password39", "Patronymic13", 2 },
                    { 40, "FirstName14", "LastName14", "Login40", "Password40", "Patronymic14", 2 },
                    { 41, "FirstName15", "LastName15", "Login41", "Password41", "Patronymic15", 2 },
                    { 42, "FirstName16", "LastName16", "Login42", "Password42", "Patronymic16", 2 },
                    { 43, "FirstName17", "LastName17", "Login43", "Password43", "Patronymic17", 2 },
                    { 44, "FirstName18", "LastName18", "Login44", "Password44", "Patronymic18", 2 },
                    { 45, "FirstName19", "LastName19", "Login45", "Password45", "Patronymic19", 2 },
                    { 46, "FirstName20", "LastName20", "Login46", "Password46", "Patronymic20", 2 },
                    { 47, "FirstName21", "LastName21", "Login47", "Password47", "Patronymic21", 2 },
                    { 48, "FirstName22", "LastName22", "Login48", "Password48", "Patronymic22", 2 },
                    { 49, "FirstName23", "LastName23", "Login49", "Password49", "Patronymic23", 2 },
                    { 50, "FirstName24", "LastName24", "Login50", "Password50", "Patronymic24", 2 },
                    { 51, "FirstName0", "LastName0", "Login51", "Password51", "Patronymic0", 3 },
                    { 52, "FirstName1", "LastName1", "Login52", "Password52", "Patronymic1", 3 },
                    { 53, "FirstName2", "LastName2", "Login53", "Password53", "Patronymic2", 3 },
                    { 54, "FirstName3", "LastName3", "Login54", "Password54", "Patronymic3", 3 },
                    { 55, "FirstName4", "LastName4", "Login55", "Password55", "Patronymic4", 3 },
                    { 56, "FirstName5", "LastName5", "Login56", "Password56", "Patronymic5", 3 },
                    { 57, "FirstName6", "LastName6", "Login57", "Password57", "Patronymic6", 3 },
                    { 58, "FirstName7", "LastName7", "Login58", "Password58", "Patronymic7", 3 },
                    { 59, "FirstName8", "LastName8", "Login59", "Password59", "Patronymic8", 3 },
                    { 60, "FirstName9", "LastName9", "Login60", "Password60", "Patronymic9", 3 },
                    { 61, "FirstName10", "LastName10", "Login61", "Password61", "Patronymic10", 3 },
                    { 62, "FirstName11", "LastName11", "Login62", "Password62", "Patronymic11", 3 },
                    { 63, "FirstName12", "LastName12", "Login63", "Password63", "Patronymic12", 3 },
                    { 64, "FirstName13", "LastName13", "Login64", "Password64", "Patronymic13", 3 },
                    { 65, "FirstName14", "LastName14", "Login65", "Password65", "Patronymic14", 3 },
                    { 66, "FirstName15", "LastName15", "Login66", "Password66", "Patronymic15", 3 },
                    { 67, "FirstName16", "LastName16", "Login67", "Password67", "Patronymic16", 3 },
                    { 68, "FirstName17", "LastName17", "Login68", "Password68", "Patronymic17", 3 },
                    { 69, "FirstName18", "LastName18", "Login69", "Password69", "Patronymic18", 3 },
                    { 70, "FirstName19", "LastName19", "Login70", "Password70", "Patronymic19", 3 },
                    { 71, "FirstName20", "LastName20", "Login71", "Password71", "Patronymic20", 3 },
                    { 72, "FirstName21", "LastName21", "Login72", "Password72", "Patronymic21", 3 },
                    { 73, "FirstName22", "LastName22", "Login73", "Password73", "Patronymic22", 3 },
                    { 74, "FirstName23", "LastName23", "Login74", "Password74", "Patronymic23", 3 },
                    { 75, "FirstName24", "LastName24", "Login75", "Password75", "Patronymic24", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 4,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 5,
                column: "StatusId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic" },
                values: new object[] { "test", "test", "log1", "pass1", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic", "RoleId" },
                values: new object[] { "test", "test", "log2", "pass1", null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "Login", "Password", "Patronymic", "RoleId" },
                values: new object[] { "test", "test", "log3", "pass1", null, 3 });
        }
    }
}
