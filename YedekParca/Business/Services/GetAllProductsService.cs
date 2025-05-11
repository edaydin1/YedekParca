
using Business.DTO;
using Business.WebAPI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class GetAllProductsService
    {
        private readonly AppDbContext _context;
        public GetAllProductsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var product = await _context.YedekParcalar
                .Select(x => new ProductDTO
                {
                    ProductId = x.Id,
                    ProductName = x.MaterialName,
                    ProductCode= x.MaterialCode,
                    ProductPrice = x.Price
                }).ToListAsync();
            return product;
        }
    }
}
