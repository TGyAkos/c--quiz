using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Quiz
{
    class Connection
    {
        public static MySqlConnection CreateConnection()
        {
            string connStr = "server=tanulo;user=root;database=world;port=3306;password=tanulo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to db...");
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public static void CloseConnection(MySqlConnection conn)
        {
            Console.WriteLine("db closed");
            conn.Close();
        }
    }
}
