using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Numerics;
using static QLHD.Pages.Clients.PlanModel;

namespace QLHD.Pages.Clients
{
    public class CreatePlanModel : PageModel
    {
        public PlanInfo PlanInfo = new PlanInfo();
        public string successadd = "";
        public void OnGet()
        {

        }
        public void OnPost()
        {
            PlanInfo.id_plan  = Int32.Parse(Request.Form["idplan"])  ;
            PlanInfo.title = Request.Form["title"];
            PlanInfo.time = DateTime.Parse(Request.Form["time"]);
            PlanInfo.place = Request.Form["place"];
            PlanInfo.level = Int32.Parse(Request.Form["level"]);
            successadd = "Thêm thành công";
            try
            {
                ConnectionStringMananger cmng = new ConnectionStringMananger();
                string connectionString = cmng.getconnection();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "insert into plans" +
                        "(id_plan,title,time,place,level) values " + "(@idplan,@title,@time,@place,@level);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@idplan", PlanInfo.id_plan);
                        command.Parameters.AddWithValue("@title", PlanInfo.title);
                        command.Parameters.AddWithValue("@time", PlanInfo.time);
                        command.Parameters.AddWithValue("@place", PlanInfo.place);
                        command.Parameters.AddWithValue("@level", PlanInfo.level);
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch
            {

            }
            Response.Redirect("/Clients/Plan");
        }
    }
}
