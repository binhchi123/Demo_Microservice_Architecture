namespace DishAPI.Application.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category>   Categories  { get; set; }
    public virtual DbSet<Dish>       Dishes      { get; set; }
    public virtual DbSet<Ingredient> Ingredients { get; set; }
    public virtual DbSet<Recipe>     Recipes     { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=test1; Password=123456;Data Source=localhost:1521/mypdb;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("TEST1")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.LoaiMonAnId).HasName("SYS_C007786");

            entity.ToTable("CATEGORIES");

            entity.Property(e => e.LoaiMonAnId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("LOAIMONANID");
            entity.Property(e => e.TenLoai)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TENLOAI");
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.MonAnId).HasName("SYS_C007790");

            entity.ToTable("DISHES");

            entity.Property(e => e.MonAnId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("MONANID");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GHICHU");
            entity.Property(e => e.LoaiMonAnId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("LOAIMONANID");
            entity.Property(e => e.TenMon)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TENMON");

            entity.HasOne(d => d.Category).WithMany(p => p.Dishes)
                .HasForeignKey(d => d.LoaiMonAnId)
                .HasConstraintName("SYS_C007791");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.NguyenLieuId).HasName("SYS_C007788");

            entity.ToTable("INGREDIENTS");

            entity.Property(e => e.NguyenLieuId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NGUYENLIEUID");
            entity.Property(e => e.TenNguyenLieu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TENNGUYENLIEU");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.CongThucId).HasName("SYS_C007793");

            entity.ToTable("RECIPES");

            entity.Property(e => e.CongThucId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CONGTHUCID");
            entity.Property(e => e.DonViTinh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DONVITINH");
            entity.Property(e => e.MonAnId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("MONANID");
            entity.Property(e => e.NguyenLieuId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NGUYENLIEUID");
            entity.Property(e => e.SoLuong)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SOLUONG");

            entity.HasOne(d => d.Dish).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.MonAnId)
                .HasConstraintName("SYS_C007794");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.NguyenLieuId)
                .HasConstraintName("SYS_C007795");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
