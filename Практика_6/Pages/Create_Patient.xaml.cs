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
    /// Логика взаимодействия для Create_Patient.xaml
    /// </summary>
    
    public partial class Create_Patient : Page
    {
        private Pacient npatient = new Pacient();
        private Doctor people = new Doctor();
        public int i=0;
        ObservableCollection<Pacient> pacients;
        private System_onl sys = new System_onl();
        public Create_Patient(Doctor people, ObservableCollection<Pacient> Pacients,System_onl s)
        {
            this.people = people;
            InitializeComponent();
            Reg_pacient.DataContext = npatient;
            pacients = Pacients;
            sys = s;
        }

        private void Regiser_pac(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentpacient = npatient;
                if (npatient.Name != null && npatient.Last_Name != null && npatient.Middle_Name != null && npatient.BirthDay != null )
                {
                    int i = 0;
                    while (true)
                    {
                        if (File.Exists($"P_{i.ToString().PadLeft(7, '0')}.json"))
                        {
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    currentpacient.Id = $"{i}";
                    pacients.Add(currentpacient);
                    string jsonString = JsonSerializer.Serialize(currentpacient);
                    string fileName = $"P_{i.ToString().PadLeft(7, '0')}.json";
                    File.WriteAllText(fileName, jsonString);
                    MessageBox.Show($"Ваш ID={i.ToString().PadLeft(7, '0')}");
                    sys.Pac = (Convert.ToInt32(sys.Pac) + 1).ToString();
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show($"Есть пустые поля {npatient.Last_Name} {npatient.Middle_Name} {npatient.BirthDay}");
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
    }
}
