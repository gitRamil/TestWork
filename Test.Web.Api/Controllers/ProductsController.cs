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

    [HttpPost]
    public async Task<ActionResult> AddDataAsync(int productCounts, CancellationToken cancellationToken)
    {
        var result = await _service.AddDataAsync(productCounts, cancellationToken);

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> GetProductsAsync(CancellationToken cancellationToken)
    {
        var result = await _service.GetProductsAsync(cancellationToken);

        return Ok(result);
    }
}