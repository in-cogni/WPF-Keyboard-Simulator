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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 
    {
        public Window2(int num, double timePressed)
        {
            InitializeComponent();

            TextBlock.Text = $"Нажатые кнопки: {num}";
            TextBlock2.Text = $"Среднее время нажатия на кнопку: {timePressed:F2} ms";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
