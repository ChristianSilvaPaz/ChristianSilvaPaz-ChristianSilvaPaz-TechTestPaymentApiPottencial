using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces.Repositories;

public interface IProductRepository
{
    List<Product> GetByIdList(List<Guid> ids);

    List<Product> Get();
}
