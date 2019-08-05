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
        public ShowPlanWindow(object ob)
        {
            Plan plan = (Plan)ob;
            //this.OurText.Document.Blocks.Add(new Paragraph(new Run(plan.text)));
            
            InitializeComponent();
          
        }

       
    }
}
