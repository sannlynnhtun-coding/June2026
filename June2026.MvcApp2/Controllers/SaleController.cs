using June2026.Domain.Features.Product;
using June2026.Domain.Features.Sale;
using June2026.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace June2026.MvcApp2.Controllers
{
    public class SaleController : Controller
    {
        private readonly IProductService _productService;
        private readonly SaleService _saleService;

        public SaleController(IProductService productService, SaleService saleService)
        {
            _productService = productService;
            _saleService = saleService;
        }

        [ActionName("Index")]
        public async Task<IActionResult> SaleList()
        {
            SaleListResponseModel model = await _saleService.GetSalesAsync();
            model.Sales ??= new List<SaleModel>();

            ViewData["SalesCards"] = model.IsSuccess ? model.Sales : new List<SaleModel>();

            if (!model.IsSuccess)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = model.Message;
            }

            return View("SaleList", model);
        }

        public async Task<IActionResult> Create()
        {
            ProductListResponseModel products = await _productService.GetProductsAsync();
            if (!products.IsSuccess)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = products.Message;
            }

            ViewData["Products"] = products.IsSuccess ? products.Products : new List<ProductModel>();
            return View("SaleCreate", new SaleCreateRequestModel
            {
                SaleDateTime = DateTime.Now
            });
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save(SaleCreateRequestModel requestModel)
        {
            ProductListResponseModel productList = await _productService.GetProductsAsync();
            ViewData["Products"] = productList.IsSuccess ? productList.Products : new List<ProductModel>();

            if (string.IsNullOrWhiteSpace(requestModel.VoucherNo))
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "Voucher number is required.";
                return View("SaleCreate", requestModel);
            }

            if (requestModel.SaleDateTime == default)
            {
                requestModel.SaleDateTime = DateTime.Now;
            }

            requestModel.SaleDetails = requestModel.SaleDetails.Where(item => item.ProductId > 0 && item.Quantity > 0).ToList();

            if (requestModel.SaleDetails.Count == 0)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "At least one valid product line is required.";
                return View("SaleCreate", requestModel);
            }

            SaleCreateResponseModel response = await _saleService.CreateSaleAsync(requestModel);
            TempData["IsSuccess"] = response.IsSuccess;
            TempData["Message"] = response.Message;
            return Redirect("/Sale");
        }
    }
}
