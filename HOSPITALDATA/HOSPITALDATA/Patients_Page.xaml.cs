using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Patients_Page.xaml
    /// </summary>
    public partial class Patients_Page : Page
    {
        DataBase db = new DataBase();
        public ObservableCollection<Patients> patients { get; set; }
        public Patients_Page()
        {
            InitializeComponent();
            patients = new ObservableCollection<Patients>();
            LoadPatientsData();
        }

        private void LoadPatientsData()
        {
            var patientlis = db.GetPatients();

            foreach (var pat in patientlis)
            {
                patients.Add(pat);
            }
            patients_LB.ItemsSource = patients;
        }

        private void add_patient_Click(object sender, RoutedEventArgs e)
        {
            AddPatient addPatient = new AddPatient();

            if (addPatient.ShowDialog() == true)
            {
                if (addPatient.NewPatients != null)
                {
                    patients.Add(addPatient.NewPatients);
                }
            }
            LoadPatientsData();
        }


        private void del_patient_Click(object sender, RoutedEventArgs e)
        {
            Patients selectedPatient = patients_LB.SelectedItem as Patients;


            if (selectedPatient == null)
            {
                MessageBox.Show("Пожалуйста, выберите пациента для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show($"Вы действительно хотите удалить пациента {selectedPatient.FirstName} {selectedPatient.LastName}?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                db.RemoveFromPatients(selectedPatient.Id);

                patients.Remove(selectedPatient);

                MessageBox.Show("Пациент успешно удален.");
            }
        }
    }
}
