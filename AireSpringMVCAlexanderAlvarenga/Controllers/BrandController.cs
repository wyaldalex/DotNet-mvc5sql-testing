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
            try
            {
                BrandViewModel bvm = new BrandViewModel();
                CarQuerys queries = new CarQuerys();
                var brands = queries.getAllBrands();

                bvm.brand = new Brand();
                bvm.listBrands = brands;
                return View(bvm);
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Brand", "Index"));
            }
            
        }

        [HttpPost]
        public ActionResult GetBrands(Brand brand)
        {
            try
            {
                CarQuerys queries = new CarQuerys();
                BrandViewModel bvm = new BrandViewModel();

                queries.insertBrand(brand.BrandName);
                var brands = queries.getAllBrands();

                bvm.brand = new Brand();
                bvm.listBrands = brands;
                return PartialView("_PartialBrand", bvm);
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Brand", "Index"));
            }

            
        }
    }
}