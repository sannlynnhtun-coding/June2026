# Implementation Plan: Mini POS

Create a mini POS (Point of Sale) system inside `June2026.Domain` and `June2026.Database` following the existing project architecture patterns.

## Proposed Changes

### Database Project (`June2026.Database`)

Modify and create entity models for the POS:

#### [MODIFY] [AppDbContext.cs](file:///d:/slh\proj\June2026\June2026.Database\AppDbContextModels\AppDbContext.cs)
- Add DbSets for `TblProduct`, `TblSale`, and `TblSaleDetail`.
- Configure their keys, relationships, and constraints in `OnModelCreating`.
- Note: We will replace or modify the existing `TblProduct` entity since the prompt requests `ProductId`, `ProductCode`, `ProductName`, `Price`, `Quantity` as well as the audit fields.

#### [NEW] [TblProduct.cs](file:///d:/slh\proj\June2026\June2026.Database\AppDbContextModels\TblProduct.cs) (Overwrite/Update)
- Fields:
  - `ProductId` (int, Key)
  - `ProductCode` (string)
  - `ProductName` (string)
  - `Price` (decimal)
  - `Quantity` (int)
  - `CreatedDateTime` (DateTime)
  - `ModifiedDateTime` (DateTime?)
  - `IsDelete` (bool)

#### [NEW] [TblSale.cs](file:///d:/slh\proj\June2026\June2026.Database\AppDbContextModels\TblSale.cs)
- Fields:
  - `SaleId` (int, Key)
  - `VoucherNo` (string)
  - `SaleDateTime` (DateTime)
  - `TotalAmount` (decimal)
  - `CreatedDateTime` (DateTime)
  - `ModifiedDateTime` (DateTime?)
  - `IsDelete` (bool)

#### [NEW] [TblSaleDetail.cs](file:///d:/slh\proj\June2026\June2026.Database\AppDbContextModels\TblSaleDetail.cs)
- Fields:
  - `SaleDetailId` (int, Key)
  - `SaleVoucherNo` (string)
  - `ProductId` (int)
  - `Price` (decimal)
  - `Quantity` (int)
  - `CreatedDateTime` (DateTime)
  - `ModifiedDateTime` (DateTime?)
  - `IsDelete` (bool)

---

### Domain Project (`June2026.Domain`)

Create features and services:

#### [NEW] Models in `June2026.Domain\Models`
- `ProductListRequestModel.cs`
- `ProductListResponseModel.cs`
- `ProductCreateRequestModel.cs`
- `ProductCreateResponseModel.cs`
- `ProductEditRequestModel.cs`
- `ProductEditResponseModel.cs`
- `ProductPatchRequestModel.cs`
- `ProductPatchResponseModel.cs`
- `ProductDeleteRequestModel.cs`
- `ProductDeleteResponseModel.cs`
- `ProductModel.cs`
- `SaleCreateRequestModel.cs`
- `SaleCreateResponseModel.cs`
- `SaleDetailModel.cs`
- `SaleListRequestModel.cs`
- `SaleListResponseModel.cs`
- `SaleModel.cs`

#### [NEW] [ProductService.cs](file:///d:/slh\proj\June2026\June2026.Domain\Features\Product\ProductService.cs)
- Service for Product CRUD operations (GetProducts, GetProduct, CreateProduct, UpdateProduct, PatchProduct, DeleteProduct) handling `IsDelete` soft delete and audit timestamps.

#### [NEW] [SaleService.cs](file:///d:/slh\proj\June2026\June2026.Domain\Features\Sale\SaleService.cs)
- Service for Sale transaction operations (handling both `TblSale` and `TblSaleDetail` in a transaction, updating product quantities on sale).

## Verification Plan

### Automated/Manual Verification
- Create a new project or update `ConsoleApp7` to test the Product CRUD and Sale transaction features.
