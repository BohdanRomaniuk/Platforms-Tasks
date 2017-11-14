using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO.NET
{
    class NorthWindTasks
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ADO.NET.Properties.Settings.NorthwindConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Show the list of first and last names of the employees from London");
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT FirstName, LastName FROM Employees WHERE City='London';";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["FirstName"], reader["LastName"]);
            }
            reader.Close();

            Console.WriteLine("\nCalculate the count of employees from London");
            command.CommandText = "SELECT COUNT(*) AS EmployeeQuantity FROM Employees WHERE City='London';";
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine(reader["EmployeeQuantity"]);
            }
            reader.Close();



            connection.Close();
            Console.ReadKey();
        }
    }
}
