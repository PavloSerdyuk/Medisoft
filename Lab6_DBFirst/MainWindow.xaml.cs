using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Lab6_DBFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestDBShymanskaEntities db = new TestDBShymanskaEntities();
       // public BlogContext db;
            public MainWindow()
            {
                InitializeComponent();
                db = new TestDBShymanskaEntities();

            }

            private void AllData_OnClick(object sender, RoutedEventArgs e)
            {

                DataGrid.ItemsSource = db.Customers.ToList();


            }
         
            private void Add_OnClick(object sender, RoutedEventArgs e)
            {
            Customers test = new Customers
            {
                cnum = 2012,
                cname = "TestName!",
                city = "Lviv",
                rating = 200,
                snum = 1001
                };
                db.Customers.Add(test);
                db.SaveChanges();
                DataGrid.ItemsSource = db.Customers.ToList();
            }


            private void Change_OnClick(object sender, RoutedEventArgs e)
            {
                Customers changeCus = db.Customers.Find(Convert.ToInt32(TextBoxIdForChange.Text));
                changeCus.cname = TextBoxChangeName.Text;
                db.Entry(changeCus).State = EntityState.Modified;
                db.SaveChanges();
                DataGrid.ItemsSource = db.Customers.ToList();
            }

            private void Delete_OnClick(object sender, RoutedEventArgs e)
            {
                Customers changeCus = db.Customers.Find(Convert.ToInt32(TextBoxDeleteId.Text));
                db.Customers.Remove(changeCus);
                db.Entry(changeCus).State = EntityState.Deleted;
                db.SaveChanges();
                DataGrid.ItemsSource = db.Customers.ToList();
            }
     }
    
}
