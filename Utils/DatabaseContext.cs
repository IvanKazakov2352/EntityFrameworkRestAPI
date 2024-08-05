using Microsoft.EntityFrameworkCore;
using TodoRestApi.interfaces;

namespace TodoRestApi.Utils
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Дополнительная конфигурация моделей (если необходимо)
            base.OnModelCreating(modelBuilder);

            // Например, настройка таблиц и отношений:
            modelBuilder.Entity<Todo>(entity =>
            {
                entity.ToTable("Todos"); // Указывает имя таблицы
                entity.HasKey(e => e.Id); // Указывает первичный ключ

                // Дополнительная настройка полей:
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.IsCompleted).IsRequired();
            });
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
