using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;
using Business.WebAPI;
using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class AddModelService
    {
        private readonly AppDbContext _context;

        public AddModelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ModelDef> AddAsyncModel(ModelDefDTO dto)
        {
            bool exists = await _context.ModelTanimlari
            .Where(mt => mt.MotorName == dto.MotorName)
            .AnyAsync(mt => mt.ModelName == dto.ModelName);

            if (exists)
            {
                throw new Exception("Aynı model adı ve motor modeli ile kayıt zaten mevcut!");
            }

            var newModel = new ModelDef
            {
                ModelName = dto.ModelName,
                MotorName = dto.MotorName,
                Year = dto.Year
            };

            _context.ModelTanimlari.Add(newModel);
            await _context.SaveChangesAsync();
            return newModel;
        }
    }
}
