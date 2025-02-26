using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITALDATA
{
    public class DataBase
    {
        MySqlConnection connection = new MySqlConnection("user=root; password=1234; port=3306; server=localhost; database=hospital");

        public List<Patients> GetPatients()
        {
            List<Patients> patientslst = new List<Patients>();

            try
            {
                connection.Open();

                string query = "select * from patients";

                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Patients patients = new Patients();
                    patients.Id = Convert.ToInt32(reader["id_patient"]);
                    patients.FirstName = reader["firstname"].ToString();
                    patients.LastName = reader["lastname"].ToString();
                    patients.Phone = reader["phone"].ToString();
                    patients.Adress = reader["adress"].ToString();

                    patientslst.Add(patients);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return patientslst;
        }

        public void AddPatient(string firstname, string lastname, string phone, DateTime birthday, string adress)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO patients (firstname, lastname, phone, birthday, adress) VALUES (@firstname, @lastname, @phone, @birthday, @adress)";
                MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
                mySqlCommand.Parameters.AddWithValue("@firstname", firstname);
                mySqlCommand.Parameters.AddWithValue("@lastname", lastname);
                mySqlCommand.Parameters.AddWithValue("@phone", phone);
                mySqlCommand.Parameters.AddWithValue("@birthday", birthday);
                mySqlCommand.Parameters.AddWithValue("@adress", adress);

                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void RemoveFromPatients(int patientId)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("DELETE FROM patients WHERE id_patient = @patientId", connection);
            command.Parameters.AddWithValue("@patientId", patientId);

            
            command.ExecuteNonQuery();
            connection.Close();
        }



    }
}
