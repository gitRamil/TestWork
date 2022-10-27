using System;
using JWTService.Model;

namespace JWTService.SupportFiles;

public static class CreateDbData
{
    public static List<User> CreateUsers(int count, List<User> productCategories)
    {
        var random = new Random();
        List<User> products = new();

        for (int i = 0; i < count; i++)
        {
            int index = random.Next(productCategories.Count);

            products.Add(new User()
            {
                Id = Guid.NewGuid(),
                Username = "product: " + i,
                Password = "code " + i,
            });
        }

        return products;
    }
}