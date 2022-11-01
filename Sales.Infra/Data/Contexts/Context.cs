using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;

namespace Sales.Infra.Data.Contexts;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>();
        modelBuilder.Entity<SaleItem>();
        modelBuilder.Entity<User>().HasData(new User() { Id = new Guid("0dd0e40dceb64b35b4130ca6efb3332d"), Username = "string", Password = "string" });

        modelBuilder.Entity<Seller>().HasData(new Seller()
        {
            Id = new Guid("0dd0e40dceb64b35b4130ca6efb3332d"),
            DocumentNumber = "12345678910",
            Name = "Christian",
            Email = "teste@teste.com",
            PhoneNumber = "(38)98877-6655"
        });

        modelBuilder.Entity<Seller>().HasData(new Seller()
        {
            Id = new Guid("cf7c87b3-07c4-4c02-b0f8-b945b2afbb8c"),
            DocumentNumber = "32165498701",
            Name = "Hercules",
            Email = "teste1@teste1.com",
            PhoneNumber = "(38)95577-8875"
        });

        modelBuilder.Entity<Product>().HasData(new Product() { Id = new Guid("0dd0e40dceb64b35b4130ca6efb3332d"), Name = "Rider IDE", Price = 925.32m });
        modelBuilder.Entity<Product>().HasData(new Product() { Id = new Guid("cf7c87b3-07c4-4c02-b0f8-b945b2afbb8c"), Name = "Flleet IDE", Price = 5m });
        modelBuilder.Entity<Product>().HasData(new Product() { Id = new Guid("6a145330-2c6e-4c9b-90f4-61ace8ee5d9c"), Name = "Visual Studio IDE", Price = 800.25m });
    }
}
