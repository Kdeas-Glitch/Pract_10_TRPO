using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
    /// Логика взаимодействия для Main_Page.xaml
    /// </summary>
    public partial class Main_Page : Page
    {
        private Doctor people = new Doctor();
        private System_onl sys = new System_onl();
        public int idef = 0;
        public ObservableCollection<Pacient> Pacients { get; set; } = new();
        public Pacient? SelectedPac { get; set; }
        public Main_Page(Doctor d)
        {
            int i = 0;
            int a = 0;
            while (i<100)
            {
                if (File.Exists($"P_{i.ToString().PadLeft(7, '0')}.json"))
                {
                    Pacient pacient = new Pacient();
                    string fileName = $"P_{i.ToString().PadLeft(7, '0')}.json";
                    string jsonString = File.ReadAllText(fileName);
                    pacient = JsonSerializer.Deserialize<Pacient>(jsonString)!;
                    pacient.Id = i.ToString();
                    Pacients.Add(pacient);
                    a++;
                }
                i++;
            }
                    sys.Pac = a.ToString();
            InitializeComponent();
            DataContext = this;
            System_.DataContext = sys;
            people = d;
            Sec_Win.DataContext = people;
        }
       

        private void Create_pat(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Create_Patient(people,Pacients,sys));
        }
        private void Start_Rec(object sender, RoutedEventArgs e)
        {
            if (SelectedPac == null)
            {
                MessageBox.Show("Пациент не выбран");
                return;
            }
            NavigationService.Navigate(new Priem(people,Pacients,SelectedPac));
        }
        private void Change_Inf(object sender, RoutedEventArgs e)
        {
            if (SelectedPac == null)
            {
                MessageBox.Show("Пациент не выбран");
                return;
            }
            NavigationService.Navigate(new Change_Information(Pacients,SelectedPac));
        }
        private void Delete_Pac(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32(Pacients[Pacients.Count-1].Id);
            if (SelectedPac == null)
            {
                MessageBox.Show("Пациент не выбран");
                return;
            }
            string fileName = $"P_{SelectedPac.Id.ToString().PadLeft(7, '0')}.json";
            File.Delete(fileName);
            for(int j = Convert.ToInt32(SelectedPac.Id); j < i; j++)
            {
                if (File.Exists($"P_{j.ToString().PadLeft(7, '0')}.json"))
                {
                    Pacient pacient = new Pacient();
                    fileName = $"P_{j.ToString().PadLeft(7, '0')}.json";

                    string jsonString = File.ReadAllText(fileName);
                    pacient = JsonSerializer.Deserialize<Pacient>(jsonString)!;
                    pacient.Id = j.ToString();
                    jsonString = JsonSerializer.Serialize(pacient);
                    fileName = $"P_{(j+1).ToString().PadLeft(7, '0')}.json";
                    File.WriteAllText(fileName, jsonString);
                }
                else
                {
                    sys.Pac = i.ToString();
                    break;
                }
            }
            //while (true)
            //{
            //    if (File.Exists($"P_{i.ToString().PadLeft(7, '0')}.json"))
            //    {
            //        Pacient pacient = new Pacient();
            //        fileName = $"P_{i.ToString().PadLeft(7, '0')}.json";
                    
            //        string jsonString = File.ReadAllText(fileName);
            //        pacient = JsonSerializer.Deserialize<Pacient>(jsonString)!;
            //        pacient.Id = i.ToString();
            //        jsonString = JsonSerializer.Serialize(pacient);
            //        int a = i+1;
            //        fileName = $"P_{a.ToString().PadLeft(7, '0')}.json";
            //        File.WriteAllText(fileName, jsonString);
            //        i++;
            //    }
            //    else
            //    {
            //        sys.Pac = i.ToString();
            //        break;
            //    }
            //}
            Pacients.Remove(SelectedPac);
        }
    }
}
