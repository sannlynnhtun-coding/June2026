using June2026.Domain.Models;

namespace June2026.Domain.Features.Product
{
    public interface IProductService
    {
        Task<ProductCreateResponseModel> CreateProductAsync(ProductCreateRequestModel requestModel);
        Task<ProductDeleteResponseModel> DeleteProductAsync(ProductDeleteRequestModel requestModel);
        Task<ProductEditResponseModel> GetProductAsync(ProductEditRequestModel requestModel);
        Task<ProductListResponseModel> GetProductsAsync();
        Task<ProductPatchResponseModel> PatchProductAsync(ProductPatchRequestModel requestModel);
    }
}
