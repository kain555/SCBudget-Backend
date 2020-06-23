using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBAccess;

namespace BudgetAPI.Controllers
{
    public class LinesController : ApiController
    {
        public IEnumerable<getLines1_Result> Get()
        {
            using (BudgetCHEntities1 entities = new BudgetCHEntities1())
            {
                return entities.getLines1().ToArray();
            }
        }
        public IEnumerable<LinesbyBudget2_Result> Get(int reqID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.LinesbyBudget2(reqID);
                var result = response.ToArray();
                return result;
            }
        }
    }

}
