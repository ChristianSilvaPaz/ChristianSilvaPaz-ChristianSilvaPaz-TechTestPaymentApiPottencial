using Sales.Domain.Entities;
using Sales.Domain.Interfaces.Repositories;
using Sales.Infra.Data.Contexts;

namespace Sales.Infra.Data.Repositories;

public class SellerRepository : ISellerRepository
{
    private readonly Context _context;

    public SellerRepository(Context context)
    {
        _context = context;
    }

    public Seller GetById(Guid id)
    {
        return _context.Set<Seller>().Where(s => s.Id == id).FirstOrDefault();
    }

    public List<Seller> Get()
    {
        return _context.Set<Seller>().ToList();
    }

}
