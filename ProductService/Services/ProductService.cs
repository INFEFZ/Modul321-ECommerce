using ProductService.Models;

namespace ProductService.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _productDbContext;

        public ProductService(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _productDbContext.Products;
        }

        public async Task Create(Product Product)
        {
            await _productDbContext.Products.AddAsync(Product);
            await _productDbContext.SaveChangesAsync();
        }

        public async Task Delete(Product Product)
        {
            _productDbContext.Products.Remove(Product);
            await _productDbContext.SaveChangesAsync();
        }

        public async Task<Product> GetById(int ProductId)
        {
            var Product = await _productDbContext.Products.FindAsync(ProductId);
            if (Product == null)
            {
                throw new Exception("Product not found");
            }

            return Product;
        }

        public async Task Update(Product Product)
        {
            _productDbContext.Products.Update(Product);
            await _productDbContext.SaveChangesAsync();
        }
    }
}
