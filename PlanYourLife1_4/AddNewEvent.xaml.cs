using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlanYourLife1_4
{
    /// <summary>
    /// Логика взаимодействия для AddNewEvent.xaml
    /// </summary>
    public partial class AddNewEvent : Window
    {
        public AddNewEvent()
        {
            InitializeComponent();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Here we should save new event to the database!");
            DateTime date = Convert.ToDateTime(this.DateOfNewEvent.DataContext);
            string text = this.TextOfNewEvent.ToString();
            MessageBox.Show("Date: " + date.ToString() + "\nText: " + text);
        }
    }
}
