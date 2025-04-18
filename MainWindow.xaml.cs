using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        
        public int time;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(time);
            this.Close();
            window1.Show();
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            time = 10;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            time = 30;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            time = 60;
        }
    }
}
