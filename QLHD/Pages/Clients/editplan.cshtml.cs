using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static QLHD.Pages.Clients.PlanModel;

namespace QLHD.Pages.Clients
{
    public class editplanModel : PageModel
    {
        public PlanInfo PlanInfo = new PlanInfo();

        public void OnGet()
        {
            String id_plan = Request.Query["idplan"];

            try
            {
                ConnectionStringMananger cmng = new ConnectionStringMananger();
                string connectionString = cmng.getconnection();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Plans WHERE id_plan = @id_plan";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@id_plan", id_plan);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PlanInfo planInfo = new PlanInfo();
                                planInfo.id_plan = reader.GetInt32(0);
                                planInfo.title = reader.GetString(1);
                                planInfo.time = reader.GetDateTime(2);
                                planInfo.place = reader.GetString(3);
                                planInfo.level = reader.GetInt32(4);


                            }
                        }


                    }
                }
            }

            catch (Exception ex)
            {

            }
        }
        public void OnPost()
        {
            PlanInfo.id_plan = Int32.Parse(Request.Form["idplan"]);
            PlanInfo.title = Request.Form["title"];
            PlanInfo.time = DateTime.Parse(Request.Form["time"]);
            PlanInfo.place = Request.Form["place"];
            PlanInfo.level = Int32.Parse(Request.Form["level"]);
            try
            {
                ConnectionStringMananger cmng = new ConnectionStringMananger();
                string connectionString = cmng.getconnection();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "update  Plans " +
                        "set title=@title,time=@time,place=@place,level=@level" + "where id_plan=@id_plan";
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
            Response.Redirect("/Clients/plan");
        }
    }
    }
