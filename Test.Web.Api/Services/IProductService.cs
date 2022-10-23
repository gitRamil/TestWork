using System;
using Microsoft.AspNetCore.Mvc;
using Test.Web.Api.Model;

namespace Test.Web.Api.Services;

public interface IProductService
{
    Task<TimeSpan> AddDataAsync(int productsCount, int productCategories, CancellationToken cancellationToken);

    Task<List<ProductCategory>> GetProductCategoriesAsync(CancellationToken cancellationToken);

    Task<List<Product>> GetProductsByCategoryAsync(Guid productCategoryId, CancellationToken cancellationToken);
}