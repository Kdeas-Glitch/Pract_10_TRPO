

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Практика_7;
using Практика_7.Pages;

namespace Практика_6
{
    
    public partial class MainWindow : Window
    {
        private Doctor CurrentUser = new Doctor();//Регистрация пользователя
        private Doctor people = new Doctor();//Вход Пользователя
        private Pacient npatient = new Pacient();
        private Pacient patient = new Pacient();
        private Passwords pass = new Passwords();
        private System_onl sys = new System_onl();
        private ObservableCollection<Pacient> pacients = new ObservableCollection<Pacient>();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Login());
            ThemeHelper.ApplySaved();
            //regForm.DataContext = CurrentUser;

            //Sec_Win.DataContext = people;

            //Cor_p.DataContext = pass;

            //Reg_pacient.DataContext = npatient;

            //Change_pacient.DataContext = patient;

            //FindPatient.DataContext = patient;

            //Priem_Pat.DataContext = patient;


            //System_.DataContext = sys;

            //Count();
        }
        private void Change_Theme(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Theme_Change());
        }
        //private void Count()
        //{
        //    int i = 0;
        //    while (true)
        //    {
        //        if (File.Exists($"D_{i.ToString().PadLeft(5, '0')}.json"))
        //        {
        //            i++;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    sys.Doc = i.ToString();
        //    i = 0;
        //    while (true)
        //    {
        //        if (File.Exists($"D_{i.ToString().PadLeft(7, '0')}.json"))
        //        {
        //            i++;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    sys.Pac = i.ToString();
        //    System_.DataContext = sys;
        //}


        //private void MessageUser(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        var currentUser = CurrentUser;
        //        if (currentUser.Name != null && currentUser.Last_Name != null && currentUser.Middle_Name != null && currentUser.Password != null)
        //        {
        //            if (currentUser.Password == CurrentUser.Cor_Password)
        //            {
        //                int i = 0;
        //                while (true)
        //                {
        //                    if (File.Exists($"D_{i.ToString().PadLeft(5, '0')}.json"))
        //                    {
        //                        i++;
        //                    }
        //                    else
        //                    {
        //                        break;
        //                    }
        //                }
        //                currentUser.Id = $"{i}";
        //                string jsonString = JsonSerializer.Serialize(currentUser);

        //                string fileName = $"D_{i.ToString().PadLeft(5, '0')}.json";
        //                File.WriteAllText(fileName, jsonString);
        //                MessageBox.Show($"Ваш ID={i.ToString().PadLeft(5, '0')}");
        //                currentUser.Name = "";
        //                currentUser.Last_Name = "";
        //                currentUser.Middle_Name = "";
        //                currentUser.Password = "";
        //                currentUser.Specialisation = "";
        //            }
        //            else
        //            {
        //                MessageBox.Show("Пароли не совпадают");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Есть пустые поля");
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Ошибка");
        //    }
        //}
        //private void Login(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        int i = Convert.ToInt32(_ID.Text.ToString());
        //        string fileName = $"D_{i.ToString().PadLeft(5, '0')}.json";
        //        if (File.Exists(fileName))
        //        {
        //            string jsonString = File.ReadAllText(fileName);
        //            people = JsonSerializer.Deserialize<Doctor>(jsonString)!;
        //            if (people != null)
        //            {

        //                if (people.Password == pass.Cor_Password)
        //                {
        //                    Sec_Win.DataContext = people;
        //                    people.Id = $"{i}";
        //                    people.Name = $"{people.Name} {people.Middle_Name} {people.Last_Name}";
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Неверный пароль");

        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Пусто(");
        //            }

        //        }
        //        else
        //        {
        //            MessageBox.Show("Такого id нет");
        //        }
        //    }
        //    catch (IOException a)
        //    {
        //        MessageBox.Show("Ошибка");
        //    }
        //}

        //private void DeleteUser(object sender, RoutedEventArgs e)
        //{
        //    var currentUser = CurrentUser;
        //    currentUser.Name = "";
        //    currentUser.Last_Name = "";
        //    currentUser.Middle_Name = "";
        //    currentUser.Password = "";
        //    currentUser.Specialisation = "";
        //}

        //private void Find(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (patient.Id != "" && patient.Id != null)
        //        {
        //            if (people.Name != null)
        //            {
        //                int i = Convert.ToInt32(patient.Id);
        //                string fileName = $"D_{i.ToString().PadLeft(7, '0')}.json";
        //                if (File.Exists(fileName))
        //                {
        //                    string jsonString = File.ReadAllText(fileName);
        //                    patient = JsonSerializer.Deserialize<Pacient>(jsonString)!;
        //                    if (patient != null)
        //                    {
        //                        Change_pacient.DataContext = patient;
        //                        Priem_Pat.DataContext = patient;
        //                        patient.Id = $"{i}";
        //                        fileName = $"D_{patient.Last_Doctor.ToString().PadLeft(5, '0')}.json";
        //                        jsonString = File.ReadAllText(fileName);
        //                        Doctor BDoc = JsonSerializer.Deserialize<Doctor>(jsonString)!;
        //                        patient.Last_Doctor = $"{BDoc.Name} {BDoc.Last_Name} {BDoc.Middle_Name}";

        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Пусто(");
        //                    }

        //                }
        //                else
        //                {
        //                    MessageBox.Show("Такого id нет");
        //                }
        //                FindPatient.DataContext = patient;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Сначала войдите как доктор");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Пустое поле!");
        //        }
        //    }
        //    catch (IOException a)
        //    {
        //        MessageBox.Show("Ошибка");
        //    }
        //}
        //private void Regiser_pac(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (people.Name != null)
        //        {
        //            var currentpacient = npatient;
        //            if (npatient.Name != null && npatient.Last_Name != null && npatient.Middle_Name != null && npatient.BirthDay != null && npatient.Recomendations != null && npatient.Diagnosis != null)
        //            {
        //                int i = 0;
        //                while (true)
        //                {
        //                    if (File.Exists($"D_{i.ToString().PadLeft(7, '0')}.json"))
        //                    {
        //                        i++;
        //                    }
        //                    else
        //                    {
        //                        break;
        //                    }
        //                }
        //                currentpacient.Id = $"{i}";
        //                currentpacient.Last_Doctor = people.Id;
        //                currentpacient.Last_Appointment = DateTime.Now.ToString();
        //                string jsonString = JsonSerializer.Serialize(currentpacient);
        //                string fileName = $"D_{i.ToString().PadLeft(7, '0')}.json";
        //                File.WriteAllText(fileName, jsonString);
        //                MessageBox.Show($"Ваш ID={i.ToString().PadLeft(7, '0')}");
        //                currentpacient.Name = "";
        //                currentpacient.Last_Name = "";
        //                currentpacient.Middle_Name = "";
        //                currentpacient.BirthDay = "";
        //                currentpacient.Recomendations = "";
        //                currentpacient.Diagnosis = "";
        //            }
        //            else
        //            {
        //                MessageBox.Show($"Есть пустые поля {npatient.Last_Name} {npatient.Middle_Name} {npatient.BirthDay} {npatient.Diagnosis} {npatient.Recomendations}");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Сначала войдите как доктор");
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Ошибка");
        //    }
        //}
        //private void Back_Changes(object sender, RoutedEventArgs e)
        //{
        //    if (patient.Name != null)
        //    {
        //        int i = Convert.ToInt32(patient.Id);
        //        string fileName = $"D_{i.ToString().PadLeft(7, '0')}.json";
        //        string jsonString = File.ReadAllText(fileName);
        //        var Bpatient = JsonSerializer.Deserialize<Pacient>(jsonString)!;
        //        patient.Name = Bpatient.Name;
        //        patient.Last_Name = Bpatient.Last_Name;
        //        patient.Middle_Name = Bpatient.Middle_Name;
        //        patient.BirthDay = Bpatient.BirthDay;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Нет активного пациента");
        //    }
        //}



        //private void Save_Priem(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (people.Name != null)
        //        {
        //            var currentpacient = patient;
        //            if (patient.Name != null && patient.Last_Name != null && patient.Middle_Name != null && patient.BirthDay != null && patient.Recomendations != null && patient.Diagnosis != null)
        //            {
        //                int i = Convert.ToInt32(patient.Id);
        //                currentpacient.Last_Doctor = people.Id;
        //                currentpacient.Last_Appointment = DateTime.Now.ToString();
        //                string jsonString = JsonSerializer.Serialize(currentpacient);
        //                string fileName = $"D_{i.ToString().PadLeft(7, '0')}.json";
        //                File.WriteAllText(fileName, jsonString);
        //                MessageBox.Show($"Ваш ID={i.ToString().PadLeft(7, '0')}");
        //                currentpacient.Name = "";
        //                currentpacient.Last_Name = "";
        //                currentpacient.Middle_Name = "";
        //                currentpacient.BirthDay = "";
        //                currentpacient.Last_Appointment = "";
        //                currentpacient.Last_Doctor = "";
        //                currentpacient.Recomendations = "";
        //                currentpacient.Diagnosis = "";
        //                patient.Id = "";
        //            }
        //            else
        //            {
        //                MessageBox.Show($"Есть пустые поля {npatient.Last_Name} {npatient.Middle_Name} {npatient.BirthDay} {npatient.Diagnosis} {npatient.Recomendations}");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Сначала войдите как доктор");
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Ошибка");
        //    }
        //}

    }
}
