using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces.Repositories;
using Sales.Infra.Data.Contexts;

namespace Sales.Infra.Data.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly Context _context;

    public SaleRepository(Context context)
    {
        _context = context;
    }

    public Sale Add(Sale sale)
    {
        _context.Add(sale);
        _context.SaveChanges();
        return sale;
    }

    public async Task<Sale> GetById(Guid id)
    {
        return await _context.Set<Sale>().Include(s => s.Seller)
            .Include(s => s.Items)
            .Where(s => s.Id == id).FirstOrDefaultAsync();
    }

    public Sale Update(Sale sale)
    {
        _context.Update(sale);
        _context.SaveChanges();
        return sale;
    }
}
