using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesCostProvider.Models.DB;

namespace SalesCostProvider.DB
{
    public class CostProviderDbContext : DbContext
    {
        IConfiguration Configuration { get; set; }
        public CostProviderDbContext(IConfiguration configuration) : base()
        {
            Configuration = configuration;
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("CostProviderDbConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductIn>(entity =>
            entity.ToTable("ProductIn"));

            modelBuilder.Entity<ProductIn>()
            .HasKey(b => b.Id);

            modelBuilder.Entity<ProductOut>()
            .HasKey(b => b.Id);

            modelBuilder.Entity<ProductOut>()
            .HasIndex(u => u.Id)
            .IsUnique();
            
            modelBuilder.Entity<ProductIn>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd();


            modelBuilder.Entity<ProductOut>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProductOut>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<InComeModel>(entity =>
            entity.ToTable("InComeModel"));

            modelBuilder.Entity<InComeModel>()
            .HasKey(b => b.Id);

            modelBuilder.Entity<InComeModel>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<InComeModel>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<ResultModel>(entity =>
            entity.ToTable("ResultModel"));

            modelBuilder.Entity<ResultModel>()
            .HasKey(b => b.Id);

            modelBuilder.Entity<ResultModel>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<ResultModel>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd();

        }

        public DbSet<ProductIn> IN_Products { get; set; }
        public DbSet<ProductOut> OUT_Produtcts { get; set; }

        public DbSet<InComeModel> IncomeModels { get; set; }
        public DbSet<ResultModel> ResultModels { get; set; }
    }
}
