using June2026.Domain.Features.Sale;
using June2026.Domain.Features.User;
using June2026.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace June2026.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly SaleService _saleService;
    private readonly UserService _userService;

    public SaleController(SaleService saleService, UserService userService)
    {
        _saleService = saleService;
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetSales()
    {
        var result = _saleService.GetSales();
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    public IActionResult CreateSale([FromBody] SaleCreateRequestModel requestModel)
    {
        var result = _saleService.CreateSale(requestModel);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }
}
