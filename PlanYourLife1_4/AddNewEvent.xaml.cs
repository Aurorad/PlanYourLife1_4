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
            try
            {
                DateTime date = this.DateOfNewEvent.SelectedDate.Value.Date;
                string text = new TextRange(TextOfNewEvent.Document.ContentStart,
                              TextOfNewEvent.Document.ContentEnd).Text;
                Plan addPlan = new Plan(date, text, false);
                MessageBox.Show("Подія успішно додана до бази данних!");
                this.Close();
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("Дату введено неправильно!");
            }
            
        }
    }
}
