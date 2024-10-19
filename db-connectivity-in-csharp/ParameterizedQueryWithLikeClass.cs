using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_connectivity_in_csharp
{
    internal class ParameterizedQueryWithLikeClass
    {
        public static void SearchContactsStartsWith(string StartsWith)
        {
            SqlConnection connection = new SqlConnection(Program.connectionString);
            string query = "SELECT * FROM Contacts WHERE FirstName LIKE '' + @StartsWith +'%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StartsWith", StartsWith);
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

        public static void SearchContactsEndsWith(string EndsWith)
        {
            SqlConnection connection = new SqlConnection(Program.connectionString);
            string query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @EndsWith +'';";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EndsWith", EndsWith);
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

        public static void SearchContactsContainsWith(string Contains)
        {
            SqlConnection connection = new SqlConnection(Program.connectionString);
            string query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @Contains +'%';";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
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
        public static void ParameterizedQueryWithLike()
        {
            Console.WriteLine("=====================SearchContactsStartsWith j==============");
            SearchContactsStartsWith("j");
            Console.WriteLine("=====================SearchContactsEndsWith e==============");
            SearchContactsEndsWith("e");
            Console.WriteLine("=====================SearchContactsContainsWith ae==============");
            SearchContactsContainsWith("ae");
            Console.WriteLine("================================================================");
        }
    }
}
