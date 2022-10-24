using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using Test.Web.Api.Context;
using Test.Web.Api.Model;
using System.Collections.Generic;
using System.Collections;
using Test.Web.Api.SupportFiles;
using Test.Web.Api.DTOs;
using Test.Web.Api.MapProfiles;

namespace Test.Web.Api.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _dbContext;
    private readonly DtoMapper _mapper;
    private DateTime Start;
    private TimeSpan TimeSpan;

    public ProductService(AppDbContext productContext)
    {
        _dbContext = productContext;
        _mapper = new DtoMapper();
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

    public async Task<List<ProductCategoryDto>> GetProductCategoriesAsync(CancellationToken cancellationToken)
    {
        var productCategories = await _dbContext.ProductCategory
            .Select(pc => _mapper.ProductCategoryToProductCategoryDto(pc))
            .ToListAsync();

        return productCategories;
    }

    public async Task<List<ProductDto>> GetProductsByCategoryAsync(Guid productCategoryId, CancellationToken cancellationToken)
    {
        Start = DateTime.Now;
        var products = await _dbContext.Product
            .Where(p => p.ProductCategory.Id == productCategoryId)
            .Include(p => p.ProductCategory)
            .Select(p => _mapper.ProductToProductDto(p))
            .ToListAsync();

        TimeSpan = DateTime.Now - Start;

        return products;
    }
}