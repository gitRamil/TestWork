using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using Test.Web.Api.Context;
using Test.Web.Api.Model;
using System.Collections.Generic;
using System.Collections;
using Test.Web.Api.SupportFiles;

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

    public async Task<TimeSpan> AddDataAsync(int productCount, int categoriesCount, CancellationToken cancellationToken)
    {
        Start = DateTime.Now;
        var productCategories = CreateDbData.CreateProductCategories(categoriesCount);
        var products = CreateDbData.CreateProducts(productCount, productCategories);

        await _dbContext.BulkInsertAsync(productCategories);
        await _dbContext.BulkInsertAsync(products);
        TimeSpan = DateTime.Now - Start;

        return TimeSpan;
    }

    public async Task<List<ProductCategory>> GetProductCategoriesAsync(CancellationToken cancellationToken)
    {
        var productCategories = await _dbContext.ProductCategory.ToListAsync();

        return productCategories;
    }

    public async Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken)
    {
        Start = DateTime.Now;
        var products = await _dbContext.Product.ToListAsync();

        TimeSpan = DateTime.Now - Start;

        return products;
    }
}