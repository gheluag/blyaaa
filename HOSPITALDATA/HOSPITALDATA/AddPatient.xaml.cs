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

namespace HOSPITALDATA
{
    /// <summary>
    /// Логика взаимодействия для AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        private DataBase db = new DataBase();
        public Patients NewPatients { get; private set; }
        public AddPatient()
        {
            InitializeComponent();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            string firstname = firstnameTb.Text;
            string lastname = lastnameTb.Text;
            string adress = adressTb.Text;
            string phone = phoneTb.Text;
            DateTime birthday = datePick.SelectedDate.HasValue ? datePick.SelectedDate.Value.Date : DateTime.Now.Date;

            if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname) 
                || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(adress)
                || !datePick.SelectedDate.HasValue)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            db.AddPatient(firstname, lastname, phone, birthday, adress);

            Patients newPatient = new Patients
            {
                FirstName = firstname,
                LastName = lastname,
                Phone = phone,
                BirthDay = birthday,
                Adress = adress
            };
            MessageBox.Show("Пациент добавлен успешно!"); 
            ClearFields();
            this.DialogResult = true;
            Close();

        }
        private void ClearFields()
        {
            firstnameTb.Text = string.Empty;
            lastnameTb.Text = string.Empty;
            phoneTb.Text = string.Empty;
            adressTb.Text = string.Empty;
            datePick.SelectedDate = null; 
        }
    }
}
