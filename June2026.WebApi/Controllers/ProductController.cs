using June2026.Domain.Features.Product;
using June2026.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace June2026.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        var result = await _productService.GetProductsAsync();
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductAsync(int id)
    {
        var result = await _productService.GetProductAsync(new ProductEditRequestModel { ProductId = id });
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromBody] ProductCreateRequestModel requestModel)
    {
        var result = await _productService.CreateProductAsync(requestModel);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchProductAsync(int id, [FromBody] ProductPatchRequestModel requestModel)
    {
        requestModel.ProductId = id;
        var result = await _productService.PatchProductAsync(requestModel);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        var result = await _productService.DeleteProductAsync(new ProductDeleteRequestModel { ProductId = id });
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }
}
