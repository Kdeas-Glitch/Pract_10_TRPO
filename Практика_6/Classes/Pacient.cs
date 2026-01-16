using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Documents;
using Практика_7.Classes;

namespace Практика_7
{
    public class Pacient : INotifyPropertyChanged
    {
        private string? id;
        private string name;
        private string last_name;
        private string middle_name;
        private string birthday;
        private Int128 phoneNumber;
        private ObservableCollection<Reception> appointmentStories = new();
        
        

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        public string Last_Name
        {
            get => last_name;
            set { last_name = value; OnPropertyChanged(); }
        }
        public string Middle_Name
        {
            get => middle_name;
            set { middle_name = value; OnPropertyChanged(); }
        }
        public string BirthDay
        {
            get => birthday;
            set { birthday = value; OnPropertyChanged(); }
        }
        public Int128 PhoneNumber
        {
            get => phoneNumber;
            set { phoneNumber = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Reception> AppointmentStories
        {
            get => appointmentStories;
            set {
                    foreach(var a in value)
                {
                    appointmentStories.Add(a);

                } OnPropertyChanged(); }
        }


        [JsonIgnore]
        public string? Id
        {
            get => id;
            set { id = value; OnPropertyChanged(); }
        }
        [JsonIgnore] public string Date;
        [JsonIgnore] public string Doctor_id;
        [JsonIgnore] public string Diagnosis { get; set; }
        [JsonIgnore] public string Recomendations { get; set; }
        [JsonIgnore]
        public string Adult
        {
            get
            {
                if(Age>=18)
                return "Совершеннолетний";
                else return "Не совершеннолетний";
            }
        }
        [JsonIgnore]
        public double Age
        {
            get
            {
                if(Convert.ToDateTime(birthday).Month< DateTime.Now.Month)
                {
                    return (DateTime.Now.Year - Convert.ToDateTime(birthday).Year);
                }
                else
                {
                    if(Convert.ToDateTime(birthday).Month == DateTime.Now.Month)
                    {
                        if(Convert.ToDateTime(birthday).Day < DateTime.Now.Day)
                        {
                            return (DateTime.Now.Year - Convert.ToDateTime(birthday).Year);
                        }
                        else
                        {
                            if (Convert.ToDateTime(birthday).Day == DateTime.Now.Day)
                            {
                                return (DateTime.Now.Year - Convert.ToDateTime(birthday).Year);
                            }
                            else
                            {
                                return (DateTime.Now.Year - Convert.ToDateTime(birthday).Year)-1;
                            }
                        }
                    }
                    else
                    {
                        return (DateTime.Now.Year - Convert.ToDateTime(birthday).Year) - 1;
                    }
                }
            }
        }
        [JsonIgnore]
        public string DaysFromLastRecep
        {
            get
            {
                if (AppointmentStories.Count > 0)
                {
                    return $"{(DateTime.Now - Convert.ToDateTime(appointmentStories[appointmentStories.Count-1].Date)).Days} дней с последнего посещения";
                }
                else { return $"Первый прием в клинике"; }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
