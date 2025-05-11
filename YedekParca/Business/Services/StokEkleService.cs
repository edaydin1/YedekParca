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
    public class StokEkleService
    {

        private readonly AppDbContext _context;
        public StokEkleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SatisYapAsync(StokSatisDTO dto)
        {
            var stok = await _context.StokDetaylar
                .FirstOrDefaultAsync(s => s.YedekParcasId == dto.YedekParcasId);
            if (stok == null)
                throw new InvalidOperationException("Ürün veya stok kaydı bulunamadı.");

            var sehir = dto.Sehir.Trim().ToLower();
            var miktar = dto.Miktar;

            switch (sehir)
            {
                case "izmir":
                    stok.StokIzm += miktar;
                    await _context.SaveChangesAsync();
                    return stok.StokIzm;

                case "merkez":
                    stok.StokMRK += miktar;
                    await _context.SaveChangesAsync();
                    return stok.StokMRK;

                case "ankara":
                    stok.StokAnk += miktar;
                    await _context.SaveChangesAsync();
                    return stok.StokAnk;

                case "adana":
                    stok.StokAdn += miktar;
                    await _context.SaveChangesAsync();
                    return stok.StokAdn;

                case "erzurum":
                    stok.StokErz += miktar;
                    await _context.SaveChangesAsync();
                    return stok.StokErz;

                default:
                    throw new ArgumentException("Geçersiz şehir kodu. (izmir, merkez, ankara, adana, erzurum)");
            }
        }
    }
}
