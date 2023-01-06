using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace QLHD.Pages.Clients
{
    public class PlanModel : PageModel
    {
        public List<PlanInfo> listPlans = new List<PlanInfo>();
        public void OnGet()
        {
            ConnectionStringMananger cmng = new ConnectionStringMananger();
            string connectionString = cmng.getconnection();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "SELECT * FROM Plans";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PlanInfo planInfo = new PlanInfo();
                            planInfo.id_plan = reader.GetInt32(0);
                            planInfo.title = reader.GetString(1);
                            planInfo.time = reader.GetDateTime(2);
                            planInfo.place = reader.GetString(3);
                            planInfo.level =  reader.GetInt32(4);


                            listPlans.Add(planInfo);

                        }
                    }
                }
            }
        }
        public class PlanInfo
        {

            public int id_plan;
            public string title;
            public DateTime time;
            public string place;
            public int   level;

        }
    }
}
