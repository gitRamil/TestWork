using Test.Web.Api.DTOs;

namespace Test.Web.Api.Services;

public interface IProductService
{
    Task<TimeSpan> AddDataAsync(int productsCount, int productCategories, CancellationToken cancellationToken);

    Task<List<ProductCategoryDto>> GetProductCategoriesAsync(CancellationToken cancellationToken);

    Task<List<ProductDto>> GetProductsByCategoryAsync(Guid productCategoryId, CancellationToken cancellationToken);
}