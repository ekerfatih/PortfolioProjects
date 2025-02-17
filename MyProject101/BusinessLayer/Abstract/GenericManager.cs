using DataAccessLayer.Abstract;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract {
    public class GenericManager<T> : IGenericService<T> where T : class {

        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal) {
            _genericDal = genericDal;
        }

        public void TDelete(T t) {
            _genericDal.Delete(t);
        }

        public T TGetById(int id) {
            return _genericDal.GetById(id);
        }

        public List<T> TGetList() {
            return _genericDal.GetList();
        }

        public void TInsert(T t) {
            _genericDal.Insert(t);
        }

        public void TUpdate(T t) {
            _genericDal.Update(t);
        }
    }
}
