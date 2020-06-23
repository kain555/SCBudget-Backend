using DBAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BudgetAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employees> Get()
        {
            using (BudgetCHEntities1 entities = new BudgetCHEntities1())
            {
                return entities.Employees.ToList();
            }
        }

        public IEnumerable<string> Get(int position)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.userByPosition(position);
                var result = response.ToArray();
                return result;
            }
        }
        public IEnumerable<empDirector1_Result> GetDirectors()
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.empDirector1();
                var result = response.ToList();
                return result;
            }
        }

        public IEnumerable<empDirectorReg1_Result> getDirectorsReg()
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.empDirectorReg1();
                var result = response.ToList();
                return result;
            }
        }

        public IEnumerable<empOwner1_Result> getOwners()
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.empOwner1();
                var result = response.ToList();
                return result;
            }
        }
    }
}
