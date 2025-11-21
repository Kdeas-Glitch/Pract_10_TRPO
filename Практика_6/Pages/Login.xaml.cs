using System;
using System.Collections.Generic;
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

namespace Практика_7.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private Doctor people = new Doctor();
        private Passwords pass = new Passwords();
        public Login()
        {
            InitializeComponent();
            Sec_Win.DataContext = people;
            Cor_p.DataContext = pass;

        }
        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            //this.Background = Brushes.Beige;
            ThemeHelper.Toggle();

        }

        private void Login_Doc(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(_ID.Text.ToString());
                string fileName = $"D_{i.ToString().PadLeft(5, '0')}.json";
                if (File.Exists(fileName))
                {
                    string jsonString = File.ReadAllText(fileName);
                    people = JsonSerializer.Deserialize<Doctor>(jsonString)!;
                    if (people != null)
                    {

                        if (people.Password == pass.Cor_Password)
                        {
                            Sec_Win.DataContext = people;
                            people.Id = $"{i}";
                            people.Name = $"{people.Name} {people.Middle_Name} {people.Last_Name}";
                            NavigationService.Navigate(new Main_Page(people));
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль");

                        }
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
            }
            catch
            {
                MessageBox.Show("Пусто");
            }
        }
        private void Regist(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
    }
}
