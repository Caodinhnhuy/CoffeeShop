using System.Collections.Generic;

namespace coffeeshop.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product? GetProductDetail(int id);
        IEnumerable<Product> GetTrendingProducts();
    }
}
