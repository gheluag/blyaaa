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

namespace HOSPITALDATA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void patient_btn_Click(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Patients_Page());
        }

        private void doctor_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void appontment_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void department_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
