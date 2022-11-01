using Sales.Domain.Enums;

namespace Sales.Domain.Entities;

public class Sale
{
    public Guid Id { get; init; }
    public SaleStatus Status { get; private set; }
    public DateTime Date { get; set; }
    public List<SaleItem> Items { get; set; }
    public Seller Seller { get; set; }

    public Sale()
    {
        Status = SaleStatus.WaitingPayment;
        Items = new List<SaleItem>();
    }

    public void ApprovePayment()
    {
        if (Status != SaleStatus.WaitingPayment)
            throw new Exception("Não é possivel aprovar pagamento para venda que não está aguardando pagamento");

        Status = SaleStatus.PaymentApproved;
    }

    public void Cancel()
    {
        if (Status != SaleStatus.WaitingPayment && Status != SaleStatus.PaymentApproved)
            throw new Exception("Só é possível cancelar venda que esteja aguardando pagamento ou com pagamento aprovado");

        Status = SaleStatus.Canceled;
    }

    public void SendToCarrier()
    {
        if (Status != SaleStatus.PaymentApproved)
            throw new Exception("É necessário que o pagamento esteja aprovado para enviar para a transportadora");

        Status = SaleStatus.SentToCarrier;
    }

    public void Deliver()
    {
        if (Status != SaleStatus.SentToCarrier)
            throw new Exception("É necessário que o pedido esteja enviado para transportadora para que seja entregue");

        Status = SaleStatus.Delivered;
    }

    public void AddProduct(Product product)
    {
        Items.Add(new SaleItem()
        {
            Sale = this,
            Product = product,
            Value = product.Price
        });
    }
}
