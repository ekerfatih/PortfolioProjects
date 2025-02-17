using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class ProductManager(IGenericDal<Product> genericDal) : GenericManager<Product>(genericDal), IProductService {

        private IProductDal _productDal  = (IProductDal)genericDal;

        public List<Product> GetProductsWithCategories() {
            return _productDal.GetProductsWithCategories();
        }
    }
}
