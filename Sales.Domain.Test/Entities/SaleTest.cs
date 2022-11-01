using Sales.Domain.Entities;
using Sales.Domain.Enums;
using Xunit;

namespace Sales.Domain.Test.Entities;

public class SaleTest
{
    [Fact]
    public void ApprovePayment_ShouldChangeStatusToPaymentApprovedWhenCurrentStatusEqualsWaitingPayment()
    {
        //Arrange
        var sale = new Sale();
        var initialStatus = sale.Status;

        //Act
        sale.ApprovePayment();

        //Assert
        Assert.Equal(SaleStatus.WaitingPayment, initialStatus);
        Assert.Equal(sale.Status, SaleStatus.PaymentApproved);
    }

    [Fact]
    public void ApprovePayment_ShouldThrowExceptionWhenInitialStatusIsDifferentFromWaitingPayment()
    {
        //Arrange
        var sale = new Sale();
        sale.Cancel(); //Changed sale status to cancelled to test ApprovePayment() exception
        var initialStatus = sale.Status;

        //Act
        var action = () => sale.ApprovePayment();

        //Assert
        Assert.NotEqual(SaleStatus.WaitingPayment, initialStatus);
        Assert.Throws<Exception>(action);
    }
}
