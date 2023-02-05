using Microsoft.AspNetCore.Mvc;
using ProductManagement_DataAccess.Repository;
using ProductManagement_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagemet.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        public ProductController(IProductRepository _productRepo, ICategoryRepository _categoryRepo)
        {
            this._productRepo = _productRepo;
            this._categoryRepo = _categoryRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_productRepo.Get());
        }
        [HttpGet]
        public IActionResult Create() 
        {
            var catList = _categoryRepo.Get().ToList();
            ViewBag.Category = catList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            _productRepo.Insert(product);
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            if (_productRepo.Delete(id)) 
            {
                return RedirectToAction("index");
            }
            return View();
        }

    }
}
