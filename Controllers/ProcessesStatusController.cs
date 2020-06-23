using DBAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BudgetAPI.Controllers
{
    public class ProcessesStatusController : ApiController
    {
        public IEnumerable<pentingDirector_Result> GetPentingDirector(int reqID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.pentingDirector(reqID);
                var result = response.ToArray();
                return result;
            }
        }

        public IEnumerable<pentingDirectorReg_Result> GetPentingDirectorReg(int reqID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.pentingDirectorReg(reqID);
                var result = response.ToArray();
                return result;
            }
        }
        public IEnumerable<pendingOwner_Result> GetPentingOwner(int reqID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.pendingOwner(reqID);
                var result = response.ToArray();
                return result;
            }
        }
        public IEnumerable<acceptedDirector_Result> GetAcceptedDirector(int reqID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.acceptedDirector(reqID);
                var result = response.ToArray();
                return result;
            }
        }

        public IEnumerable<acceptedDirectorRegional_Result> GetAcceptedReg(int reqID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.acceptedDirectorRegional(reqID);
                var result = response.ToArray();
                return result;
            }
        }
        public IEnumerable<accteptedOwner_Result> GetAcceptedOwner(int reqID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.accteptedOwner(reqID);
                var result = response.ToArray();
                return result;
            }
        }

        public IEnumerable<rejectedDirector_Result> GetRejectedDirector(int reqID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.rejectedDirector(reqID);
                var result = response.ToArray();
                return result;
            }
        }

        public IEnumerable<rejectedDirectorRegional_Result> GetRejectedReg(int reqID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.rejectedDirectorRegional(reqID);
                var result = response.ToArray();
                return result;
            }
        }
        public IEnumerable<rejectedOwner_Result> GetRejectedOwner(int reqID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.rejectedOwner(reqID);
                var result = response.ToArray();
                return result;
            }
        }
    }
}
