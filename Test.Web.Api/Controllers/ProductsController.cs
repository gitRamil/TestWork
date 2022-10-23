using System.Net.Mime;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Test.Web.Api.Context;
using Test.Web.Api.Services;

namespace Test.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<ActionResult> AddDataAsync(int productCount, int productCategoriesCount, CancellationToken cancellationToken)
    {
        var result = await _service.AddDataAsync(productCount, productCategoriesCount, cancellationToken);

        return Ok(result);
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<ActionResult> GetProductCategoriesAsync(CancellationToken cancellationToken)
    {
        var result = await _service.GetProductCategoriesAsync(cancellationToken);

        return Ok(result);
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<ActionResult> GetProductsAsync(CancellationToken cancellationToken)
    {
        var result = await _service.GetProductsAsync(cancellationToken);

        return Ok(result);
    }
}