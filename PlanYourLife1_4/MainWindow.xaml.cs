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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlanYourLife1_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Plans plansForDataGrid = new Plans();
            DataGridPlanYourLife.ItemsSource = plansForDataGrid.plans;
        }
        private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your want to create new event!");
            AddNewEvent addNewEventWindow = new AddNewEvent();
            addNewEventWindow.Show();
        }
        private void MenuItemUpdata_Click(object sender, RoutedEventArgs e)
        {
            Plans updataPlans = new Plans();
            this.DataGridPlanYourLife.ItemsSource = updataPlans.plans;
        }
    }
}
