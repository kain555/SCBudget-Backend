using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBAccess;

namespace BudgetAPI.Controllers
{
    public class NewProcessController : ApiController
    {
        public HttpResponseMessage Post([FromBody] Processes process)
        {
            try
            {
                using (var entities = new BudgetCHEntities1())
                {
                    var response = entities.newProcess(process.basis_id, process.budget_ID, process.step_id, process.status_id, process.startedBy, process.requestor, process.asignedTo, process.actionDate, process.comment);
                    var message = Request.CreateResponse(HttpStatusCode.Created, process);
                    message.Headers.Location = new Uri(Request.RequestUri + process.process_id.ToString());
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
