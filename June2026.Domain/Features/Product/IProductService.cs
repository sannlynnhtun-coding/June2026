using June2026.Domain.Models;

namespace June2026.Domain.Features.Product
{
    public interface IProductService
    {
        ProductCreateResponseModel CreateProduct(ProductCreateRequestModel requestModel);
        ProductDeleteResponseModel DeleteProduct(ProductDeleteRequestModel requestModel);
        ProductEditResponseModel GetProduct(ProductEditRequestModel requestModel);
        ProductListResponseModel GetProducts();
        ProductPatchResponseModel PatchProduct(ProductPatchRequestModel requestModel);
    }
}