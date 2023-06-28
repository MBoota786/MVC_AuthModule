
using _3_Authentication_Authorization_Other_Project.Models;
using DAL.Data;
using DML._1_clsAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace _1_Authentication_Authorization.Controllers
{

    //*******************  2. Controller Level Authorize  *******************
    [Authorize]
    public class ProductsController : Controller
    {

        private dbContext context;
        public ProductsController(dbContext context)
        {
            this.context = context;
        }

        //______________________ Index _________________________

        //*******************  2. Controller Level Authorize  *******************
        [AllowAnonymous]
        public IActionResult Index()
        {
            var list = context.clProductsAuthentication.ToList();
            return View(list);
        }


        //______________________ Create _________________________

        //*******************  1. Action Level Authorize  *******************
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(clsProductAuthentication product)
        {
            context.clProductsAuthentication.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
