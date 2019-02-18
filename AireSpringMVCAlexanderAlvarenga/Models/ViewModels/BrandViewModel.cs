using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDBSql.Models;

namespace AireSpringMVCAlexanderAlvarenga.Models.ViewModels
{
    public class BrandViewModel
    {
        public Brand brand { get; set; }
        public IEnumerable<Brand> listBrands { get; set; }
    }
}