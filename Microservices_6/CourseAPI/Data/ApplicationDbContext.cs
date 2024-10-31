namespace CourseAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(){}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Course>    Courses { get; set; }
        public DbSet<CourseDay> CoursesDays { get; set; }
        public DbSet<Student>   Students { get; set; }
    }
}
