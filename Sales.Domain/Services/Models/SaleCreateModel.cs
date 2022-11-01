namespace Sales.Domain.Services.Models;

public class SaleCreateModel
{
    public Guid SellerId { get; init; }
    public List<Guid> ProductIds { get; init; }
}
