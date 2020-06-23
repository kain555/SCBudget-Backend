using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBAccess;

namespace BudgetAPI.Controllers
{
    public class ProcessStepController : ApiController
    {
        public HttpResponseMessage Post([FromBody] Processes proc)
        {
            try
            {
                using (var entities = new BudgetCHEntities1())
                {
                    var response = entities.nextStep(proc.process_id, proc.actionDate, proc.step_id, proc.requestor, proc.asignedTo);
                    var message = Request.CreateResponse(HttpStatusCode.Created, proc);
                    message.Headers.Location = new Uri(Request.RequestUri + proc.process_id.ToString());
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
