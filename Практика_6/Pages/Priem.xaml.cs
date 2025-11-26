using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

using Практика_6;
using Практика_7;
using Практика_7.Classes;

namespace Практика_7.Pages
{
    /// <summary>
    /// Логика взаимодействия для Priem.xaml
    /// </summary>
    public partial class Priem : Page
    {
        private Doctor people = new Doctor();
        public Pacient patient = new Pacient();
        public Pacient patients = new Pacient();
        public ObservableCollection<Reception> Receptions { get; set; } = new();
        public ObservableCollection<Pacient> Pacients { get; set; } = new();
        public ObservableCollection<Pacient> Pacients2 { get; set; } = new();

        public Reception? SelectedPac { get; set; }
        public Priem(Doctor d, ObservableCollection<Pacient> Pacientes, Pacient pacientos)
        {
            Pacients = Pacientes;

            Receptions = pacientos.AppointmentStories;
            patients = pacientos;
            InitializeComponent();
            people = d;
            Priem_Pat.DataContext = patient;
            DataContext = this;
            
        }

        private void Delete_Priem(object sender, RoutedEventArgs e)
        {

            if (SelectedPac == null)
            {
                MessageBox.Show("Пользователь не выбран");
                return;
            }
            else
            {
                patients.AppointmentStories.Remove(SelectedPac);
                var currentpacient = patients;
                    int i = Convert.ToInt32(patients.Id);
                    Receptions = patients.AppointmentStories;
                    string jsonString = JsonSerializer.Serialize(currentpacient);
                    string fileName = $"P_{i.ToString().PadLeft(7, '0')}.json";
                    File.WriteAllText(fileName, jsonString);
                    Receptions.Remove(SelectedPac);


            }

        }
        private void Save_Priem(object sender, RoutedEventArgs e)
        {
            try
            {
                if (people.Name != null)
                {
                    var currentpacient = patient;
                    if (patient.Recomendations != null && patient.Diagnosis != null)
                    {
                        int i = Convert.ToInt32(patient.Id);
                        Reception r = new Reception();
                        r.Doctor_id = Convert.ToInt32(people.Id);
                        r.Date = DateTime.Now.ToString();
                        r.Diagnosis = patient.Diagnosis;
                        r.Recomendations = patient.Recomendations;
                        currentpacient.AppointmentStories.Add(r);
                        patient = currentpacient;
                        Receptions = patient.AppointmentStories;
                        string jsonString = JsonSerializer.Serialize(currentpacient);
                        string fileName = $"P_{i.ToString().PadLeft(7, '0')}.json";
                        File.WriteAllText(fileName, jsonString);
                        MessageBox.Show($"Ваш ID={i.ToString().PadLeft(7, '0')}");
                        NavigationService.GoBack();

                    }
                    else
                    {
                        MessageBox.Show($"Есть пустые поля {patient.Last_Name} {patient.Middle_Name} {patient.BirthDay} {patient.Diagnosis} {patient.Recomendations}");
                    }
                }
                else
                {
                    MessageBox.Show("Сначала войдите как доктор");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Change_Inf(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Change_Information(Pacients, patients));
        }
    }
}
