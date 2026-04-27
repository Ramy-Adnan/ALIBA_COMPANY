using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALIBA_COMPANY.classes
{
    public class Validator
    {
        private readonly AlibaRamyEntities _dbContext;

        public Validator(AlibaRamyEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CustomerExists(string customerName)
        {
            // تحقق من وجود العميل في قاعدة البيانات بناءً على اسم العميل
            return _dbContext.TB_cust.Any(c => c.cust_name == customerName);
        }
        public bool CarExists(string carName)
        {
           
            return _dbContext.TB_cars.Any(c => c.car_name == carName);
        }
        public bool EmploExists(string emploName)
        {
           
            return _dbContext.TB_emplo.Any(c => c.emplo_name == emploName);
        }
        public bool BranchExists(string branchName)
        {
            
            return _dbContext.TB_cust.Any(c => c.cust_name == branchName);
        }
        public bool CityExists(string cityName)
        {
           
            return _dbContext.TB_city.Any(c => c.city_name == cityName);
        }
        public bool ItemExists(string itemName)
        {
          
            return _dbContext.TB_items.Any(c => c.items_name == itemName);
        }
    }

}
