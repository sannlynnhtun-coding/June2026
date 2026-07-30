using June2026.Database.AppDbContextModels;
using June2026.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace June2026.Domain.Features.Product;

public class ProductService
{
    private readonly AppDbContext _db;

    public ProductService()
    {
        _db = new AppDbContext();
    }

    public ProductListResponseModel GetProducts()
    {
        try
        {
            var lst = _db.TblProducts
                .Where(x => !x.IsDelete)
                .ToList();

            var products = lst.Select(item => new ProductModel
            {
                ProductId = item.ProductId,
                ProductCode = item.ProductCode,
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = item.Quantity
            }).ToList();

            return new ProductListResponseModel
            {
                IsSuccess = true,
                Message = "Products fetched successfully.",
                Products = products
            };
        }
        catch (Exception ex)
        {
            return new ProductListResponseModel
            {
                IsSuccess = false,
                Message = ex.ToString(),
                Products = new List<ProductModel>()
            };
        }
    }

    public ProductEditResponseModel GetProduct(ProductEditRequestModel requestModel)
    {
        try
        {
            var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == requestModel.ProductId && !x.IsDelete);
            if (item is null)
            {
                return new ProductEditResponseModel
                {
                    IsSuccess = false,
                    Message = "Product doesn't exist."
                };
            }

            return new ProductEditResponseModel
            {
                IsSuccess = true,
                Message = "Product fetched successfully.",
                ProductId = item.ProductId,
                ProductCode = item.ProductCode,
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }
        catch (Exception ex)
        {
            return new ProductEditResponseModel
            {
                IsSuccess = false,
                Message = ex.ToString()
            };
        }
    }

    public ProductCreateResponseModel CreateProduct(ProductCreateRequestModel requestModel)
    {
        try
        {
            TblProduct product = new TblProduct
            {
                ProductCode = requestModel.ProductCode,
                ProductName = requestModel.ProductName,
                Price = requestModel.Price,
                Quantity = requestModel.Quantity,
                CreatedDateTime = DateTime.Now,
                IsDelete = false
            };

            _db.TblProducts.Add(product);
            int result = _db.SaveChanges();

            return new ProductCreateResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Saving Successful." : "Saving Failed.",
                ProductId = product.ProductId
            };
        }
        catch (Exception ex)
        {
            return new ProductCreateResponseModel
            {
                IsSuccess = false,
                Message = ex.ToString()
            };
        }
    }

    public ProductPatchResponseModel PatchProduct(ProductPatchRequestModel requestModel)
    {
        try
        {
            var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == requestModel.ProductId && !x.IsDelete);
            if (item is null)
            {
                return new ProductPatchResponseModel
                {
                    IsSuccess = false,
                    Message = "Product doesn't exist."
                };
            }

            if (!string.IsNullOrEmpty(requestModel.ProductCode))
            {
                item.ProductCode = requestModel.ProductCode;
            }
            if (!string.IsNullOrEmpty(requestModel.ProductName))
            {
                item.ProductName = requestModel.ProductName;
            }
            if (requestModel.Price.HasValue)
            {
                item.Price = requestModel.Price.Value;
            }
            if (requestModel.Quantity.HasValue)
            {
                item.Quantity = requestModel.Quantity.Value;
            }

            item.ModifiedDateTime = DateTime.Now;

            int result = _db.SaveChanges();

            return new ProductPatchResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Updating Successful." : "Updating Failed."
            };
        }
        catch (Exception ex)
        {
            return new ProductPatchResponseModel
            {
                IsSuccess = false,
                Message = ex.ToString()
            };
        }
    }

    public ProductDeleteResponseModel DeleteProduct(ProductDeleteRequestModel requestModel)
    {
        try
        {
            var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == requestModel.ProductId && !x.IsDelete);
            if (item is null)
            {
                return new ProductDeleteResponseModel
                {
                    IsSuccess = false,
                    Message = "Product doesn't exist."
                };
            }

            item.IsDelete = true;
            item.ModifiedDateTime = DateTime.Now;

            int result = _db.SaveChanges();

            return new ProductDeleteResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Deleting Successful." : "Deleting Failed."
            };
        }
        catch (Exception ex)
        {
            return new ProductDeleteResponseModel
            {
                IsSuccess = false,
                Message = ex.ToString()
            };
        }
    }
}
