using Sales.Domain.Entities;
using Sales.Domain.Interfaces.Repositories;
using Sales.Infra.Data.Contexts;

namespace Sales.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly Context _context;

    public ProductRepository(Context context)
    {
        _context = context;
    }

    public List<Product> GetByIdList(List<Guid> ids)
    {
        return _context.Set<Product>().Where(p => ids.Any(i => i == p.Id)).ToList();
    }

    public List<Product> Get()
    {
        var products = _context.Set<Product>().ToList();
        return products;
    }
}
