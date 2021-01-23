using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Application.Domains;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.EF
{
    public class WatchContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<BillProm> BillProms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CodeProm> CodeProms { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<InfoShop> InfoShops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductProm> ProductProms { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<UnitTransport> UnitTransports { get; set; }
        public DbSet<Wire> Wires { get; set; }

        public WatchContext(DbContextOptions<WatchContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Address
            modelBuilder.Entity<Address>().Property(p => p.AddressStore).HasMaxLength(750);
            //Band
            modelBuilder.Entity<Band>().Property(p => p.Name).HasMaxLength(100);
            modelBuilder.Entity<Band>().Property(p => p.SeoImage).HasMaxLength(100);
            modelBuilder.Entity<Band>().Property(p => p.SeoTitle).HasMaxLength(150);
            modelBuilder.Entity<Band>().Property(p => p.SeoDescription).HasMaxLength(750);
            //Category
            modelBuilder.Entity<Category>().Property(p => p.Name).HasMaxLength(100);
            modelBuilder.Entity<Category>().Property(p => p.SeoImage).HasMaxLength(100);
            modelBuilder.Entity<Category>().Property(p => p.SeoTitle).HasMaxLength(150);
            modelBuilder.Entity<Category>().Property(p => p.SeoDescription).HasMaxLength(750);
            //coupon
            modelBuilder.Entity<CodeProm>().Property(p => p.CodeCoupon).HasMaxLength(100);
            //Wire
            modelBuilder.Entity<Wire>().Property(p => p.Name).HasMaxLength(100);
            //Fee
            modelBuilder.Entity<Fee>().Property(p => p.Name).HasMaxLength(100);
            //InfoShop
            modelBuilder.Entity<InfoShop>().Property(p => p.Name).HasMaxLength(100);
            modelBuilder.Entity<InfoShop>().Property(p => p.WorkTime).HasMaxLength(100);
            modelBuilder.Entity<InfoShop>().Property(p => p.Email).HasMaxLength(100);
            modelBuilder.Entity<InfoShop>().Property(p => p.SeoImage).HasMaxLength(100);
            modelBuilder.Entity<InfoShop>().Property(p => p.SeoTitle).HasMaxLength(150);
            modelBuilder.Entity<InfoShop>().Property(p => p.SeoDescription).HasMaxLength(750);
            //Social
            modelBuilder.Entity<Social>().Property(p => p.Name).HasMaxLength(150);
            modelBuilder.Entity<Social>().Property(p => p.Link).HasMaxLength(250);
            //Order
            modelBuilder.Entity<Order>().Property(o => o.Id).ValueGeneratedNever();
            modelBuilder.Entity<Order>().Property(o => o.DateCreated).HasColumnType("smalldatetime");
            modelBuilder.Entity<Order>().Property(o => o.CustomerName).HasMaxLength(250);
            modelBuilder.Entity<Order>().Property(o => o.CustomerPhone).HasMaxLength(50);
            modelBuilder.Entity<Order>().Property(o => o.CustomerProvince).HasMaxLength(100);
            modelBuilder.Entity<Order>().Property(o => o.CustomerEmail).HasMaxLength(150);
            modelBuilder.Entity<Order>().Property(o => o.CustomerAddress).HasMaxLength(500);
            modelBuilder.Entity<Order>().Property(o => o.Note).HasMaxLength(750);
            //OrderDetail
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });
            //OrderStatus
            modelBuilder.Entity<OrderStatus>().Property(o => o.DateChanged).HasColumnType("smalldatetime");
            //Phone
            modelBuilder.Entity<Phone>().Property(p => p.PhoneNumber).HasMaxLength(50);
            //Product
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(250);
            modelBuilder.Entity<Product>().Property(p => p.Image).HasMaxLength(150);
            modelBuilder.Entity<Product>().Property(p => p.isDel).HasDefaultValue(false);
            modelBuilder.Entity<Product>().Property(p => p.isShow).HasDefaultValue(true);
            //ProductDetail
            modelBuilder.Entity<ProductDetail>().Property(p => p.TypeGlass).HasMaxLength(250);
            modelBuilder.Entity<ProductDetail>().Property(p => p.TypeBorder).HasMaxLength(250);
            modelBuilder.Entity<ProductDetail>().Property(p => p.TypeMachine).HasMaxLength(250);
            modelBuilder.Entity<ProductDetail>().Property(p => p.Parameter).HasMaxLength(250);
            modelBuilder.Entity<ProductDetail>().Property(p => p.ResistWater).HasMaxLength(250);
            modelBuilder.Entity<ProductDetail>().Property(p => p.Warranty).HasMaxLength(250);
            modelBuilder.Entity<ProductDetail>().Property(p => p.Origin).HasMaxLength(250);
            modelBuilder.Entity<ProductDetail>().Property(p => p.Color).HasMaxLength(250);
            modelBuilder.Entity<ProductDetail>().Property(p => p.Func).HasMaxLength(500);
            modelBuilder.Entity<ProductDetail>().Property(p => p.SeoTitle).HasMaxLength(250);
            modelBuilder.Entity<ProductDetail>().Property(p => p.SeoDescription).HasMaxLength(750);
            //Config Promotion
            modelBuilder.Entity<Promotion>().Property(p => p.ToDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Promotion>().Property(p => p.FromDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Promotion>().Property(p => p.isShow).HasDefaultValue(true);
            modelBuilder.Entity<Promotion>().Property(p => p.isAlways).HasDefaultValue(false);
            //Config ProductProm
            modelBuilder.Entity<ProductProm>().Property(p => p.ProductIds).HasMaxLength(250);
            //Config ProductProm
            //Tranport
            modelBuilder.Entity<UnitTransport>().Property(p => p.Name).HasMaxLength(150);
            //Identity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }
    }
}