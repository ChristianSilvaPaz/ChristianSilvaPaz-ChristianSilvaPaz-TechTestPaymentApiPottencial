namespace Sales.Domain.Enums
{
    public enum SaleStatus
    {
        WaitingPayment = 1,
        PaymentApproved,
        SentToCarrier,
        Delivered,
        Canceled
    }
}
