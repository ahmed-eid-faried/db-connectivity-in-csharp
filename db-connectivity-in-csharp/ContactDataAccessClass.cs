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
            SqlConnection connection = new SqlConnection(Program.connectionString);
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
        public static void InsetContact(stContact Contact)
        {
            SqlConnection connection = new SqlConnection(Program.connectionString);
            string query2 = @"INSERT INTO Contacts
           (FirstName,
            LastName,
            Email,
            Phone,
            Address,
            CountryID)
     VALUES
           (@FirstName, 
            @LastName, 
            @Email, 
            @Phone, 
            @Address, 
            @CountryID);";
            SqlCommand command = new SqlCommand(query2, connection);
            command.Parameters.AddWithValue("@FirstName", Contact.firstName);
            command.Parameters.AddWithValue("@LastName", Contact.lastName);
            command.Parameters.AddWithValue("@Email", Contact.email);
            command.Parameters.AddWithValue("@Phone", Contact.phone);
            command.Parameters.AddWithValue("@Address", Contact.address);
            command.Parameters.AddWithValue("@CountryID", Contact.countryID);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record inserted successfully.");
                }
                else
                {
                    Console.WriteLine("Record insertion failed.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error ==>> " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void InsertAddDataVeiw()
        {
            stContact Contact = new stContact
            {
                firstName = "AHMED",
                lastName = "MADY",
                email = "m@example.com",
                phone = "1234567890",
                address = "123 Main Street",
                countryID = 1
            };
            InsetContact(Contact);
        }
        public static int RetrieveInsetContact(stContact Contact)
        {
            SqlConnection connection = new SqlConnection(Program.connectionString);
            string query2 = @"INSERT INTO Contacts
           (FirstName, LastName, Email, Phone, Address, CountryID)
           VALUES
           (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID);
            Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query2, connection);
            command.Parameters.AddWithValue("@FirstName", Contact.firstName);
            command.Parameters.AddWithValue("@LastName", Contact.lastName);
            command.Parameters.AddWithValue("@Email", Contact.email);
            command.Parameters.AddWithValue("@Phone", Contact.phone);
            command.Parameters.AddWithValue("@Address", Contact.address);
            command.Parameters.AddWithValue("@CountryID", Contact.countryID);
            int InsertedID = -1;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    Console.WriteLine($"Newly inserted ID: {insertedID}");
                    InsertedID = insertedID;
                }
                else
                {
                    Console.WriteLine("Failed to retrieve the inserted ID.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error ==>> " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return InsertedID;

        }
        public static void RetrieveAutoNumberAfterInsertingAddingDataView()
        {
            stContact Contact = new stContact
            {
                firstName = "AHMED22 ",
                lastName = "MADY333",
                email = "m@example.com",
                phone = "1234567890",
                address = "123 Main Street",
                countryID = 1
            };
            Console.WriteLine(RetrieveInsetContact(Contact));
        }
        public static void UpdateContactInfo(int ContactID, stContact Contact)
        {
            SqlConnection connection = new SqlConnection(Program.connectionString);
            string query2 = @"UPDATE Contacts
           SET
           Contacts.FirstName=@FirstName,
           Contacts.LastName=@LastName,
           Contacts.Email=@Email,
           Contacts.Phone=@Phone,
           Contacts.Address=@Address,
           Contacts.CountryID=@CountryID
           WHERE Contacts.ContactID=@ContactID";
            SqlCommand command = new SqlCommand(query2, connection);
            command.Parameters.AddWithValue("@FirstName", Contact.firstName);
            command.Parameters.AddWithValue("@LastName", Contact.lastName);
            command.Parameters.AddWithValue("@Email", Contact.email);
            command.Parameters.AddWithValue("@Phone", Contact.phone);
            command.Parameters.AddWithValue("@Address", Contact.address);
            command.Parameters.AddWithValue("@CountryID", Contact.countryID);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record Updated successfully.");
                }
                else
                {
                    Console.WriteLine("Record Upadate failed.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error ==>> " + e.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        public static void UpdateContactInfoView()
        {
            stContact Contact = new stContact
            {
                firstName = "AHMED22 ",
                lastName = "MADY333",
                email = "m@example.com",
                phone = "1234567890",
                address = "123 Main Street",
                countryID = 1
            };
            UpdateContactInfo(2, Contact);
        }
        public static void DeleteContact(int contactID)
        {
            SqlConnection connection = new SqlConnection(Program.connectionString);
            string query2 = "delete from Contacts where  Contacts.contactID=@contactID;";
            SqlCommand command = new SqlCommand(query2, connection);
            command.Parameters.AddWithValue("@contactID", contactID);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record Deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Record Delete failed.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error ==>> " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }


    }
}
