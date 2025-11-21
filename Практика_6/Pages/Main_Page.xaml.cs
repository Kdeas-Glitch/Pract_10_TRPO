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
        private ObservableCollection<Pacient> pacients= new ObservableCollection<Pacient>();
        public Main_Page(Doctor d)
        {
            InitializeComponent();
            int i = 0;
            while (true)
            {
                if (File.Exists($"P_{i.ToString().PadLeft(7, '0')}.json"))
                {
                    Pacient pacient = new Pacient();
                    string fileName = $"P_{i.ToString().PadLeft(7, '0')}.json";
                    string jsonString = File.ReadAllText(fileName);
                    pacient = JsonSerializer.Deserialize<Pacient>(jsonString)!;
                    pacient.Id = i.ToString();
                    pacients.Add(pacient);
                    i++;
                }
                else
                {
                    sys.Pac = i.ToString();
                    break;
                }
            }

            System_.DataContext = sys;
            List_Rec.ItemsSource = pacients;
            people = d;
            Sec_Win.DataContext = people;
        }
       

        private void Create_pat(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Create_Patient(people,pacients,sys));
        }
        private void Start_Rec(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Priem(people,pacients));
        }
        private void Change_Inf(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Change_Information(pacients));
        }
    }
}
