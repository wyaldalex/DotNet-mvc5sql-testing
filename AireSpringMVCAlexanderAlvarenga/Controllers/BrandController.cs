using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDBSql.Querys;
using CarDBSql.Models;
using AireSpringMVCAlexanderAlvarenga.Models.ViewModels;

namespace AireSpringMVCAlexanderAlvarenga.Controllers
{
    public class BrandController : Controller
    {
        // GET: Cars
        public ActionResult Index()
        {
            BrandViewModel bvm = new BrandViewModel();
            CarQuerys queries = new CarQuerys();
            var brands = queries.getAllBrands();

            bvm.brand = new Brand();
            bvm.listBrands = brands;
            return View(bvm);
        }

        [HttpPost]
        public ActionResult GetBrands(Brand brand)
        {
            CarQuerys queries = new CarQuerys();
            BrandViewModel bvm = new BrandViewModel();

            queries.insertBrand(brand.BrandName);
            var brands = queries.getAllBrands();

            bvm.brand = new Brand();
            bvm.listBrands = brands;
            return PartialView("_PartialBrand", bvm);
        }
    }
}