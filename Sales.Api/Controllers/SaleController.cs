using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Enums;
using Sales.Domain.Interfaces.Services;
using Sales.Domain.Services;
using Sales.Domain.Services.Models;

namespace Sales.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SaleController : ControllerBase
{
    private readonly ISaleService _saleServices;

    public SaleController(ISaleService saleServices)
    {
        _saleServices = saleServices;
    }

    [HttpPost]
    public IActionResult AddSale(SaleCreateModel model)
    {
        var result = _saleServices.AddSale(model);

        if (result.Errors.Any())
            return BadRequest(result.Errors);

        return Created(string.Empty, result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSale(Guid id)
    {
        var result = await _saleServices.GetSale(id);

        if (result.Errors.Any())
            return NotFound(result.Errors);

        return Ok(result.Data);
    }

    [HttpPatch("{id}/change-status/{status}")]
    public async Task<IActionResult> UpadateSaleStatus(Guid id, SaleStatus status)
    {
        var result = await _saleServices.UpdateSaleStatus(id, status);

        if (result.Errors.Any())
            return BadRequest(result.Errors);

        return Ok(result.Data);
    } 
}