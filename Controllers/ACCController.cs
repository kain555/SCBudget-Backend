using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBAccess;

namespace BudgetAPI.Controllers
{
    public class ACCController : ApiController
    {
        public IEnumerable<showACC_Result> Get()
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.showACC();
                var result = response.ToList();
                return result;
            }
        }
        public IEnumerable<invoicesByCustomer_Result> Get(int startedBy)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.invoicesByCustomer(startedBy);
                var result = response.ToArray();
                return result;
            }
        }

        public HttpResponseMessage Post([FromBody] Invoices i)
        {
            try
            {
                using (var entities = new BudgetCHEntities1())
                {
                    var response = entities.registerByACC(i.invoice_id);
                    var message = Request.CreateResponse(HttpStatusCode.Created, i);
                    message.Headers.Location = new Uri(Request.RequestUri + i.invoice_id.ToString());
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
