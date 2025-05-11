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
    public class SatisService
    {

        private readonly AppDbContext _context;
        public SatisService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SatisYapAsync(StokSatisDTO dto)
        {
            var stok = await _context.StokDetaylar
                .FirstOrDefaultAsync(s => s.YedekParcasId == dto.YedekParcasId);
            if (stok == null)
                throw new InvalidOperationException("Ürün stok kaydı bulunamadı.");

            var sehir = dto.Sehir.Trim().ToLower();
            var miktar = dto.Miktar;

            switch (sehir)
            {
                case "izmir":
                    if (stok.StokIzm < miktar)
                        throw new InvalidOperationException($"Yetersiz İzmir stoku ({stok.StokIzm}).");
                    stok.StokIzm -= miktar;
                    await _context.SaveChangesAsync();
                    return stok.StokIzm;

                case "merkez":
                    if (stok.StokMRK < miktar)
                        throw new InvalidOperationException($"Yetersiz Merkez stoku ({stok.StokMRK}).");
                    stok.StokMRK -= miktar;
                    await _context.SaveChangesAsync();
                    return stok.StokMRK;

                case "ankara":
                    if (stok.StokAnk < miktar)
                        throw new InvalidOperationException($"Yetersiz Ankara stoku ({stok.StokAnk}).");
                    stok.StokAnk -= miktar;
                    await _context.SaveChangesAsync();
                    return stok.StokAnk;

                case "adana":
                    if (stok.StokAdn < miktar)
                        throw new InvalidOperationException($"Yetersiz Adana stoku ({stok.StokAdn}).");
                    stok.StokAdn -= miktar;
                    await _context.SaveChangesAsync();
                    return stok.StokAdn;

                case "erzurum":
                    if (stok.StokErz < miktar)
                        throw new InvalidOperationException($"Yetersiz Erzurum stoku ({stok.StokErz}).");
                    stok.StokErz -= miktar;
                    await _context.SaveChangesAsync();
                    return stok.StokErz;

                default:
                    throw new ArgumentException("Geçersiz şehir kodu. (izm, mrk, ank, adn, erz)");
            }
        }
    }
}
    


