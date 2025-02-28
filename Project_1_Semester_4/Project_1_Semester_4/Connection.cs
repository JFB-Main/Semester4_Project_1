using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Project_1_Semester_4
{
    internal class Connection
    {
        private static string connectionString = "server=localhost;user id=root;password=;database=Inventory;port=3306";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString); // Jangan langsung Open()
        }

        public static bool TestConnection()
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    return true; // Koneksi berhasil
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
