using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using db_connectivity_in_csharp;

public class Program
{

    public static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456;";






    public static void Main()
    {
        //PrintAllContacts.PrintAllContacts1();
        //PrintAllContacts.PrintAllContacts2();
        //ParameterizedQueryClass.ParameterizedQuery("john", 1);
        //ParameterizedQueryClass.ParameterizedQuery("john' and Contacts.LastName='Doe", 1);
        //ParameterizedQueryClass.ParameterizedQueryUnSave("john' and Contacts.LastName='Doe", 1);
        //ParameterizedQueryWithLikeClass.ParameterizedQueryWithLike();
        //Console.WriteLine(RetrieveASingleValueClass.RetrieveASingleValue(3));
        //ContactDataAccessClass.FindSingleContactView();
        //ContactDataAccessClass.InsertAddDataVeiw();
        ContactDataAccessClass.RetrieveAutoNumberAfterInsertingAddingDataView();

        Console.ReadKey();
    }

}
