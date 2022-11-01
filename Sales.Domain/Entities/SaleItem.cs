namespace Sales.Domain.Entities;

public class SaleItem
{
    public Guid Id { get; set; }
    public Sale Sale { get; set; }
    public Product Product { get; set; }
    public decimal Value { get; set; }
}
