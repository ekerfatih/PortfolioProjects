﻿using EntityLayer.Concrete;

namespace BusinessLayer.Abstract {
    public interface ICategoryService : IGenericService<Category> {
        List<Category> GetCategoryListWithProducts();
    }
}
