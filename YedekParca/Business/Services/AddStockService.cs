using Business.DTO;
using Business.WebAPI;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AddStockService
    {
        private readonly AppDbContext _context;

        public AddStockService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<StokDet> AddAsyncStock(AddStockDTO dto)
        {
            var newStock = new StokDet
            {
                StokAdn = dto.Adn,
                StokAnk = dto.Ank,
                StokErz = dto.Erz,
                StokIzm = dto.Izm,
                StokMRK = dto.MRK,
                YedekParcasId = dto.YedekParcaID,
            };
            _context.StokDetaylar.Add(newStock);
            await _context.SaveChangesAsync();
            return newStock;
        }
    }
}
