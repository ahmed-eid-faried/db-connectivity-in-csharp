using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;

public class Program
{
    static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=YourStrong!Passw0rd;";

    static void PrintAllContacts()
    {

        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts";

        SqlCommand command = new SqlCommand(query, connection);

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) // to loop for all records
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


        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }


    }

    static void PrintAllContacts2()
    {

        SqlConnection connection = new SqlConnection(connectionString);
        const string qeury = "SELECT * FROM Contacts;";
        SqlCommand command = new SqlCommand(qeury, connection);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ContactID = (int)reader["ContactID"];
                string FirstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string Address = (string)reader["Address"];
                int CountryID = (int)reader["CountryID"];

                Console.WriteLine("ContactID ===>> " + ContactID);
                Console.WriteLine("FirstName ===>> " + FirstName);
                Console.WriteLine("LastName ===>> " + LastName);
                Console.WriteLine("Email ===>> " + Email);
                Console.WriteLine("Phone ===>> " + Phone);
                Console.WriteLine("Address ===>> " + Address);
                Console.WriteLine("CountryID ===>> " + CountryID);
                Console.WriteLine("\n\n\n");

            }
            reader.Close();
            connection.Close();
        }
        catch (Exception error)
        {

            Console.WriteLine("Error: " + error.Message);
        }

    }
    public static void Main()
    {
        PrintAllContacts2();

        Console.ReadKey();
    }

}
