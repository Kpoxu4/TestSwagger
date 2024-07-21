using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestSwaggerData.DataModel;

namespace TestSwaggerData
{
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Priority> Priorities { get; set; }



#if DEBUG
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Database=TestSwagger");
        }
#else
        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                            .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
#endif


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>(entity =>
            {
                entity.HasOne(x => x.Priority)
                      .WithMany(x => x.ToDoItems)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.User)
                      .WithMany(x => x.ToDoItems)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
