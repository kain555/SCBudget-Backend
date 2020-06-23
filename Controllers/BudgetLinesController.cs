using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBAccess;

namespace BudgetAPI.Controllers
{
    public class BudgetLinesController : ApiController
    {
        public HttpResponseMessage Post([FromBody] Budget_line bl)
        {
            try
            {
                using (var entities = new BudgetCHEntities1())
                {
                    var response = entities.budgetLine(bl.line_id, bl.budget_id, bl.amount);
                    var message = Request.CreateResponse(HttpStatusCode.Created, bl);
                    message.Headers.Location = new Uri(Request.RequestUri + bl.bline_id.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
