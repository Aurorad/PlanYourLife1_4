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
    /// Логика взаимодействия для ShowPlanWindow.xaml
    /// </summary>
    public partial class ShowPlanWindow : Window
    {
        private Plan plan;
        public ShowPlanWindow(object ob)
        {
           
            InitializeComponent();
            Plan = (Plan)ob;
            this.OurData.SelectedDate = Plan.date;
            this.OurText.Document.Blocks.Add(new Paragraph(new Run(Plan.text)));
            this.OurImplementation.IsChecked = Plan.implementation;

        }

        internal Plan Plan { get => plan; set => plan = value; }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            //first of all we check date and update it 
            DateTime end_date = this.OurData.SelectedDate.Value.Date;
            if (end_date != this.plan.date) this.plan.UpdateDate(end_date);
            //secondly we check text
            string new_text = new TextRange(OurText.Document.ContentStart,
                              OurText.Document.ContentEnd).Text;
            if (new_text != this.plan.text) this.plan.UpdateText(new_text);
            //at last we check the implementation
            //bool new_implementation = this.OurImplementation.Content;
            bool new_implementation;
            if (this.OurImplementation.IsChecked == true) new_implementation = true;
            else new_implementation = false;
            if (new_implementation != this.plan.implementation) this.plan.ChangeImplamentation();
            //MessageBox.Show(str);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.plan.DeleteFromDB();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
