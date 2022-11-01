namespace Sales.Domain.Entities;

public class Seller
{
    public Guid Id { get; init; }
    public string DocumentNumber { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string PhoneNumber { get; init; }
}
