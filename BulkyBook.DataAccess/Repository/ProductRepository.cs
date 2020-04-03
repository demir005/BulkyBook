using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product products)
        {
            var objFromDb = _db.Products.FirstOrDefault(s => s.Id == products.Id);
            if (objFromDb != null)
            {
                if(products.ImageUrl != null)
                {
                    objFromDb.ImageUrl = products.ImageUrl;
                }

                objFromDb.ISBN = products.ISBN;
                objFromDb.Price = products.Price;
                objFromDb.Price50 = products.Price50;
                objFromDb.Price100 = products.Price100;
                objFromDb.Title = products.Title;
                objFromDb.Description = products.Description;
                objFromDb.CategoryId = products.CategoryId;
                objFromDb.Author = products.Author;
                objFromDb.CoverTypeId = products.CoverTypeId;     
            }

        }
    }
}
