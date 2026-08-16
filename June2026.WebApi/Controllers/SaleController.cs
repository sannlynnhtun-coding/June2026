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
    public async Task<IActionResult> GetSalesAsync()
    {
        var result = await _saleService.GetSalesAsync();
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSaleAsync([FromBody] SaleCreateRequestModel requestModel)
    {
        var result = await _saleService.CreateSaleAsync(requestModel);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }
}
