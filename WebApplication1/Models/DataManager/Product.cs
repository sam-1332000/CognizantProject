using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Repository;
using WebApplication1.Models;

namespace WebApplication1.Models.DataManager
{
    public class ProductManager: IProductRepository<Product>
    {
        readonly DataContext _dataContext;

        public ProductManager(DataContext context)
        {
            _dataContext = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return (IEnumerable<Product>)_dataContext.Products.ToList();
        }

        public Product Get(long id)
        {
            return _dataContext.Products
                  .FirstOrDefault(e => e.ProductID == id);
        }

        public void Add(Product entity)
        {
            _dataContext.Products.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Product p, Product entity)
        {
            p.ProductName = entity.ProductName;
            p.Category = entity.Category;
            p.Brand = entity.Brand;
            p.Price = entity.Price;
            p.ProductImage = entity.ProductImage;
            _dataContext.SaveChanges();
        }
        public void Delete(Product p)
        {
            _dataContext.Products.Remove(p);
            _dataContext.SaveChanges();
        }
    }
}
