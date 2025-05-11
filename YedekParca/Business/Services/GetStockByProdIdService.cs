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
    public class GetStockByProdIdService
    {
        private readonly AppDbContext _context;

        public GetStockByProdIdService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToplamParcaDTO>> GetStockProductId(int parcaId)
        {
            var stok = await _context.YedekParcalar
                .Include(sc => sc.StokGuid)
                .Where(sc => sc.StokGuid .Any(sm => sm.YedekParcasId == parcaId))
                .Select(sc => new ToplamParcaDTO
                {
                    MaterialName = sc.MaterialName,
                    Price = sc.Price,
                    ToplamStok = sc.StokGuid.Sum(s => s.StokIzm + s.StokErz + s.StokMRK + s.StokAdn + s.StokAnk)
                })
                .ToListAsync();

            return stok;
        }
    }
}
