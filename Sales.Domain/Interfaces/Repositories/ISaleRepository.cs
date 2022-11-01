using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces.Repositories;

public interface ISaleRepository
{
    Task<Sale> GetById(Guid id);
    Sale Add(Sale sale);
    Sale Update(Sale sale);
}
