using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace AWS_RDS_Blazor.Data
{
    public class DbHandlerPostgresSQL
    {
        // Create a connection stream, and open the connection with conn.Open()
        // using (NpgsqlConnection conn = new NpgsqlConnection(connectString)) { conn.Open() }
        // Create a command instance to run the query to the database. cmd.ExecuteNonQuery() will execute the command
        // using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn)) { cmd.ExecuteNonQuery(); }
        // Create a database reader. This will read from the database where the command has selected from
        // NpgsqlDataReader reader = cmd.ExecuteReader();
        // reader.Read() will count all the rows and read said row
            // while (reader.Read())
                // Get every value using index overlaoding
                // string id = reader["id"].ToString();
        // ExecuteScalar is good when you work with returning numbers from the database
        // count = (long)cmd.ExecuteScalar();
        // Execute the command to the database
        // cmd.ExecuteNonQuery();

        string connectString;
        // server ip
        string server = "postgresqlserver.cglgqia5tb4l.eu-west-3.rds.amazonaws.com";
        // Master user name
        string userName = "postgres";
        // Name of the database
        string database = "blazortest";
        // inbound port number
        string port = "5432";
        // Master password
        string password = "lB7zLzq90D6Gwu8hdwVD";

        // Constructor to initialize the sql connection
        public DbHandlerPostgresSQL()
        {
            connectString = $"Server={server};Username={userName};Database={database};Port={port};Password={password};";
        }

        // Check if said table exists inside the database
        private bool TableExists(string table)
        {
            try
            {
                // This will check if the table exists
                // Open the connection to the datbase
                using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
                {
                    conn.Open();
                    // Create the query
                    string query = $"SELECT * FROM Users LIMIT 1";

                    // Create the command
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        // reader reads is used to read every row
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                // Table does not exist
                return false;
            }
        }

        // Handle the insertions to the database
        // table = the table to insert to, tableRows = the keys of each row, values = values to said keys [i] => [i]
        private string InsertIntoDatabse(string table, string[] tableRows, string[] values)
        {
            // Build INSERT the query to said table, with said values
            string query = $"INSERT INTO {table} (";
            query += String.Join(", ", tableRows);
            query += ") VALUES (@";
            query += String.Join(", @", tableRows);
            query += ");";

            try
            {
                // Open the connection to the datbase
                using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
                {
                    conn.Open();
                    // Create the command
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        for (int i = 0; i < tableRows.Length; i++)
                        {
                            // Add all the values to said parameters
                            cmd.Parameters.AddWithValue($"{tableRows[i]}", values[i]);
                        }
                        cmd.ExecuteNonQuery();
                    }
                    return "Insertion successful!";
                }
            }
            catch (Exception)
            {
                return "Something went wrong, Control your parameters!";
            }
        }

        // Check the incoming insertion to see if it is valid
        public string Insert(string table, string[] tableRows, string[] values)
        {
            if(TableExists(table))
            {
                // Check if amount of parameters and values match. Every parameter needs a value.
                if (tableRows.Length == values.Length)
                {
                    // If table exist, and if parameters length and values length is good, run the query
                    return InsertIntoDatabse(table, tableRows, values);
                }
                else
                {
                    return "Amount of parameters does not match amount of values";
                }
            }
            return "You have entered an invalid table name";
        }
        
        // Handles removing rows from the database
        // DELETES said row containing said ID from said table
        public string RemoveUser(string table, int ID)
        {
            if (TableExists(table))
            {
                // Open the connection to the datbase
                using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
                {
                    conn.Open();
                    // Create the query
                    string query = $"DELETE FROM {table} WHERE ID={ID}";

                    using(NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Removed User successfully";
            }

            return "You have entered an invalid table name";
        }
        
        // Handles getting specific information from database.
        // if ID = 0, get everything from said table
        public List<User> GetUser(string table, int ID)
        {
            List<User> users = new List<User>();

            if (TableExists(table))
            {
                // Open the connection to the datbase
                using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
                {
                    conn.Open();
                    // Create the query
                    string query = $"SELECT * FROM {table}";
                    if (ID > 0)
                        query += $" WHERE ID={ID}";
                    query += ";";

                    // Create the command
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            // Get every value using index overlaoding
                            string id = reader["id"].ToString();
                            string firstName = reader["firstname"].ToString();
                            string lastName = reader["lastname"].ToString();
                            string email = reader["email"].ToString();

                            users.Add(new User(UInt32.Parse(id), firstName, lastName, email));
                            Console.WriteLine("asdasd");
                        }
                        reader.Close();

                    }
                }
            }
            // If the returned list is empty. Table does not exist
            return users;
        }

        // WORKING!
        // Gets the amount of users inside the table Users
        public int GetAmountOfUsers()
        {
            long count;
            // Open the connection to the datbase
            using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
            {
                conn.Open();
                // Create the query
                string query = $"SELECT COUNT(*) FROM Users";

                // Create the command
                using(NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    count = (long)cmd.ExecuteScalar();
                }
            }

            return (int)count;
        }
    }
}