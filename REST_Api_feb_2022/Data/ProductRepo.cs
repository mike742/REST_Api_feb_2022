using REST_Api_feb_2022.Data.Intefases;
using REST_Api_feb_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Api_feb_2022.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Product input)
        {
            _context.Products.Add(input);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var productInDb = _context.Products.FirstOrDefault(p => p.Id == id);

            if (productInDb != null)
            {
                _context.Remove(productInDb);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            var productInDb = _context.Products.FirstOrDefault(p => p.Id == id);
            return productInDb;
        }

        public void Update(int id, Product input)
        {
            var productInDb = _context.Products.FirstOrDefault(p => p.Id == id);

            if(productInDb != null)
            {
                productInDb.Name = input.Name;
                productInDb.Price = input.Price;

                _context.SaveChanges();
            }
        }
    }
}
