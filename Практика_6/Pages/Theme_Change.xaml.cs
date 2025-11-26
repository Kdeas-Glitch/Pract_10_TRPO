using System;
using System.Collections.Generic;
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

namespace Практика_7.Pages
{
    /// <summary>
    /// Логика взаимодействия для Theme_Change.xaml
    /// </summary>
    public partial class Theme_Change : Page
    {
        public Theme_Change()
        {
            InitializeComponent();
        }
        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            ThemeHelper.Toggle();
        }
        private void Login_Doc(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
