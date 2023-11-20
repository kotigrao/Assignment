using Assignment.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vantlogix.Domain.Products;

namespace Assignment.Infrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; internal set; }
        //public void Configure(EntityTypeBuilder<Product> builder)
        //{
        //    builder.HasKey(p => p.Id);
        //    builder.Property(p => p.Id).HasConversion(
        //        productId => productId.Value,
        //        value => new ProductId(value));
        //    builder.Property(p => p.StockUnit).HasConversion(
        //        stockUnit => stockUnit.Value,
        //        value => StockUnit.Create(value)!);
        //    builder.OwnsOne(p => p.Price, priceBuilder =>
        //    {
        //        priceBuilder.Property(m => m.Currency).HasMaxLength(3);
        //    });
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
