using ProductManagement_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement_DataAccess.Repository
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> Get();

    }
}
