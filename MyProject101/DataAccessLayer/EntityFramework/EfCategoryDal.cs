using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.EntityFramework {
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal {
        public List<Category> GetCategoryListWithProducts() {
            using(Context c = new Context()){
                return c.Categories.Include(x=> x.ProductsBelongThisCategory).ToList();
            }
        }
    }
}
