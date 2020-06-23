using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBAccess;

namespace BudgetAPI.Controllers
{
    public class InvoicesController : ApiController
    {

        public IEnumerable<getAllInvoicesACC_Result> Get()
        {
            using (BudgetCHEntities1 entities = new BudgetCHEntities1())
            {
                var response = entities.getAllInvoicesACC();
                var result = response.ToArray();
                return result;
            }
        }

        public IEnumerable<budgetLinesID_Result> Get(int BudgetID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.budgetLinesID(BudgetID);
                var result = response.ToArray();
                return result;
            }
        }


        public HttpResponseMessage Post([FromBody] Invoices invoice)
        {
            try
            {
                using (var entities = new BudgetCHEntities1())
                {
                    var response = entities.newInvoice(invoice.invoice_number, invoice.invoice_date, invoice.customer, invoice.item_name, invoice.budget_ID, invoice.amount, invoice.line_id, invoice.dueDate, invoice.comment);
                    var message = Request.CreateResponse(HttpStatusCode.Created, invoice);
                    message.Headers.Location = new Uri(Request.RequestUri + invoice.invoice_id.ToString());
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
