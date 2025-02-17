using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete {
    public class CustomerManager : GenericManager<Customer>, ICustomerService {

        public CustomerManager(IGenericDal<Customer> genericDal) : base(genericDal) {
           
        }

       
    }
}
