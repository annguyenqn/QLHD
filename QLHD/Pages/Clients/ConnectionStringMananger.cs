using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
namespace QLHD.Pages.Clients
{
    public class ConnectionStringMananger
    {
        public string getconnection()
        {
            return "Data Source=9H1ENY893ZBJDQQ\\LEEGNUH;Initial Catalog=Activity;Integrated Security=True;";
        }
    }
}
