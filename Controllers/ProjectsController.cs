using DBAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShoppingCentreAPI.Controllers
{
    public class ProjectsController : ApiController
    {
        public IEnumerable<GetProjects_Result> Get()
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.GetProjects();
                var result = response.ToArray();
                return result;
            }
        }
        public IEnumerable<budgetInfo_Result> Get(int budgetID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.budgetInfo(budgetID);
                var result = response.ToArray();
                return result;
            }
        }
    }
}
