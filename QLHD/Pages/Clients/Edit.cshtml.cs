using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace QLHD.Pages.Clients
{
    public class EditModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public void OnGet()
        {
            String id_SV = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=LAPTOP-L5VK15FG\\THEANDEV;Initial Catalog=Activity;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Account WHERE id_SV = @id_SV";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@id_SV", id_SV);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                clientInfo.id_SV = reader.GetString(0);
                                clientInfo.fullName = reader.GetString(2);
                                clientInfo.permision = reader.GetString(3);


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
            clientInfo.id_SV = Request.Form["id_SV"];
            clientInfo.fullName = Request.Form["name"];
            clientInfo.permision = Request.Form["permision"];
            try
            {
                String connectionString = "Data Source=LAPTOP-L5VK15FG\\THEANDEV;Initial Catalog=Activity;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "update  Account " +
                        "set fullName=@name,Permision=@permision " + "where id_SV=@id_SV";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_SV", clientInfo.id_SV);
                        command.Parameters.AddWithValue("@name", clientInfo.fullName);
                        command.Parameters.AddWithValue("@permision", clientInfo.permision);
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch
            {

            }
            Response.Redirect("/Clients/Index");
        }
    }
}
