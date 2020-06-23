using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBAccess;
namespace BudgetAPI.Controllers
{
    public class BudgetTotalController : ApiController
    {
        public decimal?[] Get(int budgetID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.getTotalBudget(budgetID);
                var result = response.ToArray();
                return result;
            }
        }
    }
}
