using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace QLHD.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string successadd = "";
        public void OnGet()
        {

        }
        public void  OnPost()
        {
            clientInfo.id_SV = Request.Form["idsv"];
            clientInfo.userPass = "1234";
            clientInfo.fullName = Request.Form["name"];
            clientInfo.permision = Request.Form["permision"];
            successadd = "Thêm thành công";
            try
            {
                String connectionString = "Data Source=LAPTOP-L5VK15FG\\THEANDEV;Initial Catalog=Activity;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "insert into Account"+
                        "(id_Sv,userPass,fullName,permision) values " + "(@idsv,'1234',@name,@permision);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@idsv",clientInfo.id_SV);
                        command.Parameters.AddWithValue("@userPass", clientInfo.userPass);
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
