using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class CategoryManager : GenericManager<Category>, ICategoryService {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(IGenericDal<Category> genericDal) : base(genericDal) {
            _categoryDal  = (ICategoryDal)genericDal;
        }

        public List<Category> GetCategoryListWithProducts() {
            return _categoryDal.GetCategoryListWithProducts();
        }
    }
}
