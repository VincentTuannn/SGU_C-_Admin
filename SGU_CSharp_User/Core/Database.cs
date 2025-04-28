using Microsoft.Data.SqlClient;
using DotNetEnv;

namespace SGU_CSharp_User.Core
{
    public sealed class Database
    {
        private static Lazy<Database> instance = new(() => new Database());
        private readonly string connectionString;

        // Private constructor to prevent instantiation
        private Database()
        {
            // Load environment variables from .env file
            Env.Load();

            // Get the connection string from the environment variables
            connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            //Print the connection string for debugging purposes
            Console.WriteLine($"Connection String: {connectionString}");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not defined in the .env file.");
            }
        }

        // Public property to access the singleton instance
        public static Database Instance => instance.Value;

        // Method to get a new SQL connection
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // For testing purposes only
        internal static void ResetInstance()
        {
            instance = new Lazy<Database>(() => new Database());
        }
    }
}
