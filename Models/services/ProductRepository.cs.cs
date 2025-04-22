using coffeeshop.Models.Interfaces;

namespace coffeeshop.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> productsList = new List<Product>()
        {
            new Product { Id = 1, Name = "Americano", Price = 25, Detail = "Strong coffee", ImageUrl = "https://via.placeholder.com/100" },
            new Product { Id = 2, Name = "Latte", Price = 30, Detail = "Smooth milk coffee", ImageUrl = "https://via.placeholder.com/100" },
            new Product { Id = 3, Name = "Espresso", Price = 20, Detail = "Short black coffee", ImageUrl = "https://via.placeholder.com/100" }
        };

        public IEnumerable<Product> GetAllProducts() => productsList;

        public Product? GetProductDetail(int id) =>
            productsList.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Product> GetTrendingProducts() =>
            productsList.Where(p => p.IsTrendingProduct);
    }
}
