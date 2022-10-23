using System;
using Test.Web.Api.Model;

namespace Test.Web.Api.SupportFiles;

public static class CreateDbData
{
    public static List<Product> CreateProducts(int count, List<ProductCategory> productCategories)
    {
        var random = new Random();
        List<Product> products = new();

        for (int i = 0; i < count; i++)
        {
            int index = random.Next(productCategories.Count);

            products.Add(new Product()
            {
                Id = Guid.NewGuid(),
                Name = "product: " + i,
                Code = "code " + i,
                Description = "description " + i,
                Price = i + 100,
                ProductCategory = productCategories[index],
            });
        }

        return products;
    }

    public static List<ProductCategory> CreateProductCategories(int count)
    {
        List<ProductCategory> productCategory = new();

        for (int i = 0; i < count; i++)
        {
            productCategory.Add(new ProductCategory()
            {
                Id = Guid.NewGuid(),
                Name = "ProductCategory: " + i,
            });
        }

        return productCategory;
    }
}