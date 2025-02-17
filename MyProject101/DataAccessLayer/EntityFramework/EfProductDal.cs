using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework {
    public class EfProductDal : GenericRepository<Product>, IProductDal {
        public List<Product> GetProductsWithCategories() {
            using (var context = new Context()) {
                return context.Products.Include(p => p.ProductCategory).ToList();
            }
        }
    }
}
