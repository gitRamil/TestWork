using Riok.Mapperly.Abstractions;
using Test.Web.Api.DTOs;
using Test.Web.Api.Model;

namespace Test.Web.Api.MapProfiles
{
    [Mapper]
    public partial class DtoMapper
    {
        public partial ProductCategoryDto ProductCategoryToProductCategoryDto(ProductCategory item);

        public partial ProductDto ProductToProductDto(Product item);
    }
}