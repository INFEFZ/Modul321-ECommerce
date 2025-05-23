using ProductService.Models;

namespace ProductService.Services
{
    public interface IProductService
    {
        Task Create(Product Product);
        Task Delete(Product Product);
        Task<Product> GetById(int ProductId);
        IEnumerable<Product> GetProducts();
        Task Update(Product Product);
    }
}