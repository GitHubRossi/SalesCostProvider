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
            ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("CostProviderDbConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InProduct>(entity =>
            entity.ToTable("IN_Products").Property(typeof(long), "Id").ValueGeneratedOnAdd());
            modelBuilder.Entity<InProduct>(entity =>
            entity.HasIndex("Id"));
            modelBuilder.Entity<InProduct>().HasOne(p => p.InComeModelId)
            .WithMany(b => b.Products);

            modelBuilder.Entity<OutProduct>(entity =>
            entity.ToTable("OUT_Products").Property(typeof(long), "Id").ValueGeneratedOnAdd());
            modelBuilder.Entity<OutProduct>(entity =>
             entity.HasIndex("Id"));
            modelBuilder.Entity<OutProduct>().HasOne(p => p.OutModelId)
            .WithMany(b => b.ProductsOut);

            modelBuilder.Entity<OutModel>(entity =>
            entity.ToTable("OUT_Models").Property(typeof(long), "Id").ValueGeneratedOnAdd());
            modelBuilder.Entity<OutModel>(entity =>
            entity.HasIndex("Id"));


            modelBuilder.Entity<InComeModel>(entity =>
            entity.ToTable("IN_Models").Property(typeof(long), "Id").ValueGeneratedOnAdd());
            modelBuilder.Entity<InComeModel>(entity =>
            entity.HasIndex("Id"));
        }

        public DbSet<InProduct> IN_Products { get; set; }
        public DbSet<OutProduct> OUT_Produtcts { get; set; }

        public DbSet<InComeModel> IN_Models { get; set; }
        public DbSet<OutModel> OUT_Models { get; set; }
    }
}
