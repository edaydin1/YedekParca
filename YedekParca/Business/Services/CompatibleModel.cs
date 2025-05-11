using Business.WebAPI;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    
    public class CompatibleModel
    {
        private readonly AppDbContext _context;

        public CompatibleModel(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<List<ModelDef>> GetModelIDByYedekParca(int yedekParcaId)
        {
            var uyumluModeller = await _context.YedekParcaModel
                .Where(ypm => ypm.YedekParcasId == yedekParcaId)
                .Include(ypm => ypm.Model)
                .Select(ypm => ypm.Model)
                .ToListAsync();

            return uyumluModeller;
        }
    }
}
