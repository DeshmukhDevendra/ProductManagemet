using Microsoft.AspNetCore.Mvc;
using ProductManagement_DataAccess.Repository;
using ProductManagement_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagemet.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository _categoryRepo)
        {
            this._categoryRepo = _categoryRepo;
        }
        public IActionResult Index()
        {
            return View(_categoryRepo.Get());
        }
    }
}
