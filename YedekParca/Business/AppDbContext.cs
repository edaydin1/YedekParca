using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Business.WebAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<YedekParcas> YedekParcalar { get; set; }
        public DbSet<StokDet> StokDetaylar { get; set; }
        public DbSet<ModelDef>? ModelTanimlari { get; set; }
        public DbSet<YedekParcaModel> YedekParcaModel { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=YedekParca;Username=postgres;Password=;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>();
            modelBuilder.Entity<ModelDef>();

            modelBuilder.Entity<YedekParcaModel>()
                .HasKey(ypm => new { ypm.YedekParcasId, ypm.ModelID });

            modelBuilder.Entity<YedekParcaModel>()
                .HasOne(ypm => ypm.YedekParcas)
                .WithMany(y => y.YedekParcaModelleri)
                .HasForeignKey(ypm => ypm.YedekParcasId);

            modelBuilder.Entity<YedekParcaModel>()
                .HasOne(ypm => ypm.Model)
                .WithMany(m => m.YedekParcaModelleri)
                .HasForeignKey(ypm => ypm.ModelID);

            modelBuilder.Entity<StokDet>()
                .HasOne(s => s.YedekParcas)
                .WithMany(y => y.StokGuid)
                .HasForeignKey(s => s.YedekParcasId);

            /*modelBuilder.Entity<ModelDef>().HasData(
                new ModelDef { ModelID = 1, Year = "06-", ModelName = "JUMPER-3", MotorName = "2.2 HDI" },
                new ModelDef { ModelID = 2, Year = "07-", ModelName = "207/308/C4/MINI", MotorName = "1.6 EP6" },
                new ModelDef { ModelID = 3, Year = "97-", ModelName = "407/607", MotorName = "BM" },
                new ModelDef { ModelID = 4, Year = "06-", ModelName = "BOXER-3", MotorName = "2.2 HDI", }
            );*/

            /*modelBuilder.Entity<YedekParcas>().HasData(
                new YedekParcas { Id = 1, MaterialCode = "0249.E9", MaterialName = "ÜST KAPAK CONTA", Price = 1114.78f },
                new YedekParcas { Id = 2, MaterialCode = "0249.F4", MaterialName = "KÜLBÜTÖR KAPAK CONTASI", Price = 837.47f }
            );*/

            modelBuilder.Entity<Users>().HasData(
                new Users { Id = 1, UserName = "admin", Password = "123", Role = "admin" },
                new Users { Id = 2, UserName = "user", Password = "user", Role = "user" }
            );


            /*modelBuilder.Entity<StokDet>().HasData(
                new StokDet
                {
                    StokID = 1,
                    StokMRK = 0,
                    StokIzm = 1,
                    StokAnk = 1,
                    StokAdn = 8,
                    StokErz = 1,
                    YedekParcasId = 1,
                    ModelID = 1
                },
                new StokDet
                {
                    StokID = 2,
                    StokMRK = 18,
                    StokIzm = 0,
                    StokAnk = 1,
                    StokAdn = 13,
                    StokErz = 11,
                    YedekParcasId = 2,
                    ModelID = 2
                }
            );*/
        }

    }
}
