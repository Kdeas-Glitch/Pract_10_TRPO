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
using Практика_7.Classes;

namespace Практика_7.Pages
{
    /// <summary>
    /// Логика взаимодействия для Priem.xaml
    /// </summary>
    public partial class Priem : Page
    {
        private Doctor people = new Doctor();
        private Pacient patient = new Pacient();
        public ObservableCollection<Reception> reception { get; set; } = new();
        ObservableCollection<Pacient> pacients;
        public Reception? SelectedPac { get; set; }
        public Priem(Doctor d, ObservableCollection<Pacient> Pacients)
        {
            InitializeComponent();
            people = d;
            Priem_Pat.DataContext = patient;
            FindPatient.DataContext = patient;
            List_Pac_Ap.DataContext = this;
            pacients = Pacients;
            reception = new ObservableCollection<Reception>();
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
                reception.Remove(SelectedPac);
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
                        reception = patient.AppointmentStories;
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

        private void Find(object sender, RoutedEventArgs e)
        {
            try
            {
                if (patient.Id != "" && patient.Id != null)
                {
                    int i = Convert.ToInt32(patient.Id);
                    string fileName = $"P_{i.ToString().PadLeft(7, '0')}.json";
                    if (File.Exists(fileName))
                    {
                        string jsonString = File.ReadAllText(fileName);
                        patient = JsonSerializer.Deserialize<Pacient>(jsonString)!;
                        if (patient != null)
                        {
                            Priem_Pat.DataContext = patient;
                            patient.Id = $"{i}";
                            reception=patient.AppointmentStories;
                            reception.Add(new Reception() { Date = "09.09.09", Diagnosis = "asd", Doctor_id = 5 });
                        }
                        else
                        {
                            MessageBox.Show("Пусто(");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Такого id нет");
                    }
                    FindPatient.DataContext = patient;

                }
                else
                {
                    MessageBox.Show("Пустое поле!");
                }
            }
            catch (IOException a)
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
            NavigationService.Navigate(new Change_Information(pacients));
        }
    }
}
