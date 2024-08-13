using Microsoft.EntityFrameworkCore;
using Menu.Models;
namespace Menu.Data
{
    public class MenuContext: DbContext 
    {
        public MenuContext(DbContextOptions<MenuContext> options ): base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredeint>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId

            });
            modelBuilder.Entity<DishIngredeint>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            
            modelBuilder.Entity<DishIngredeint>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Margharita", Price = 7.50, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSBh7r03auo3jtjlp5ApGFtpMh30-b1FaEPVA&s" });
            modelBuilder.Entity<Ingredients>().HasData(new Ingredients 
            {Id= 1, Name="Tomato Sauce " },
            { Id = 2, Name = "Mozarella" }
            );
            modelBuilder.Entity<DishIngredeint>().HasData(
                new DishIngredeint { DishId = 1, IngredientId = 1 },
                new DishIngredeint { DishId = 2, IngredientId = 2 }
                );

                base.OnModelCreating(modelBuilder);
        
        }
 public DbSet<Dish> Dishes
            { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<DishIngredeint> DishIngredeints { get; set; }

    }
}
