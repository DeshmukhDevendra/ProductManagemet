using ProductManagement_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement_DataAccess.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> Get();
        public bool Insert(Product product);
        public Product Update(int id);
        public bool Delete(int id);

    }
}
