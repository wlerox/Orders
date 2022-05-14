using Bogus;
using Microsoft.EntityFrameworkCore;
using Order.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var product = new Faker<ProductEntity>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Category, f => f.Commerce.Categories(1).First())
                .RuleFor(p => p.Unit, f => f.Random.Int(5, 100))
                .RuleFor(p => p.UnitPrice, f => f.Commerce.Price(1).First())
                .RuleFor(p => p.Status, f => f.Random.Int(0, 1))
                .RuleFor(p => p.CreateDate, f => f.Date.PastOffset().DateTime)
                .RuleFor(p => p.UpdateDate, f => f.Date.PastOffset().DateTime);

            modelBuilder.Entity<ProductEntity>().HasData(product.GenerateBetween(10,20));
        }
    }
}
