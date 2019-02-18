using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDBSql.Models
{
   public class Model
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }     
        public Double Price { get; set; }
        
    }
}
