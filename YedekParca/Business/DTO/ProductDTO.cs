using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class ProductDTO
    {
        public int ProductId {  get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public float ProductPrice { get; set; }
    }
}
