using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace PlanYourLife1_4
{
    class Plans
    {
      public List<Plan> plans { set; get; }
        public Plans()
        {
            MySqlConnection connection = Connection();
            connection.Open();
            plans = new List<Plan>();
            string commandStr = "select* from plans";
            MySqlCommand command = new MySqlCommand(commandStr, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Plan ob = new Plan(Convert.ToInt32(reader[0]), Convert.ToDateTime(reader[1].ToString()), reader[2].ToString(), Convert.ToBoolean(reader[3]));
                plans.Add(ob);
            }
            connection.Close();
        }
      
        public void ShowPlans()
        {
           foreach(Plan plan in plans)
            {
                plan.ShowPlan();
            }
        }
       public static MySqlConnection Connection()
        {
            string connectionString = "server=127.0.0.1; user=root; database=planyourlife; password=;convert zero datetime=True;charset='utf8';";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}
