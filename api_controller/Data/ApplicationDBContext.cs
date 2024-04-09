using api_controller.Models;
using Microsoft.EntityFrameworkCore;

namespace api_controller.Data
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
    {
        public DbSet<Floor> Floors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //data seeding

            modelBuilder.Entity<Floor>().HasData(
                            new Floor { FloorId = 12, FloorName = "Laminate", FloorColor = "Beige", FloorDescription = "Beige Laminate Floor", Price = 1.53 },
                            new Floor { FloorId = 15, FloorName = "Cork", FloorColor = "Brown", FloorDescription = "Brown Cork Floor", Price = 2.10 },
                            new Floor { FloorId = 18, FloorName = "Leather", FloorColor = "Black", FloorDescription = "Black Leather Floor", Price = 4.53 },
                            new Floor { FloorId = 19, FloorName = "Wood", FloorColor = "Green", FloorDescription = "Green Wood Floor", Price = 2.99 },
                            new Floor { FloorId = 21, FloorName = "Polycarbonate", FloorColor = "Clear", FloorDescription = "Clear Polycarbonate Floor", Price = 0.95 }
            );
        }
    }
}
