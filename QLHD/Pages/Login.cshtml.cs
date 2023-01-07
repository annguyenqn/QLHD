using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLHD.Pages.Clients;
using System.Data.SqlClient;

namespace QLHD.Pages
{
    public class LoginModel : PageModel
    {        
        public void OnGet()
        {
        }
        public void OnPost()
        {
            string id = Request.Form["id_SV"];
            ConnectionStringMananger cmng = new ConnectionStringMananger();
            string connectionString = cmng.getconnection();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "SELECT * FROM Account WHERE id_SV=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            SessionLogin.id_SV = reader.GetString(0);
                            SessionLogin.userPass = reader.GetString(1);
                            SessionLogin.fullName = reader.GetString(2);
                            SessionLogin.permision = reader.GetString(3);
                        }
                    }
                }
    
                if(SessionLogin.userPass == Request.Form["password"]) 
                {
                    if (SessionLogin.permision == "admin")
                    {
                        Response.Redirect("/clients/index");
                    }    
                } 
                    
            }
        }
    }
    public static class SessionLogin
    {
        public static string id_SV;
        public static string userPass;
        public static string fullName;
        public static string permision;
    }
}
