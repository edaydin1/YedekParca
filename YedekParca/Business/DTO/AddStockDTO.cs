using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class AddStockDTO
    {
        public int MRK { get; set; }
        public int Izm { get; set; }
        public int Ank { get; set; }
        public int Adn { get; set; }
        public int Erz { get; set; }
        public int YedekParcaID { get; set; }
    }
}
