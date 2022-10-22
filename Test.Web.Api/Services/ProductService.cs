using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using Test.Web.Api.Context;
using Test.Web.Api.Model;

namespace Test.Web.Api.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _dbContext;
    private DateTime Start;
    private TimeSpan TimeSpan;

    public ProductService(AppDbContext productContext)
    {
        _dbContext = productContext;
    }

    public async Task<TimeSpan> AddDataAsync(int count, CancellationToken cancellationToken)
    {
        List<Product> products = new();
        Start = DateTime.Now;

        for (int i = 0; i < count; i++)
        {
            Guid g = Guid.NewGuid();
            products.Add(new Product()
            {
                Id = g,
                Name = "Employee_" + i
            });
        }

        await _dbContext.BulkInsertAsync(products);
        TimeSpan = DateTime.Now - Start;

        return TimeSpan;
    }

    public async Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken)
    {
        Start = DateTime.Now;
        var products = await _dbContext.Product.ToListAsync();

        TimeSpan = DateTime.Now - Start;

        return products;
    }
}