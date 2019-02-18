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
    public class ModelController : Controller
    {
        // GET: Model
        public ActionResult ModelDashboard()
        {
            try
            {
                ModelView modelV = new ModelView();
                CarQuerys queries = new CarQuerys();
                List<Model> models = queries.getAllModels();
                //for dropdowns
                List<Brand> brands = queries.getAllBrands();

                modelV.models = models;
                modelV.brands = brands;
                modelV.brand = new Brand();
                modelV.model = new Model();

                return View(modelV);
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Model", "ModelDashboard"));
            }
            
        }

        [HttpPost]
        public ActionResult AddModel(Model model, int BrandId)
        {
            try
            {
                CarQuerys queries = new CarQuerys();
                ModelView modelV = new ModelView();
                model.BrandId = BrandId;
                queries.insertModel(model);
                var brands = queries.getAllBrands();

                List<Model> models = queries.getAllModels();
                //for dropdowns

                modelV.models = models;
                modelV.brands = brands;
                modelV.brand = new Brand();
                modelV.model = new Model();
                return PartialView("_PartialModel", modelV);
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "Model", "AddModel"));
            }
           
        }
    }
}