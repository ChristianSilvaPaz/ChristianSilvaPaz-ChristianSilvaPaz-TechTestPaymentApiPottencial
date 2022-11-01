using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Sales.Controllers;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces.Services;
using Sales.Domain.Result;
using Xunit;

namespace Sales.Api.Test.Controller;

public class SaleControllerTest
{
    private readonly ISaleService _saleService = Substitute.For<ISaleService>();
    private readonly SaleController _saleController;
   
    public SaleControllerTest()
    {
        _saleController = new SaleController(_saleService);
    }

    [Fact]
    public async Task GetSale_ShouldReturnSale()
    {
        //Arrange
        _saleService.GetSale(new Guid()).Returns(new ServiceResult<Sale>(new Sale()));

        //Act
        var result = await _saleController.GetSale(new Guid());

        //Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetSale_ShouldNotReturnSale()
    {
        //Arrange
        var serviceResult = new ServiceResult<Sale>();
        serviceResult.AddError("", "teste");
        _saleService.GetSale(new Guid()).Returns(serviceResult);

       //Act
        var result = await _saleController.GetSale(new Guid());

       //Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }
}
