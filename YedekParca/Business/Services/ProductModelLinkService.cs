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
    public class ProductModelLinkService
    {
        private readonly AppDbContext _appDbContext;

        public ProductModelLinkService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<YedekParcaModel> AddProductModelLink(ProductModelLinkDTO modelLinkDTO)
        {

            bool Productchck = await _appDbContext.YedekParcalar
            .AnyAsync(ab => ab.Id == modelLinkDTO.ProductID);

            bool Modelchck = await _appDbContext.ModelTanimlari
            .AnyAsync(ac => ac.ModelID == modelLinkDTO.ModelID);

            if (!Productchck || !Modelchck)
            {
                throw new Exception("Model veya Product bulunamadı");
            }

            bool exists = await _appDbContext.YedekParcaModel
            .Where(yp => yp.YedekParcasId == modelLinkDTO.ProductID)
            .AnyAsync(yp => yp.ModelID == modelLinkDTO.ModelID);

            if (exists)
            {
                throw new Exception("Aynı bağlantı bulunmakta");
            }

            var link = new YedekParcaModel
            {
                YedekParcasId = modelLinkDTO.ProductID,
                ModelID = modelLinkDTO.ModelID
            };
            _appDbContext.YedekParcaModel.Add(link);
            await _appDbContext.SaveChangesAsync();
            return link;
        }
    }
}
