using Combine.Api.Models;

namespace Combine.Api.Features
{
    public static class ProductExtensions
    {
        public static ProductDto ToDto(this Product product)
        {
            return new()
            {
                ProductId = product.ProductId,
                Name = product.Name
            };
        }
    }
}
