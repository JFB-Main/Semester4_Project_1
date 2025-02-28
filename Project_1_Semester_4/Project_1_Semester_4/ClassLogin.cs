using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Project_1_Semester_4
{
    internal class ClassLogin
    {
        public bool LoginUser(string username, string password)
        {
            bool isAuthenticated = false;

            using (MySqlConnection conn = Connection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT password_hash FROM users WHERE username = @username";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string storedHash = result.ToString();
                            string inputHash = ComputeSHA256(password); 

                            // Bandingkan hash dari database dengan hash input
                            if (storedHash.Equals(inputHash, StringComparison.OrdinalIgnoreCase))
                            {
                                isAuthenticated = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

            return isAuthenticated;
        }

        // Fungsi untuk hashing SHA-1
        public static string ComputeSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower(); // Ubah ke format hex
            }
        }
    }
}
