using Artisanaux.Web.Models;

namespace Artisanaux.Web.Services.IServices;

public class ProdactService : BaseServise,IProdactService
{
    private readonly IHttpClientFactory _clientFactory;

    public ProdactService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public Task<T> CreateProductAsync<T>(ProductDto product, string token)
    {
        throw new NotImplementedException();
    }

    public Task<T> DeleteProductAsync<T>(int id, string token)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task<T> GetAllProductsAsync<T>(string token)
    {
       return await SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.ProductApiBase + "/api/products",
            Token = token
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

    public Task<T> UpdateProductAsync<T>(int id, ProductDto product, string token)
    {
        throw new NotImplementedException();
    }
}
