using Sales.Domain.Entities;
using Sales.Domain.Enums;
using Sales.Domain.Result;
using Sales.Domain.Services.Models;

namespace Sales.Domain.Interfaces.Services;

public interface ISaleService
{
    ServiceResult<Sale> AddSale(SaleCreateModel model);
    Task<ServiceResult<Sale>> GetSale(Guid id);
    Task<ServiceResult<Sale>> UpdateSaleStatus(Guid id, SaleStatus status);
}
