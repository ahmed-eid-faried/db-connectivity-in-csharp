using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_connectivity_in_csharp
{
    internal class ParameterizedQueryClass
    {
        public static void ParameterizedQuery(string FirstName, int CountryID)
        {
            SqlConnection connection = new SqlConnection(Program.connectionString);
            //string query = "select * from Contacts where Contacts.FirstName=@FirstName";
            string query2 = "select * from Contacts where Contacts.FirstName=@FirstName and Contacts.CountryID=@CountryID;";
            SqlCommand command = new SqlCommand(query2, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactID}");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();

                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("error ==>> " + e.Message);
            }

        }

        public static void ParameterizedQueryUnSave(string FirstName, int CountryID)
        {
            SqlConnection connection = new SqlConnection(Program.connectionString);
            //string query = "select * from Contacts where Contacts.FirstName=@FirstName";
            string query2 = "select * from Contacts where Contacts.FirstName='" + FirstName + "' and Contacts.CountryID=" + CountryID + ";";
            Console.WriteLine(query2);
            SqlCommand command = new SqlCommand(query2, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {contactID}");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();

                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("error ==>> " + e.Message);
            }

        }

    }
}
