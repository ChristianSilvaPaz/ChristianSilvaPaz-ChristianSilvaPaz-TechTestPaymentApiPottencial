using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces.Repositories;

public interface ISellerRepository
{
    Seller GetById(Guid id);

    List<Seller> Get();
}
