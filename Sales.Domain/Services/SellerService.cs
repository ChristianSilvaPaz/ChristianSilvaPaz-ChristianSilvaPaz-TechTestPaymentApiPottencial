using Sales.Domain.Entities;
using Sales.Domain.Interfaces.Repositories;

namespace Sales.Domain.Services;

public class SellerService
{
    private readonly ISellerRepository _sellerRepository;

    public SellerService(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public List<Seller> GetSellers()
    {
        return _sellerRepository.Get();
    }
}
