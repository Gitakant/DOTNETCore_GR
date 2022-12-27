using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyStore.Pages.Clients
{
    public class IndexModel : PageModel
    {
        //2.Define the list
        public List<ClientInfo>  listClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                //3.We need to connect to the database
                //4.Create the connection string, we can obtain it from our connection to the database
                //Goto server explorer -> Name of the cooncetion -> In prooperties we can get the connection string
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MyStore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "Select * from clients";
                    //below cmd will aloow us to execute the sqlquery
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name= reader.GetString(1);
                                clientInfo.email= reader.GetString(2);
                                clientInfo.phone= reader.GetString(3);
                                clientInfo.address= reader.GetString(4);
                                clientInfo.created_at= reader.GetDateTime(5).ToString();

                                listClients.Add(clientInfo);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    //1. Create the class
    public class ClientInfo
    {
        public string id;
        public string name;
        public string email;
        public string phone;
        public string address;
        public string created_at;

    }
}
