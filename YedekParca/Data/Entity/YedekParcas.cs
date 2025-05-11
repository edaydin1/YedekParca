using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class YedekParcas
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public float Price { get; set; }
        public ICollection<StokDet>? StokGuid { get; set; }
        public ICollection<YedekParcaModel>? YedekParcaModelleri { get; set; }
    }
    public class StokDet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StokID { get; set; }
        public int StokMRK { get; set; }
        public int StokIzm { get; set; }
        public int StokAnk { get; set; }
        public int StokAdn { get; set; }
        public int StokErz { get; set; }

        public int ModelID { get; set; }

        public int YedekParcasId { get; set; }
        [ForeignKey("YedekParcasId")]
        public YedekParcas YedekParcas { get; set; }

    }

    public class ModelDef
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public string MotorName { get; set; }

        public string Year { get; set; }
        public ICollection<YedekParcaModel> YedekParcaModelleri { get; set; }

    }

    public class YedekParcaModel
    {
        public int YedekParcasId { get; set; }
        public YedekParcas? YedekParcas { get; set; }

        public int ModelID { get; set; }
        public ModelDef? Model { get; set; }
    }
}
