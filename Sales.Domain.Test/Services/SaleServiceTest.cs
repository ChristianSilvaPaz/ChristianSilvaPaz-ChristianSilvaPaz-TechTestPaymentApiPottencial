using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces.Repositories;
using Sales.Domain.Services;
using Xunit;

namespace Sales.Domain.Test.Services;

public class SaleServiceTest
{
    private readonly SaleService _saleService;
    private readonly ISellerRepository _sellerRepository = Substitute.For<ISellerRepository>();
    private readonly ISaleRepository _saleRepository = Substitute.For<ISaleRepository>();
    private readonly IProductRepository _productRepository = Substitute.For<IProductRepository>();

    public SaleServiceTest()
    {
        _saleService = new SaleService(_sellerRepository, _productRepository, _saleRepository);
    }

    [Fact]
    public async Task GetSale_ShouldReturnSale()
    {
        //Arrange
        var saleId = new Guid();
        _saleRepository.GetById(saleId).Returns(new Sale());

        //Act
        var result = await _saleService.GetSale(saleId);

        //Assert
        Assert.Empty(result.Errors);
        Assert.NotNull(result.Data);
    }

    [Fact]
    public async Task GetSale_ShouldNotReturnSale()
    {
        //Arrange
        _saleRepository.GetById(Arg.Any<Guid>()).ReturnsNull();

        //Act
        var result = await _saleService.GetSale(new Guid());

        //Assert
        Assert.NotEmpty(result.Errors);
        Assert.Null(result.Data);
    }
}