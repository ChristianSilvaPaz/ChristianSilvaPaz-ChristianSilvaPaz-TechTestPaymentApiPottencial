using Sales.Domain.Entities;
using Sales.Domain.Interfaces.Repositories;

namespace Sales.Domain.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> GetProduct()
    {
        return _productRepository.Get();
    }
}
