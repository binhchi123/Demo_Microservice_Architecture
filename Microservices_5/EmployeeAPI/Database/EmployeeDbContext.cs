namespace EmployeeAPI.Database
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Employee>   Employees   { get; set; }
        public DbSet<Project>    Projects    { get; set; }
    }
}
