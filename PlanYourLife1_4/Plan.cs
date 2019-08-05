using System;
using MySql.Data.MySqlClient;

namespace PlanYourLife1_4
{
     class Plan
    {
        public int id { set; get; }
        public DateTime date { set; get; }
        public string text { set; get; }
        public bool implementation { set; get; }
        /// <summary>
        /// Конструктор класу
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="text"></param>
        /// <param name="implementation"></param>
        public Plan(int id, DateTime date, string text, bool implementation)
        {
            this.id = id;
            this.date = date;
            this.text = text;
            this.implementation = implementation;
        }
        
        /// <summary>
        /// Конструктор, що створює новий екземпляр класу, надаючи йому наступний порядковий номер і додає даний план в бд
        /// </summary>
        /// <param name="date"></param>
        /// <param name="text"></param>
        /// <param name="implementation"></param>
        public Plan(DateTime date, string text, bool implementation)
        {
            MySqlConnection connection = Plans.Connection();
            connection.Open();
            string commandStr = "SELECT MAX(Id) FROM plans";
            MySqlCommand command = new MySqlCommand(commandStr, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int Id=1;
            while (reader.Read())
            {
                Id += Convert.ToInt32(reader[0]);
            }
            
            connection.Close();
            this.id = Id;
            this.date = date;
            this.text = text;
            this.implementation = implementation;
            this.AddToDB();
        }
        public void AddToDB()
        {
            string DateStr = this.date.ToString("yyyy-MM-dd hh:mm:ss");
            string commandStr = "INSERT INTO plans (Id, Date, Text, Implementation) VALUES " +
                "('"+this.id+"', '"+DateStr+"', '"+this.text+"', '"+this.implementation+"')";
            MySqlConnection connection = Plans.Connection();
            connection.Open();
            MySqlCommand command = new MySqlCommand(commandStr, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteFromDB()
        {
            string commandStr = "DELETE FROM plans WHERE Id='" + this.id + "'";
            MySqlConnection connection = Plans.Connection();
            connection.Open();
            MySqlCommand command = new MySqlCommand(commandStr, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateDate(DateTime newDate)
        {
            string DateStr = newDate.ToString("yyyy-MM-dd hh:mm:ss");
            string commandStr="UPDATE plans SET Date='"+DateStr+ "'" +
                " WHERE Id='" + this.id + "'";
            MySqlConnection connection = Plans.Connection();
            connection.Open();
            MySqlCommand command = new MySqlCommand(commandStr, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
      
        public void UpdateText(string Text)
        {
            string commandStr= "UPDATE plans SET Text='" + Text + "' WHERE Id='" + this.id + "'";
            MySqlConnection connection = Plans.Connection();
            connection.Open();
            MySqlCommand command = new MySqlCommand(commandStr, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ChangeImplamentation()
        {
            bool newImplemetation = !this.implementation;
            string commandStr = "UPDATE plans SET Implementation='" + newImplemetation + "' WHERE Id='" + this.id + "'";
            MySqlConnection connection = Plans.Connection();
            connection.Open();
            MySqlCommand command = new MySqlCommand(commandStr, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// Виводить на консоль об'єкт класу 
        /// </summary>
        public void ShowPlan()
        {
            Console.WriteLine(id + "\t" + date + "\t" + text + "\t" + implementation);
        }
    }
}
