using ProductManagement_DataAccess.Data;
using ProductManagement_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement_DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            this._dbContext = context;
        }

        public IEnumerable<Category> Get()
        {
            try
            {
                return _dbContext.Categories.ToList();
            }
            catch (Exception ex)
            {
                return new List<Category>();
            }
        }

    }
}
