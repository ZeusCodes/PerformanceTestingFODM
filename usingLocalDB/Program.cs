using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace usingLocalDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            var sqlConn = new MySqlConnection("server=feenix-mariadb.swin.edu.au;uid=s103484306;password=110203;database=s103484306_db;");
            //var sqlConn = new MySqlConnection("server=localhost;user id=root;password=Bhaibonuami@5;database=World;");

            using (sqlConn)
            {
                Console.WriteLine("Trying to Connect");
                try
                {
                    sqlConn.Open();
                    Console.WriteLine("Connected");
                    MySqlCommand myCommand = sqlConn.CreateCommand();
                    MySqlTransaction myTrans;

                    // Start a local transaction
                    myTrans = sqlConn.BeginTransaction();
                    // Must assign both transaction object and connection
                    // to Command object for a pending local transaction
                    myCommand.Connection = sqlConn;
                    myCommand.Transaction = myTrans;

                    ////Insert Statements
                    //myCommand.CommandText = "Insert into country VALUES ('ZZZ','Newly Created Country','Asia','Southern and Central Asia','652090.00','2022','22720000','45.9','5976.00','793.00','Newbie','Republic','Raja Baksha','245','NB')";
                    //myCommand.ExecuteNonQuery();
                    //myCommand.CommandText = "Insert into countrylanguage (CountryCode, Language, IsOfficial, Percentage) VALUES ('ZZZ', 'Elvy','T',90.1)";
                    //myCommand.ExecuteNonQuery();
                    //myCommand.CommandText = "INSERT INTO `city` VALUES(110001, 'Thiem', 'ZZZ' , 'Theoderr', 17800);";
                    //myCommand.ExecuteNonQuery();
                    //myTrans.Commit();
                    //Console.WriteLine("Both records are written to database.");

                    //////Update Statements
                    //myCommand.CommandText = "UPDATE countrylanguage SET Language='AANONE' WHERE CountryCode='ABW' AND Language='Dutch' ";
                    //myCommand.ExecuteNonQuery();
                    //myCommand.CommandText = "UPDATE city SET Name='AACity' WHERE ID='1' ";
                    //myCommand.ExecuteNonQuery();
                    //myCommand.CommandText = "UPDATE country SET Name='AACountry' WHERE Code='ABW'";
                    //myCommand.ExecuteNonQuery();
                    //myTrans.Commit();
                    //Console.WriteLine("Both records are UPDATED in database.");

                    ////Delete Statements
                    //myCommand.CommandText = "Delete from countrylanguage WHERE CountryCode='ABW'";
                    //myCommand.ExecuteNonQuery();
                    //myCommand.CommandText = "Delete from city WHERE CountryCode='ABW'";
                    //myCommand.ExecuteNonQuery();
                    //myCommand.CommandText = "Delete from country WHERE Code='ABW'";
                    //myCommand.ExecuteNonQuery();
                    //myTrans.Commit();
                    //Console.WriteLine("Both records are DELETED from database.");

                    //Read Statements
                    MySqlCommand cmd = new MySqlCommand("Select * from country;", sqlConn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine(reader);
                    while (reader.Read())
                    {
                        Console.WriteLine((string)reader["Name"]);
                    }
                    Console.WriteLine("Records READ from database.");

                    sqlConn.Close();
                    watch.Stop();
                    Console.WriteLine($"Execution Time to fetch from CLOUD DATABASE: {watch.ElapsedMilliseconds} ms");
                    //Console.WriteLine($"Execution Time to fetch from LOCAL DATABASE: {watch.ElapsedMilliseconds} ms");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Occured");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
