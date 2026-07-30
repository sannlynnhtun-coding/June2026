using June2026.Database.AppDbContextModels;
using June2026.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace June2026.Domain.Features.Sale;

public class SaleService
{
    private readonly AppDbContext _db;

    public SaleService()
    {
        _db = new AppDbContext();
    }

    public SaleCreateResponseModel CreateSale(SaleCreateRequestModel requestModel)
    {
        using var transaction = _db.Database.BeginTransaction();
        try
        {
            if (string.IsNullOrEmpty(requestModel.VoucherNo))
            {
                return new SaleCreateResponseModel
                {
                    IsSuccess = false,
                    Message = "Voucher number is required."
                };
            }

            // Check if voucher no already exists
            var existingSale = _db.TblSales.FirstOrDefault(x => x.VoucherNo == requestModel.VoucherNo && !x.IsDelete);
            if (existingSale is not null)
            {
                return new SaleCreateResponseModel
                {
                    IsSuccess = false,
                    Message = $"Voucher number {requestModel.VoucherNo} already exists."
                };
            }

            decimal totalAmount = 0;
            List<TblSaleDetail> detailsToSave = new List<TblSaleDetail>();

            foreach (var detailReq in requestModel.SaleDetails)
            {
                var product = _db.TblProducts.FirstOrDefault(x => x.ProductId == detailReq.ProductId && !x.IsDelete);
                if (product is null)
                {
                    return new SaleCreateResponseModel
                    {
                        IsSuccess = false,
                        Message = $"Product with ID {detailReq.ProductId} does not exist."
                    };
                }

                if (product.Quantity < detailReq.Quantity)
                {
                    return new SaleCreateResponseModel
                    {
                        IsSuccess = false,
                        Message = $"Insufficient stock for product {product.ProductName}. Available: {product.Quantity}, Requested: {detailReq.Quantity}"
                    };
                }

                // Deduct stock
                product.Quantity -= detailReq.Quantity;
                product.ModifiedDateTime = DateTime.Now;

                // Calculate subtotal
                decimal subTotal = product.Price * detailReq.Quantity;
                totalAmount += subTotal;

                // Create detail record
                var saleDetail = new TblSaleDetail
                {
                    SaleVoucherNo = requestModel.VoucherNo,
                    ProductId = detailReq.ProductId,
                    Price = product.Price,
                    Quantity = detailReq.Quantity,
                    CreatedDateTime = DateTime.Now,
                    IsDelete = false
                };
                detailsToSave.Add(saleDetail);
            }

            // Create main sale record
            TblSale sale = new TblSale
            {
                VoucherNo = requestModel.VoucherNo,
                SaleDateTime = requestModel.SaleDateTime,
                TotalAmount = totalAmount,
                CreatedDateTime = DateTime.Now,
                IsDelete = false
            };

            _db.TblSales.Add(sale);
            _db.TblSaleDetails.AddRange(detailsToSave);

            _db.SaveChanges();
            transaction.Commit();

            return new SaleCreateResponseModel
            {
                IsSuccess = true,
                Message = "Sale transaction completed successfully.",
                SaleId = sale.SaleId
            };
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            return new SaleCreateResponseModel
            {
                IsSuccess = false,
                Message = ex.ToString()
            };
        }
    }

    public SaleListResponseModel GetSales()
    {
        try
        {
            var sales = _db.TblSales.Where(x => !x.IsDelete).ToList();
            var resultList = new List<SaleModel>();

            foreach (var sale in sales)
            {
                var saleModel = new SaleModel
                {
                    SaleId = sale.SaleId,
                    VoucherNo = sale.VoucherNo,
                    SaleDateTime = sale.SaleDateTime,
                    TotalAmount = sale.TotalAmount,
                    SaleDetails = new List<SaleDetailModel>()
                };

                var details = _db.TblSaleDetails
                    .Where(x => x.SaleVoucherNo == sale.VoucherNo && !x.IsDelete)
                    .ToList();

                foreach (var detail in details)
                {
                    var product = _db.TblProducts.FirstOrDefault(x => x.ProductId == detail.ProductId);
                    saleModel.SaleDetails.Add(new SaleDetailModel
                    {
                        SaleDetailId = detail.SaleDetailId,
                        SaleVoucherNo = detail.SaleVoucherNo,
                        ProductId = detail.ProductId,
                        ProductName = product?.ProductName ?? "Unknown Product",
                        Price = detail.Price,
                        Quantity = detail.Quantity
                    });
                }

                resultList.Add(saleModel);
            }

            return new SaleListResponseModel
            {
                IsSuccess = true,
                Message = "Sales fetched successfully.",
                Sales = resultList
            };
        }
        catch (Exception ex)
        {
            return new SaleListResponseModel
            {
                IsSuccess = false,
                Message = ex.ToString(),
                Sales = new List<SaleModel>()
            };
        }
    }
}
