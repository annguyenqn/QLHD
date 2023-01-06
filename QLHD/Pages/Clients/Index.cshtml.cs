using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace QLHD.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=LAPTOP-L5VK15FG\\THEANDEV;Initial Catalog=Activity;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Account";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id_SV = reader.GetString(0);
                                clientInfo.fullName = reader.GetString(2);
                                clientInfo.permision = reader.GetString(3);
                                listClients.Add(clientInfo);

                            }
                        }
                    } 
                }
            }

            catch(Exception ex)
            {

            }

        }
    }
    public class ClientInfo{
        public string id_SV;
        public string userPass;
        public string fullName;
        public string permision;

    }
}
