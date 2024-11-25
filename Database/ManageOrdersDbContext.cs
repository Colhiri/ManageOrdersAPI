using Microsoft.EntityFrameworkCore;

namespace ManageOrdersAPI.Database
{
    public class ManageOrdersDbContext : DbContext
    {
        public DbSet<OrderModel> Orders { get; set; }
        public ManageOrdersDbContext(DbContextOptions<ManageOrdersDbContext> options) : base(options) 
        {
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

            modelBuilder.Entity<OrderModel>(entity =>
            {
                entity.HasKey(e => e.IdOrder);
            });

            modelBuilder.Entity<OrderModel>().HasData(
                new OrderModel
                {
                    IdOrder = 1,
                    NameClient = "Иванов Иван",
                    NameExecutor = "Сидоров Петр",
                    PickupAddress = "ул. Ленина, 10",
                    DeliveryAddress = "ул. Пушкина, 5",
                    PickupTime = DateTime.Now.AddHours(1),
                    Status = "Новая",
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 2,
                    NameClient = "Петров Сергей",
                    NameExecutor = "Иванов Андрей",
                    PickupAddress = "пр. Мира, 23",
                    DeliveryAddress = "ул. Гоголя, 12",
                    PickupTime = DateTime.Now.AddHours(2),
                    Status = "Новая",
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 3,
                    NameClient = "Смирнов Алексей",
                    NameExecutor = "Михайлов Игорь",
                    PickupAddress = "ул. Советская, 15",
                    DeliveryAddress = "ул. Чехова, 8",
                    PickupTime = DateTime.Now.AddHours(3),
                    Status = "Новая",
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 4,
                    NameClient = "Алексеева Ольга",
                    NameExecutor = "Николаев Виталий",
                    PickupAddress = "ул. Кирова, 7",
                    DeliveryAddress = "ул. Толстого, 20",
                    PickupTime = DateTime.Now.AddHours(4),
                    Status = "Новая",
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 5,
                    NameClient = "Кузнецов Виктор",
                    NameExecutor = "Павлов Дмитрий",
                    PickupAddress = "ул. Бабушкина, 9",
                    DeliveryAddress = "ул. Некрасова, 3",
                    PickupTime = DateTime.Now.AddHours(5),
                    Status = "Новая",
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 6,
                    NameClient = "Куликова Анна",
                    NameExecutor = "Егоров Максим",
                    PickupAddress = "ул. Труда, 14",
                    DeliveryAddress = "ул. Островского, 6",
                    PickupTime = DateTime.Now.AddHours(6),
                    Status = "Новая",
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 7,
                    NameClient = "Морозов Артем",
                    NameExecutor = "Лебедев Денис",
                    PickupAddress = "ул. Зои Космодемьянской, 18",
                    DeliveryAddress = "ул. Пирогова, 11",
                    PickupTime = DateTime.Now.AddHours(7),
                    Status = "Новая",
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 8,
                    NameClient = "Фролова Татьяна",
                    NameExecutor = "Григорьев Олег",
                    PickupAddress = "ул. Победы, 22",
                    DeliveryAddress = "ул. Лермонтова, 13",
                    PickupTime = DateTime.Now.AddHours(8),
                    Status = "Новая",
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 9,
                    NameClient = "Воробьева Светлана",
                    NameExecutor = "Данилов Александр",
                    PickupAddress = "ул. Багратиона, 19",
                    DeliveryAddress = "ул. Тургенева, 2",
                    PickupTime = DateTime.Now.AddHours(9),
                    Status = "Новая",
                    CancelReason = null
                },
                new OrderModel
                {
                    IdOrder = 10,
                    NameClient = "Громов Михаил",
                    NameExecutor = "Романов Артем",
                    PickupAddress = "ул. Декабристов, 25",
                    DeliveryAddress = "ул. Горького, 17",
                    PickupTime = DateTime.Now.AddHours(10),
                    Status = "Новая",
                    CancelReason = null
                }
            );
        }
    }
}
