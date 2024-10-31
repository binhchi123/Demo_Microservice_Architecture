namespace DishAPI.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base (options)
        {
            
        }

        public DbSet<Category>   Categories  { get; set; }
        public DbSet<Dish>       Dishes      { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe>     Recipes     { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình bảng Category
            modelBuilder.Entity<Category>()
                .HasKey(c => c.LoaiMonAnId);

            // Cấu hình bảng Dish
            modelBuilder.Entity<Dish>()
                .HasKey(d => d.MonAnId);

            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Category)
                .WithMany(c => c.Dishes)
                .HasForeignKey(d => d.LoaiMonAnId)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình bảng Recipe
            modelBuilder.Entity<Recipe>()
                .HasKey(r => r.CongThucId);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Dish)
                .WithMany(d => d.Recipes)
                .HasForeignKey(r => r.MonAnId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Ingredient)
                .WithMany(i => i.Recipes)
                .HasForeignKey(r => r.NguyenLieuId)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình bảng Ingredient
            modelBuilder.Entity<Ingredient>()
                .HasKey(i => i.NguyenLieuId);
        }

    }
}
