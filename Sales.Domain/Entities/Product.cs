namespace Sales.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}
