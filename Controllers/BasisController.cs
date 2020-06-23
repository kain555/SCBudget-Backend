using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBAccess;

namespace BudgetAPI.Controllers
{
    public class BasisController : ApiController
    {
        public IEnumerable<GetBasis_Result> Get()
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.GetBasis();
                var result = response.ToArray();
                return result;
            }
        }
        public IEnumerable<getBudgetIdToProcess_Result> Get(int ownerID)
        {
            using (var entities = new BudgetCHEntities1())
            {
                var response = entities.getBudgetIdToProcess(ownerID);
                var result = response.ToArray();
                return result;
            }
        }

        public Budget Post(Budget bud)
        {
            string query = "INSERT INTO Budget(period,basis_id,owner_id,comment,project_id) OUTPUT INSERTED.budget_id VALUES (@period,@bas,@own,@com,@pro)";
            using (SqlConnection con = new SqlConnection(@"Server = LAP100MK\SQLSERVER; Database = BudgetCH; User Id=otoMotoAdmin;Password=hardPASS123;"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@period", bud.period);
                    cmd.Parameters.AddWithValue("@bas", bud.basis_id);
                    cmd.Parameters.AddWithValue("@own", bud.owner_id);
                    cmd.Parameters.AddWithValue("@com", bud.comment);
                    cmd.Parameters.AddWithValue("@pro", bud.project_id);
                    con.Open();
                    bud.budget_id = (int)cmd.ExecuteScalar();
                    con.Close();
                }
                return bud;
            }
        }
    }
}
