using System;
using Microsoft.AspNetCore.Mvc;
using Test.Web.Api.Model;

namespace Test.Web.Api.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken);

    Task<TimeSpan> AddDataAsync(int count, CancellationToken cancellationToken);
}