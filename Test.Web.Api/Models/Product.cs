using System;

namespace Test.Web.Api.Model;

public class Product : BaseAuditEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string Code { get; set; }

    public ProductCategory? ProductCategory { get; set; }
}