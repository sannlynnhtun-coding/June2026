using June2026.Domain.Features.Product;
using June2026.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace June2026.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController()
    {
        _productService = new ProductService();
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var result = _productService.GetProducts();
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var result = _productService.GetProduct(new ProductEditRequestModel { ProductId = id });
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductCreateRequestModel requestModel)
    {
        var result = _productService.CreateProduct(requestModel);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchProduct(int id, [FromBody] ProductPatchRequestModel requestModel)
    {
        requestModel.ProductId = id;
        var result = _productService.PatchProduct(requestModel);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var result = _productService.DeleteProduct(new ProductDeleteRequestModel { ProductId = id });
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }
}
