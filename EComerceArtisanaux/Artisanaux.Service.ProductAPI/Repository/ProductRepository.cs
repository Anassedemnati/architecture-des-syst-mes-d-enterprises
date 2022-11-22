using Artisanaux.Service.ProductAPI.DbContexts;
using Artisanaux.Service.ProductAPI.Models;
using Artisanaux.Service.ProductAPI.Models.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Artisanaux.Service.ProductAPI.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product? product = await _db.Products!.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            if (product != null)
            {
                ProductDto productDto = _mapper.Map<ProductDto>(product);
                return productDto;
            }
            return await Task.FromResult<ProductDto>(null!);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await _db.Products!.ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
