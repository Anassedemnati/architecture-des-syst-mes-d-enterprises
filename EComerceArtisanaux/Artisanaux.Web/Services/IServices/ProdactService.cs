using Artisanaux.Web.Models;

namespace Artisanaux.Web.Services.IServices;

public class ProdactService : BaseServise,IProdactService
{
    private readonly IHttpClientFactory _clientFactory;

    public ProdactService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public Task<T> CreateProductAsync<T>(ProductDto product)
    {
        return this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = product,
            Url = SD.ProductApiBase + "/api/products"
        });
    }

    public async Task<T> DeleteProductAsync<T>(int id, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.ProductApiBase + "/api/products/" + id,
            Token = token
        });
    }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task<T> GetAllProductsAsync<T>()
    {
       return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductApiBase + "/api/products",
            //Token = token
        });
    }

    public async Task<T> GetProductsAsync<T>(int id, string token)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductApiBase + $"/api/products/{id}",
            Token = token
        });
    }

    public Task<T> UpdateProductAsync<T>(int id, ProductDto product)
    {
        return this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.PUT,
            Data = product,
            Url = SD.ProductApiBase + $"/api/products/{id}"
 
        });
    }
}
