using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyStore.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost() 
        { 
            clientInfo.name= Request.Form["name"];
            clientInfo.email= Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo.address= Request.Form["address"];

            if (clientInfo.name.Length == 0 || clientInfo.email.Length == 0 || clientInfo.address.Length == 0 || clientInfo.phone.Length == 0)
            {
                errorMessage = "All the fileds are required";
                return;
            }
            //save the new client into the database
            try
            {
                //3.We need to connect to the database
                //4.Create the connection string, we can obtain it from our connection to the database
                //Goto server explorer -> Name of the cooncetion -> In prooperties we can get the connection string
                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MyStore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO clients " +
                        "(name,email,phone,address) VALUES " +
                        "(@name,@email,@phone,@address);";
                    //below cmd will aloow us to execute the sqlquery
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", clientInfo.name);
                        command.Parameters.AddWithValue("email", clientInfo.email);
                        command.Parameters.AddWithValue("address", clientInfo.address);
                        command.Parameters.AddWithValue("@phone", clientInfo.phone);

                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            clientInfo.name = "";
            clientInfo.email = "";
            clientInfo.phone = "";
            clientInfo.address = "";
            successMessage = "New client added successfully";

            Response.Redirect("/Clients/Index");
        }
    }
}
