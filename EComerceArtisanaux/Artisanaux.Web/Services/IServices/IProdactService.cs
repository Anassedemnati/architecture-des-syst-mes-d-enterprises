using Artisanaux.Web.Models;

namespace Artisanaux.Web.Services.IServices;

public interface IProdactService:IBaseServise
{
    Task<T> GetAllProductsAsync<T>(string token);
    Task<T> GetProductsAsync<T>(int id,string token);
    Task<T> CreateProductAsync<T>(ProductDto product, string token);
    Task<T> UpdateProductAsync<T>(int id,ProductDto product, string token);
    Task<T> DeleteProductAsync<T>(int id, string token);

}
