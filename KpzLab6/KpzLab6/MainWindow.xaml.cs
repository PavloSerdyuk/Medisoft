using KpzLab6.Models;
using Microsoft.EntityFrameworkCore;
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

namespace KpzLab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        kpz6Context db;
        public MainWindow()
        {
            InitializeComponent();
            db = new kpz6Context();
            db.Doctor.Load();
            doctorsGrid.ItemsSource = db.Doctor.Local.ToBindingList();
            db.Patient.Load();
            patientsGrid.ItemsSource = db.Patient.Local.ToBindingList();
            db.Appointment.Load();
            appointmGrid.ItemsSource = db.Appointment.Local.ToBindingList();
            db.Declaration.Load();
            declGrid.ItemsSource = db.Declaration.Local.ToBindingList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (declGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < declGrid.SelectedItems.Count; i++)
                {
                    Declaration d = declGrid.SelectedItems[i] as Declaration;
                    if (d != null)
                    {
                        db.Declaration.Remove(d);
                    }
                }
            }
            db.SaveChanges();
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            var obj = new Declaration();
            
                obj.Id = Convert.ToInt32(ID.Text.ToString());
                obj.PatientId = Convert.ToInt32(PatientID.Text.ToString());
                obj.DoctorId = Convert.ToInt32(DoctorID.Text.ToString());
                obj.StartDate = DateTime.Parse(StartDate.Text.ToString());
                db.Declaration.Add(obj);

                db.SaveChanges();


        }
    }
}


 