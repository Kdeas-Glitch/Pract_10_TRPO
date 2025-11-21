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

namespace Pract_8_TRPO.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ObservableCollection<User> Users { get; set; } = new();
        public User? SelectedUser { get; set; }
        public ListPage()
        {
            Users.Add(new User() { Id = 1, Name = "Иван", Email = "ivan@mail.ru", Age = 18 });
            Users.Add(new User() { Id = 2, Name = "Петр", Email = "petr@mail.ru", Age = 18 });
            Users.Add(new User() { Id = 3, Name = "Дмитрий", Email = "dmitrii@mail.ru", Age = 18 });
            Users.Add(new User() { Id = 4, Name = "Федор", Email = "fedor@mail.ru", Age = 18 });
            Users.Add(new User() { Id = 5, Name = "Максим", Email = "maksim@mail.ru", Age = 18 });
            Users.Add(new User() { Id = 6, Name = "Александр", Email = "alexander@mail.ru", Age = 18 });
            InitializeComponent();
            DataContext = this;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserFormPage(Users));
        }
        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Пользователь не выбран");
                return;
            }
            bool confirm = MessageBox.Show(
                "Вы действительно хотите удалить запись?",
                "Подтверждение удаления",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes;
            if (confirm)
            {
                Users.Remove(SelectedUser);
            }
        }
        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Не выбран элемент списка");
                return;
            }
            NavigationService.Navigate(new UserFormPage(Users, SelectedUser));
        }
    }
}
