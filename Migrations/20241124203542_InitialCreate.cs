using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManageOrdersAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameClient = table.Column<string>(type: "TEXT", nullable: false),
                    NameExecutor = table.Column<string>(type: "TEXT", nullable: false),
                    PickupAddress = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "TEXT", nullable: false),
                    PickupTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    CancelReason = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "IdOrder", "CancelReason", "DeliveryAddress", "NameClient", "NameExecutor", "PickupAddress", "PickupTime", "Status" },
                values: new object[,]
                {
                    { 1, null, "ул. Пушкина, 5", "Иванов Иван", "Сидоров Петр", "ул. Ленина, 10", new DateTime(2024, 11, 25, 0, 35, 41, 433, DateTimeKind.Local).AddTicks(6931), "Новая" },
                    { 2, null, "ул. Гоголя, 12", "Петров Сергей", "Иванов Андрей", "пр. Мира, 23", new DateTime(2024, 11, 25, 1, 35, 41, 436, DateTimeKind.Local).AddTicks(5984), "Новая" },
                    { 3, null, "ул. Чехова, 8", "Смирнов Алексей", "Михайлов Игорь", "ул. Советская, 15", new DateTime(2024, 11, 25, 2, 35, 41, 436, DateTimeKind.Local).AddTicks(6012), "Новая" },
                    { 4, null, "ул. Толстого, 20", "Алексеева Ольга", "Николаев Виталий", "ул. Кирова, 7", new DateTime(2024, 11, 25, 3, 35, 41, 436, DateTimeKind.Local).AddTicks(6016), "Новая" },
                    { 5, null, "ул. Некрасова, 3", "Кузнецов Виктор", "Павлов Дмитрий", "ул. Бабушкина, 9", new DateTime(2024, 11, 25, 4, 35, 41, 436, DateTimeKind.Local).AddTicks(6020), "Новая" },
                    { 6, null, "ул. Островского, 6", "Куликова Анна", "Егоров Максим", "ул. Труда, 14", new DateTime(2024, 11, 25, 5, 35, 41, 436, DateTimeKind.Local).AddTicks(6023), "Новая" },
                    { 7, null, "ул. Пирогова, 11", "Морозов Артем", "Лебедев Денис", "ул. Зои Космодемьянской, 18", new DateTime(2024, 11, 25, 6, 35, 41, 436, DateTimeKind.Local).AddTicks(6026), "Новая" },
                    { 8, null, "ул. Лермонтова, 13", "Фролова Татьяна", "Григорьев Олег", "ул. Победы, 22", new DateTime(2024, 11, 25, 7, 35, 41, 436, DateTimeKind.Local).AddTicks(6030), "Новая" },
                    { 9, null, "ул. Тургенева, 2", "Воробьева Светлана", "Данилов Александр", "ул. Багратиона, 19", new DateTime(2024, 11, 25, 8, 35, 41, 436, DateTimeKind.Local).AddTicks(6033), "Новая" },
                    { 10, null, "ул. Горького, 17", "Громов Михаил", "Романов Артем", "ул. Декабристов, 25", new DateTime(2024, 11, 25, 9, 35, 41, 436, DateTimeKind.Local).AddTicks(6036), "Новая" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
