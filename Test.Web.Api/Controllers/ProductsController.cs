using Microsoft.AspNetCore.Mvc;
using Test.Web.Api.DTOs;
using Test.Web.Api.Services;

namespace Test.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;
    private const int _productCountDefault = 1000000;
    private const int _productCategoryCountDefault = 50;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<ActionResult> AddDataAsync(CancellationToken cancellationToken,
        int productCount = _productCountDefault,
        int productCategoriesCount = _productCategoryCountDefault)
    {
        var result = await _service.AddDataAsync(productCount, productCategoriesCount, cancellationToken);

        return Ok(result);
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<ActionResult<List<ProductCategoryDto>>> GetProductCategoriesAsync(CancellationToken cancellationToken)
    {
        var result = await _service.GetProductCategoriesAsync(cancellationToken);

        return Ok(result);
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetProductsByCategoryAsync(Guid productCategoryId, CancellationToken cancellationToken)
    {
        var result = await _service.GetProductsByCategoryAsync(productCategoryId, cancellationToken);

        return Ok(result);
    }
}