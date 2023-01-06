using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
namespace QLHD.Pages.Clients
{
    public class ConnectionStringMananger
    {
    public string getconnection()
        {
            return "Data Source=LAPTOP-L5VK15FG\\THEANDEV;Initial Catalog=Activity;Integrated Security=True;";
        }
    }
}
