using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;

namespace Quiz
{
    class Dao
    {
        private MySqlConnection conn;

        private static readonly string SELECT_ALL = "SELECT * FROM `answer_question`";
        private static readonly string CREATE_RELEVANT_TABLES = @"
                CREATE TABLE IF NOT EXISTS `answer_question`(
                id INT NOT NULL AUTO_INCREMENT,
                question VARCHAR(250) NOT NULL,
                answer VARCHAR(50) NOT NULL,
                PRIMARY KEY (id)
                )";

        public Dao() { conn = Connection.CreateConnection(); CreateRelevantTables(); }


        public Model[] AllQuestionAnswers()
        {
            MySqlDataReader rdr = GetMySqlCommand(SELECT_ALL).ExecuteReader();

            //https://stackoverflow.com/questions/30600370/why-is-datareader-giving-enumeration-yielded-no-results

            Console.WriteLine(GetAllRows());
            Model[] a = new Model[GetAllRows()];

            while (rdr.Read())
            {
                Model ModelFromDataBase = new(rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString());
                Console.WriteLine(ModelFromDataBase.ToString());
                int b = Convert.ToInt32(rdr.GetValue(0));
                a[b - 1] = ModelFromDataBase;
            }

            rdr.Close();
            return a;
        }
        public int GetAllRows()
        {
            int AllRows;
            try
            {
                AllRows = Convert.ToInt32(GetMySqlCommand(SELECT_ALL).ExecuteScalar());
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                return 0;
            }
            return AllRows;
        }
        public void CreateRelevantTables()
        {
            GetMySqlCommand(CREATE_RELEVANT_TABLES).ExecuteNonQuery();
            //https://stackoverflow.com/questions/22993857/create-table-in-mysql-from-c-sharp
        }
        public MySqlCommand GetMySqlCommand(string SqlString)
        {
            MySqlCommand cmd = new(SqlString, conn);
            return cmd;
        }
    }
}
