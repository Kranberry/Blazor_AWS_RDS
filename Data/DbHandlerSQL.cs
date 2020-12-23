//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Data;
//using System.Data.SqlClient;

//namespace AWS_RDS_Blazor.Data
//{
//    public class DbHandlerPostgresSQL
//    {
//        string connectString;
//        // cnn.Open() to open connection
//        // cnn.Close() to close it
//        // SqlCommand sqlCmd, creates a new instance of a command
//        // SqlCommand.Parameters.AddWithValue(valueParameter, value), adds value to the value parameters named inside the query string
//        // SqlDataReader creates an instance of a SQL connection stream
//        // SqlDataReader sqlDr = sqlCmd.ExecuteReader();, ExecuteReader creates a sqlDataReader object. Sends the command via the stream to the database
//        SqlConnection cnn;
//        // using(cnn = new SqlConnection(connectString)) { Do db stuff here }

//        // Constructor to initialize the sql connection
//        public DbHandlerPostgresSQL()
//        {
//            connectString = @"Data Source=database-1.ctkljihhvznt.eu-north-1.rds.amazonaws.com; Initial Catalog=BlazorTest; User ID=admin;Password=SLOn9V3HAy2cHP8niDmU";
//        }

//        // Check if said table exists inside the database
//        private bool TableExists(string table)
//        {

//            try
//            {
//                // This will check if the table exists
//                // Open the connection to the datbase
//                using (cnn = new SqlConnection(connectString))
//                {
//                    string query = $"SELECT TOP 1 * FROM {table};";
//                    SqlCommand sqlCmd = new SqlCommand(query, cnn);

//                    cnn.Open();
//                    SqlDataReader sd = sqlCmd.ExecuteReader();
//                    cnn.Close();
//                }
//                return true;
//            }
//            catch (Exception)
//            {
//                // Table does not exist
//                return false;
//            }
//        }

//        // Handle the insertions to the database
//        // table = the table to insert to, tableRows = the keys of each row, values = values to said keys [i] => [i]
//        private string InsertIntoDatabse(string table, string[] tableRows, string[] values)
//        {
//            // Build INSERT the query to said table, with said values
//            string query = $"INSERT INTO {table} (";
//            query += String.Join(", ", tableRows);
//            query += ") VALUES (@";
//            query += String.Join(", @", tableRows);
//            query += ");";

//            try
//            {
//                // Open the connection to the datbase
//                using (cnn = new SqlConnection(connectString))
//                {
//                    // Create the command
//                    SqlCommand sqlCmd = new SqlCommand(query, cnn);
//                    for (int i = 0; i < tableRows.Length; i++)
//                    {
//                        // Add all the values to said parameters
//                        sqlCmd.Parameters.AddWithValue($"@{tableRows[i]}", values[i]);
//                    }
//                    // Create the stream instance
//                    SqlDataReader sqlDr = sqlCmd.ExecuteReader();
//                    cnn.Close();

//                    return "Insertion successful!";
//                }
//            }
//            catch (Exception)
//            {
//                return "Something went wrong, Control your parameters!";
//            }
//        }

//        // Check the incoming insertion to see if it is valid
//        public string Insert(string table, string[] tableRows, string[] values)
//        {
//            if(TableExists(table))
//            {
//                // Check if amount of parameters and values match. Every parameter needs a value.
//                if (tableRows.Length == values.Length)
//                {
//                    // If table exist, and if parameters length and values length is good, run the query
//                    return InsertIntoDatabse(table, tableRows, values);
//                }
//                else
//                {
//                    return "Amount of parameters does not match amount of values";
//                }
//            }

//            return "You have entered an invalid table name";
//        }
        
//        // Handles removing rows from the database
//        // DELETES said row containing said ID from said table
//        public string RemoveUser(string table, int ID)
//        {
//            if (TableExists(table))
//            {
//                // Open the connection to the datbase
//                using (cnn = new SqlConnection(connectString))
//                {
//                    // Create the query
//                    string query = $"DELETE FROM {table} WHERE ID={ID}";

//                    // Create the command
//                    SqlCommand cmm = new SqlCommand(query, cnn);
//                    // Open the connection
//                    cnn.Open();
//                    // Execute query
//                    SqlDataReader dr = cmm.ExecuteReader();
//                    // Close connection
//                    cnn.Close();
//                }
//                return "Removed User successfully";
//            }

//            return "You have entered an invalid table name";
//        }
        
//        // Handles getting specific information from database.
//        // if ID = 0, get everything from said table
//        public List<User> GetUser(string table, int ID)
//        {
//            List<User> users = new List<User>();

//            if (TableExists(table))
//            {
//                // Open the connection to the datbase
//                using (cnn = new SqlConnection(connectString))
//                {
//                    // Create the query
//                    string query = $"SELECT * FROM {table}";
//                    if (ID > 0)
//                        query += $" WHERE ID={ID}";

//                    // Create the command
//                    SqlCommand cmm = new SqlCommand(query, cnn);
//                    // Represents commands and a database connection that is used to fill the DataSet and update the SQL database
//                    SqlDataAdapter da = new SqlDataAdapter(cmm);
//                    // Create a new datatable
//                    DataTable dt = new DataTable();
//                    da.Fill(dt);

//                    foreach (DataRow element in dt.Rows)
//                    {
//                        // The datatable uses index overloading to get the data you want.
//                        string id = element["ID"].ToString();
//                        string firstName = element["FirstName"].ToString();
//                        string lastName = element["LastName"].ToString();
//                        string email = element["Email"].ToString();

//                        users.Add(new User(UInt32.Parse(id), firstName, lastName, email));
//                    }

//                    cnn.Close();
//                }
//            }

//            // If the returned list is empty. Table does not exist
//            return users;
//        }

//        // Gets the amount of users inside the table Users
//        public int GetAmountOfUsers()
//        {
//            int count;
//            // Open the connection to the datbase
//            using (cnn = new SqlConnection(connectString))
//            {
//                // Create the query
//                string query = $"SELECT COUNT(*) FROM Users";

//                // Create the command
//                SqlCommand cmm = new SqlCommand(query, cnn);
//                // Execute query
//                count = (int)cmm.ExecuteScalar(); 
//                // Close connection
//                cnn.Close();
//            }

//            return count;
//        }
//    }
//}