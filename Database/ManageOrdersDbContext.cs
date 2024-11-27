using Microsoft.EntityFrameworkCore;

namespace ManageOrdersAPI.Database
{
    public class ManageOrdersDbContext : DbContext
    {
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<CourierModel> Couriers { get; set; }
        public DbSet<OrderModel> OrderStatuses { get; set; }

        public ManageOrdersDbContext(DbContextOptions<ManageOrdersDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        /// <summary>
        /// Заполнение базы
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Справочник статусов заявки
            modelBuilder.Entity<OrderStatusModel>(entity =>
            {
                entity.HasKey(e => e.IdStatus);
            });
            modelBuilder.Entity<OrderStatusModel>().HasData(
                new OrderStatusModel 
                { 
                    IdStatus = 0,
                    NameStatus = "Новая",
                },
                new OrderStatusModel
                {
                    IdStatus = 0,
                    NameStatus = "Передано на выполнение",
                },
                new OrderStatusModel
                {
                    IdStatus = 0,
                    NameStatus = "Выполнено",
                },
                new OrderStatusModel
                {
                    IdStatus = 0,
                    NameStatus = "Отменена",
                }
            );

            // Справочник курьеров
            modelBuilder.Entity<CourierModel>(entity =>
            {
                entity.HasKey(e => e.IdCourier);
            });

            modelBuilder.Entity<CourierModel>().HasData(
                new CourierModel { IdCourier = 1, NameCourier = "Eren Yeager" },
                new CourierModel { IdCourier = 2, NameCourier = "Mikasa Ackerman" },
                new CourierModel { IdCourier = 3, NameCourier = "Armin Arlert" },
                new CourierModel { IdCourier = 4, NameCourier = "Levi Ackerman" },
                new CourierModel { IdCourier = 5, NameCourier = "Hange Zoë" },
                new CourierModel { IdCourier = 6, NameCourier = "Jean Kirstein" },
                new CourierModel { IdCourier = 7, NameCourier = "Connie Springer" },
                new CourierModel { IdCourier = 8, NameCourier = "Sasha Blouse" },
                new CourierModel { IdCourier = 9, NameCourier = "Historia Reiss" },
                new CourierModel { IdCourier = 10, NameCourier = "Reiner Braun" }
            );

            // Стартовые заявки
            modelBuilder.Entity<OrderModel>(entity =>
            {
                entity.HasKey(e => e.IdOrder);
            });

            modelBuilder.Entity<OrderModel>().HasData(
                new OrderModel
                {
                    IdOrder = 1,
                    NameClient = "Иванов Иван",
                    IdCourier = 1,
                    PickupAddress = "ул. Ленина, 10",
                    DeliveryAddress = "ул. Пушкина, 5",
                    PickupTime = DateTime.Now.AddHours(1),
                    IdStatus = 0,
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 2,
                    NameClient = "Петров Сергей",
                    IdCourier = 2,
                    PickupAddress = "пр. Мира, 23",
                    DeliveryAddress = "ул. Гоголя, 12",
                    PickupTime = DateTime.Now.AddHours(2),
                    IdStatus = 0,
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 3,
                    NameClient = "Смирнов Алексей",
                    IdCourier = 3,
                    PickupAddress = "ул. Советская, 15",
                    DeliveryAddress = "ул. Чехова, 8",
                    PickupTime = DateTime.Now.AddHours(3),
                    IdStatus = 0,
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 4,
                    NameClient = "Алексеева Ольга",
                    IdCourier = 4,
                    PickupAddress = "ул. Кирова, 7",
                    DeliveryAddress = "ул. Толстого, 20",
                    PickupTime = DateTime.Now.AddHours(4),
                    IdStatus = 0,
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 5,
                    NameClient = "Кузнецов Виктор",
                    IdCourier = 5,
                    PickupAddress = "ул. Бабушкина, 9",
                    DeliveryAddress = "ул. Некрасова, 3",
                    PickupTime = DateTime.Now.AddHours(5),
                    IdStatus = 0,
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 6,
                    NameClient = "Куликова Анна",
                    IdCourier = 6,
                    PickupAddress = "ул. Труда, 14",
                    DeliveryAddress = "ул. Островского, 6",
                    PickupTime = DateTime.Now.AddHours(6),
                    IdStatus = 0,
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 7,
                    NameClient = "Морозов Артем",
                    IdCourier = 7,
                    PickupAddress = "ул. Зои Космодемьянской, 18",
                    DeliveryAddress = "ул. Пирогова, 11",
                    PickupTime = DateTime.Now.AddHours(7),
                    IdStatus = 0,
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 8,
                    NameClient = "Фролова Татьяна",
                    IdCourier = 8,
                    PickupAddress = "ул. Победы, 22",
                    DeliveryAddress = "ул. Лермонтова, 13",
                    PickupTime = DateTime.Now.AddHours(8),
                    IdStatus = 0,
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 9,
                    NameClient = "Воробьева Светлана",
                    IdCourier = 9,
                    PickupAddress = "ул. Багратиона, 19",
                    DeliveryAddress = "ул. Тургенева, 2",
                    PickupTime = DateTime.Now.AddHours(9),
                    IdStatus = 0,
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 10,
                    NameClient = "Громов Михаил",
                    IdCourier = 10,
                    PickupAddress = "ул. Декабристов, 25",
                    DeliveryAddress = "ул. Горького, 17",
                    PickupTime = DateTime.Now.AddHours(10),
                    IdStatus = 0,
                    CancelReason = null
                }
            );
        }
    }
}
