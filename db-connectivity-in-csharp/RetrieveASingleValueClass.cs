using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_connectivity_in_csharp
{
    internal class RetrieveASingleValueClass
    {
        public static string RetrieveASingleValue(int ContactID)
        {
            SqlConnection connection = new SqlConnection(Program.connectionString);
            string query2 = "select FirstName from Contacts where Contacts.ContactID=@ContactID;";
            SqlCommand command = new SqlCommand(query2, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            string FirstName = "";
            try
            {
                connection.Open();
                object value = command.ExecuteScalar();
                FirstName = value.ToString();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("error ==>> " + e.Message);
            }
            return FirstName;
        }

    }
}
