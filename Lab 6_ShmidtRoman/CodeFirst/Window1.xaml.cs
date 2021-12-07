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
using System.Windows.Shapes;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public class Item
        {
            public string Date { get; set; }
            public string DoctorsName { get; set; }
            public string DoctorsSurname { get; set; }
            public string RecordsName { get; set; }
            public string RecordsSurname { get; set; }
            public string RecordsTrouble { get; set; }
            public string RecordsTime { get; set; }
        }

        public class Item2
        {
            public string Date { get; set; }
            public string DoctorsName { get; set; }
            public string DoctorsSurname { get; set; }
            public string ShiftNumber { get; set; }
            public string? Wishes { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            HospitalCodeContext db = new HospitalCodeContext();

            var records = db.Records.ToList();
            var doctors = db.Doctors.ToList();
            var workShedules = db.WorkShedules.ToList();

            ObservableCollection<Item> users = new ObservableCollection<Item>();

            foreach (var workShedule in workShedules)
            {
                users.Add(new Item
                {
                    Date = Convert.ToString(workShedule.Date),
                    DoctorsName = workShedule.Doctor.Name,
                    DoctorsSurname = workShedule.Doctor.Surname,
                    RecordsName = workShedule.RecordCode.Name,
                    RecordsSurname = workShedule.RecordCode.Surname,
                    RecordsTrouble = workShedule.RecordCode.Trouble,
                    RecordsTime = Convert.ToString(workShedule.RecordCode.Time)
                });
            }

            WorkSheduleInfo.ItemsSource = users;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HospitalCodeContext db = new HospitalCodeContext();

            var doctors = db.Doctors.ToList();
            var shiftShedules = db.ShiftShedules.ToList();

            ObservableCollection<Item2> users = new ObservableCollection<Item2>();

            foreach (var shiftShedule in shiftShedules)
            {
                users.Add(new Item2
                {
                    Date = Convert.ToString(shiftShedule.Day),
                    DoctorsName = shiftShedule.DoctorCode.Name,
                    DoctorsSurname = shiftShedule.DoctorCode.Surname,
                    ShiftNumber = Convert.ToString(shiftShedule.ShiftNumber),
                    Wishes = shiftShedule.Wishes
                });
            }

            WorkSheduleInfo2.ItemsSource = users;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            HospitalCodeContext db = new HospitalCodeContext();
            using (var transaction = db.Database.BeginTransaction())
            {
                db.Doctors.FromSqlRaw("SET IDENTITY_INSERT dbo.DestuffedContainer ON");
                db.SaveChanges();
                
                Doctor doctor = new Doctor();

                var doctorDB = db.Doctors.FirstOrDefault();

                //Change the name of the contact.
                doctor.Name = doctorDB.Name;
                doctorDB.Name = "New Contact";
                db.Update(doctorDB);
                doctor.Name = doctorDB.Name;
                doctor.Position = doctorDB.Position;
                doctor.Age = doctorDB.Age;
                doctor.Name = doctorDB.Name;
                doctor.Surname = doctorDB.Surname;

                // Create and add a new Order to the Orders collection.
                db.Doctors.Add(doctor);

                // Removing it from the table also removes it from the Customer’s list.
                //db.Doctors.Remove(doctorDB);

                // Ask the DataContext to save all the changes.
                db.SaveChanges();
                transaction.Commit();
            }
            
        } 
    }
}
