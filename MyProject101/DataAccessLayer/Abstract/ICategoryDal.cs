﻿using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract {
    public interface ICategoryDal : IGenericDal<Category> {
        List<Category> GetCategoryListWithProducts();
    }
}
