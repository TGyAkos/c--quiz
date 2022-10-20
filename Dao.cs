using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    class Dao
    {
        private MySqlConnection conn;

        private static readonly string SELECT_ALL = "SELECT * FROM QUIZ ORDER BY Id";
        
        public Dao() { conn = Connection.CreateConnection(); }

        public MySqlDataReader AllQuestionAnswers()
        {
            MySqlCommand cmd = new MySqlCommand(SELECT_ALL, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            MySqlDataReader NewRdr = rdr;s
            rdr.Close();
            return NewRdr;
        }
        
    }
}
