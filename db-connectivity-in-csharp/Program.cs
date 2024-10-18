using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;

public class Program
{

    static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456;";

    static void PrintAllContacts()
    {

        SqlConnection connection = new SqlConnection(connectionString);

        string query = "SELECT * FROM Contacts";

        SqlCommand command = new SqlCommand(query, connection);
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


        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }


    }
    static void PrintAllContacts2()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        string query = "select * from Contacts";
        SqlCommand command = new SqlCommand(query, connection);
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
            Console.WriteLine("Error: " + e.Message);

        }



    }
    static void ParameterizedQuery(string FirstName, int CountryID)
    {
        SqlConnection connection = new SqlConnection(connectionString);
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

    static void ParameterizedQueryUnSave(string FirstName, int CountryID)
    {
        SqlConnection connection = new SqlConnection(connectionString);
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

    static void SearchContactsStartsWith(string StartsWith)
    {
        SqlConnection connection = new SqlConnection(connectionString);
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

    static void SearchContactsEndsWith(string EndsWith)
    {
        SqlConnection connection = new SqlConnection(connectionString);
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

    static void SearchContactsContainsWith(string Contains)
    {
        SqlConnection connection = new SqlConnection(connectionString);
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
    static void ParameterizedQueryWithLike(){
        Console.WriteLine("=====================SearchContactsStartsWith j==============");
        SearchContactsStartsWith("j");
        Console.WriteLine("=====================SearchContactsEndsWith e==============");
        SearchContactsEndsWith("e");
        Console.WriteLine("=====================SearchContactsContainsWith ae==============");
        SearchContactsContainsWith("ae");
        Console.WriteLine("================================================================");
    }

    public static void Main()
    {
        //PrintAllContacts2();
        //ParameterizedQuery("john", 1);
        //ParameterizedQuery("john' and Contacts.LastName='Doe", 1);
        //ParameterizedQueryUnSave("john' and Contacts.LastName='Doe", 1);
        ParameterizedQueryWithLike();
        Console.ReadKey();
    }

}
