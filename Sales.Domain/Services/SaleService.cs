using Sales.Domain.Entities;
using Sales.Domain.Enums;
using Sales.Domain.Interfaces.Repositories;
using Sales.Domain.Interfaces.Services;
using Sales.Domain.Result;
using Sales.Domain.Services.Models;

namespace Sales.Domain.Services;

public class SaleService : ISaleService
{
    private readonly ISellerRepository _sellerRepository;
    private readonly IProductRepository _productRepository;
    private readonly ISaleRepository _saleRepository;

    public SaleService(ISellerRepository sellerRepository, IProductRepository productRepository, ISaleRepository saleRepository)
    {
        _sellerRepository = sellerRepository;
        _productRepository = productRepository;
        _saleRepository = saleRepository;
    }

    public ServiceResult<Sale> AddSale(SaleCreateModel model)
    {
        var result = new ServiceResult<Sale>();
        var seller = _sellerRepository.GetById(model.SellerId); 
        var products = _productRepository.GetByIdList(model.ProductIds);

        if (seller is null)
            result.AddError("SellerId", "Vendedor informado é inexistente");

        if (model.ProductIds.Count <= 0)
            result.AddError("ProductIds", "É necessário informar pelo menos um produto");

        if (products.Count != model.ProductIds.Count)
            result.AddError("ProductIds", "Algum(s) dos produtos informados é inexistente(s)");

        if (result.Errors.Any())
            return result;

        var sale = new Sale()
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            Seller = seller,
        };

        foreach (var item in products)
            sale.AddProduct(item);

        return result.WithData(_saleRepository.Add(sale));
    }

    public async Task<ServiceResult<Sale>> GetSale(Guid id)
    {
        var result = new ServiceResult<Sale>();
        var sale = await _saleRepository.GetById(id);

        if (sale is null)
            result.AddError("Id", "Venda não encontrada");

        return result.WithData(sale);
    }

    public async Task<ServiceResult<Sale>> UpdateSaleStatus(Guid id, SaleStatus status)
    {
        var result = new ServiceResult<Sale>();
        var sale = await _saleRepository.GetById(id);

        if (sale is null)
            result.AddError("Id", "Venda não encontrada");

        try
        {
            if (status == SaleStatus.PaymentApproved)
                sale.ApprovePayment();

            if (status == SaleStatus.Canceled)
                sale.Cancel();

            if (status == SaleStatus.SentToCarrier)
                sale.SendToCarrier();

            if (status == SaleStatus.Delivered)
                sale.Deliver();
        }
        catch (Exception ex)
        {
            result.AddError("Status", ex.Message);
        }

        return result.WithData(_saleRepository.Update(sale));
    }
}

