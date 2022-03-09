using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


//This class is kind of my assignment stretch I suppose. I wanted to learn how to use sqlite with C#. For this to work, you need to alter the path
//for the db file to match your system. I don't know where the default project root is because when I used the Data Source as being just "states.db"
//it didn't find the file.
namespace AnvilStore
{
    public class Data
    {
        public bool IsValid { get; set; }

        public Data()
        {
            this.IsValid = false;
        }

        public SqliteConnection OpenConn()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\ericsergio\\source\\repos\\SqliteDemo\\states.db");
            connection.Open();
            return connection;
        }
        //This simply displays all the possibilities of valid values in 10 columns. This still needs to be incorporated in the main data flow.
        public void DisplayStateValues()
        {
            var conn = OpenConn();

            var command = conn.CreateCommand();
            command.CommandText = @"SELECT state_code FROM states WHERE id > $id";
            command.Parameters.AddWithValue("$id", 0);

            var reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                //if iteration divided by 10 has a remainder of 0 then go to next line
                //this is for formatting.
                if (i % 10 == 0)
                {
                    Console.WriteLine();
                }
                var name = reader.GetString(0);
                Console.Write($"{name} ");
                i++;
            }
        }
        //This is the validation method for the state code.
        //  TO DO: for the 2nd assignment with the new/different user requirements, this is how I will
        //  differenciate the shipping by state the customer is ordering from
        public int CheckState(string statecode)
        {
            var conn = OpenConn();
            var command = conn.CreateCommand();
            command.CommandText = @"SELECT state_code FROM states";
            //command.Parameters.AddWithValue("$statecode", statecode);
            var reader = command.ExecuteReader();
            string[] StateCodes = new string[57];
            int i = 0;
            while (reader.Read())
            {
                var name = reader.GetString(0);                
                StateCodes[i] = name;
                if (StateCodes[i] == statecode)
                {                    
                    this.IsValid = true;
                }
                i++;
            }
           if(IsValid != true)
            {
                //Console.WriteLine($"{statecode} is not a valid State Code, Please enter a valid State Code");
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
