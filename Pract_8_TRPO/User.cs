using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pract_8_TRPO
{
    public class User :INotifyPropertyChanged
    {
        public int id;
        public string name;
        public string email;
        public int age;


        public int Id
        {
            get => id;
            set { id = value; OnPropertyChanged(); }
        }
        public int Age
        {
            get => age;
            set { age = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }
        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
