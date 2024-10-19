using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_connectivity_in_csharp
{
    internal class ContactDataAccessClass
    {
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
        public static bool FindSingleContact(ref stContact Contact, int contactID)
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

        public static void FindSingleContactView()
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
    }
}
