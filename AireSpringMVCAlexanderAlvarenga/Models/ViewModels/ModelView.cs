using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDBSql.Models;

namespace AireSpringMVCAlexanderAlvarenga.Models.ViewModels
{
    public class ModelView
    {
        public IEnumerable<Model> models { get; set; }
        public IEnumerable<Brand> brands { get; set; }
        public Model model { get; set; }
        public Brand brand { get; set; }
    }
}