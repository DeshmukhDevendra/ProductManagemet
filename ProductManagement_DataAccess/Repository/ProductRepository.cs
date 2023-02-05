using ProductManagement_DataAccess.Data;
using ProductManagement_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement_DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext context)
        {
            this._dbContext = context;
        }
        public bool Delete(int id)
        {
            try
            {
                var prod = _dbContext.Products.Find(id);
                if (prod != null) 
                {
                    _dbContext.Products.Remove(prod);
                    _dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Product> Get()
        {
            try
            {
                var products = from prod in _dbContext.Products
                               join cat in _dbContext.Categories
                               on prod.Category_Id equals cat.Category_Id into prods
                               from cat in prods.DefaultIfEmpty()
                               select new Product
                               {
                                   Id = prod.Id,
                                   Name = prod.Name,
                                   SKU = prod.SKU,
                                   Category = new Category
                                   {
                                       Category_Id = cat.Category_Id,
                                       Name = cat.Name,
                                       IsActive = cat.IsActive
                                   },
                                   BasePrice = prod.BasePrice,
                                   MRP = prod.BasePrice,
                                   Description = prod.Description,
                                   Currency = prod.Currency,
                                   DateManufactured = prod.DateManufactured,
                                   ExpiryDate = prod.ExpiryDate
                               };

                return products.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Insert(Product product)
        {
            try
            {
                product.Category_Id = product.Category.Category_Id;
                product.Category = null;
                product.DateManufactured = DateTime.Now;
                _dbContext.Add(product);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Product Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
