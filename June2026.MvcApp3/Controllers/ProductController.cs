using June2026.Domain.Features.Product;
using June2026.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace June2026.MvcApp3.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [ActionName("Index")]
    public async Task<IActionResult> ProductList()
    {
        ProductListResponseModel model = await _productService.GetProductsAsync();
        model.Products ??= new List<ProductModel>();

        ViewData["ProductCards"] = model.Products;
        return View("ProductList", model);
    }

    public IActionResult Create()
    {
        return View("ProductCreate", new ProductCreateRequestModel());
    }

    [HttpPost]
    [ActionName("Save")]
    public async Task<IActionResult> Save(ProductCreateRequestModel requestModel)
    {
        if (string.IsNullOrWhiteSpace(requestModel.ProductCode))
        {
            TempData["IsSuccess"] = false;
            TempData["Message"] = "Product code is required.";
            return Json(new ProductCreateResponseModel
            {
                IsSuccess = false,
                Message = "Product code is required."
            });
        }
        if (string.IsNullOrWhiteSpace(requestModel.ProductName))
        {
            TempData["IsSuccess"] = false;
            TempData["Message"] = "Product name is required.";
            return Json(new ProductCreateResponseModel
            {
                IsSuccess = false,
                Message = "Product name is required."
            });
        }
        if (requestModel.Price <= 0)
        {
            TempData["IsSuccess"] = false;
            TempData["Message"] = "Price must be greater than zero.";
            return Json(new ProductCreateResponseModel
            {
                IsSuccess = false,
                Message = "Price must be greater than zero."
            });
        }
        if (requestModel.Quantity < 0)
        {
            TempData["IsSuccess"] = false;
            TempData["Message"] = "Quantity must be zero or greater.";
            return Json(new ProductCreateResponseModel
            {
                IsSuccess = false,
                Message = "Quantity must be zero or greater."
            });
        }

        ProductCreateResponseModel response = await _productService.CreateProductAsync(requestModel);
        TempData["IsSuccess"] = response.IsSuccess;
        TempData["Message"] = response.Message;
        return Json(response);
    }

    [ActionName("Edit")]
    public async Task<IActionResult> Edit(int id)
    {
        ProductEditResponseModel model = await _productService.GetProductAsync(new ProductEditRequestModel { ProductId = id });
        if (!model.IsSuccess)
        {
            TempData["IsSuccess"] = false;
            TempData["Message"] = model.Message;
            return Redirect("/Product");
        }

        return View("ProductEdit", model);
    }

    [HttpPost]
    [ActionName("Update")]
    public async Task<IActionResult> Update(int id, ProductPatchRequestModel requestModel)
    {
        requestModel.ProductId = id;

        if (string.IsNullOrWhiteSpace(requestModel.ProductCode)
            && string.IsNullOrWhiteSpace(requestModel.ProductName)
            && requestModel.Price is null
            && requestModel.Quantity is null)
        {
            TempData["IsSuccess"] = false;
            TempData["Message"] = "Please update at least one field.";
            return Json(new ProductPatchResponseModel
            {
                IsSuccess = false,
                Message = "Please update at least one field."
            });
        }

        ProductPatchResponseModel response = await _productService.PatchProductAsync(requestModel);
        TempData["IsSuccess"] = response.IsSuccess;
        TempData["Message"] = response.Message;
        return Json(response);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        ProductDeleteResponseModel response = await _productService.DeleteProductAsync(new ProductDeleteRequestModel { ProductId = id });
        TempData["IsSuccess"] = response.IsSuccess;
        TempData["Message"] = response.Message;
        return Json(response);
    }
}
