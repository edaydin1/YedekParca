using Business.DTO;
using Business.WebAPI;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AddProductService
    {
        private readonly AppDbContext _appDbContext;

        public AddProductService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<YedekParcas> AddAsyncProduct(AddProductDTO productDTO)
        {
            bool exists = await _appDbContext.YedekParcalar
            .Where(yp => yp.MaterialCode == productDTO.ProductCode)
            .AnyAsync(yp => yp.MaterialName == productDTO.ProductName);

            if (exists)
            {
                throw new Exception("Aynı ürün adı veya ürün kodu ile kayıt zaten mevcut!");
            }

            var newProduct = new YedekParcas
            {
                MaterialName = productDTO.ProductName,
                MaterialCode = productDTO.ProductCode,
                Price = productDTO.ProductPrice
            };
            _appDbContext.YedekParcalar.Add(newProduct);
            await _appDbContext.SaveChangesAsync();
            return newProduct;
        }
    }
}
