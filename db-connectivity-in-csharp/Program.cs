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
    static void ParameterizedQueryWithLike()
    {
        Console.WriteLine("=====================SearchContactsStartsWith j==============");
        SearchContactsStartsWith("j");
        Console.WriteLine("=====================SearchContactsEndsWith e==============");
        SearchContactsEndsWith("e");
        Console.WriteLine("=====================SearchContactsContainsWith ae==============");
        SearchContactsContainsWith("ae");
        Console.WriteLine("================================================================");
    }
    static string RetrieveASingleValue(int ContactID)
    {
        SqlConnection connection = new SqlConnection(connectionString);
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

    public struct stContact
    {
        public int contactID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int countryID { get; set; }
    }
    static bool FindSingleContact(ref stContact Contact, int contactID)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        string query2 = "select * from Contacts where  Contacts.contactID=@contactID;";
        SqlCommand command = new SqlCommand(query2, connection);
        command.Parameters.AddWithValue("@contactID", contactID);
        bool isFound = false;
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                isFound = true;
                Contact.contactID = (int)reader["ContactID"];
                Contact.firstName = (string)reader["FirstName"];
                Contact.lastName = (string)reader["LastName"];
                Contact.email = (string)reader["Email"];
                Contact.phone = (string)reader["Phone"];
                Contact.address = (string)reader["Address"];
                Contact.countryID = (int)reader["CountryID"];
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("error ==>> " + e.Message);
        }
        return isFound;
    }

    static void FindSingleContactView()
    {

        stContact Contact = new stContact();
        if (FindSingleContact(ref Contact, 1))
        {
            Console.WriteLine($"Contact ID: {Contact.contactID}");
            Console.WriteLine($"Name: {Contact.firstName} {Contact.lastName}");
            Console.WriteLine($"Email: {Contact.email}");
            Console.WriteLine($"Phone: {Contact.phone}");
            Console.WriteLine($"Address: {Contact.address}");
            Console.WriteLine($"Country ID: {Contact.countryID}");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"Contact ID is Not Found");

        }
    }
    public static void Main()
    {
        //PrintAllContacts2();
        //ParameterizedQuery("john", 1);
        //ParameterizedQuery("john' and Contacts.LastName='Doe", 1);
        //ParameterizedQueryUnSave("john' and Contacts.LastName='Doe", 1);
        //ParameterizedQueryWithLike();
        //Console.WriteLine(RetrieveASingleValue(3));
        FindSingleContactView();


        Console.ReadKey();
    }

}
