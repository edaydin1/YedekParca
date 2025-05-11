using Business.WebAPI;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YedekParca.WebAPI;

namespace Business.Services
{
    public class AvailableProducts
    {
        
        private readonly AppDbContext _context;

        public AvailableProducts(AppDbContext context)
        {
            _context = context;
        }

        

        public async Task<List<YedekParcas>> GetYedekParcalarByModelId(int modelId)
        {
            var yedekParcalar = await _context.YedekParcalar
                .Include(yp => yp.StokGuid)
                .Where(yp => yp.YedekParcaModelleri
                .Any(ypm => ypm.ModelID == modelId))
                .ToListAsync();

            return yedekParcalar;
        }
    
    }
}