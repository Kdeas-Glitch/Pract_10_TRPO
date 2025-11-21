using System;
using System.Collections.Generic;
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
using System.IO;

using Практика_6;
using System.Collections.ObjectModel;

namespace Практика_7.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        private Doctor CurrentUser = new Doctor();//Регистрация пользователя
        ObservableCollection<Pacient> pacients;
        public Registration()
        {
            InitializeComponent();
            regForm.DataContext = CurrentUser;
        }
        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            //this.Background = Brushes.Beige;
            ThemeHelper.Toggle();
            
        }


        private void Regist(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentUser = CurrentUser;
                if (currentUser.Name != null && currentUser.Last_Name != null && currentUser.Middle_Name != null && currentUser.Password != null)
                {
                    if (currentUser.Password == CurrentUser.Cor_Password)
                    {
                        int i = 0;
                        while (true)
                        {
                            if (File.Exists($"D_{i.ToString().PadLeft(5, '0')}.json"))
                            {
                                i++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        currentUser.Id = $"{i}";
                        string jsonString = JsonSerializer.Serialize(currentUser);
                        string fileName = $"D_{i.ToString().PadLeft(5, '0')}.json";
                        File.WriteAllText(fileName, jsonString);
                        MessageBox.Show($"Ваш ID={i.ToString().PadLeft(5, '0')}");
                        
                        NavigationService.Navigate(new Main_Page(currentUser));
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают");
                    }
                }
                else
                {
                    MessageBox.Show("Есть пустые поля");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Log_in(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
