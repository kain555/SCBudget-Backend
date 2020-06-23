using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBAccess;

namespace BudgetAPI.Controllers
{
    public class BudgetController : ApiController
    {
        public IEnumerable<Budget> Get()
        {
            using (BudgetCHEntities1 entities = new BudgetCHEntities1())
            {
                return entities.Budget.ToList();
                //var budget = new Budget {basis_id = result.basis_id, period = result.period };
            }
        }
        
        public IEnumerable<budgetInfo123_Result> Get(int BudgetID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.budgetInfo123(BudgetID);
                var result = response.ToArray();
                return result;
            }
        }

        public HttpResponseMessage Post([FromBody] Budget budget)
        {
            try
            {
                using (var entities = new BudgetCHEntities1())
                {
                    var response = entities.createBudget(budget.period, budget.basis_id, budget.owner_id, budget.comment, budget.project_id, budget.status);
                    var message = Request.CreateResponse(HttpStatusCode.Created, budget);
                    message.Headers.Location = new Uri(Request.RequestUri + budget.budget_id.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public IEnumerable<getBudgetsNotStarted_Result> GetBudgetNotStarted()
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.getBudgetsNotStarted();
                var result = response.ToArray();
                return result;
            }
        }
    }
}
