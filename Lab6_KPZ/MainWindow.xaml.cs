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

namespace Lab6_KPZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BlogContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new BlogContext();
           
        }

        private void AllData_OnClick(object sender, RoutedEventArgs e)
        {
          
            DataGrid.ItemsSource = db.Blogs.ToList();
            

        }
        private void AllDataP_OnClick(object sender, RoutedEventArgs e)
        {

            DataGrid.ItemsSource = db.Posts.ToList();

        }


        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            Blog testBlog = new Blog
            {
                BlogId = 6,
                Name = "TestBlogName!!"
            };
            db.Blogs.Add(testBlog);
            db.SaveChanges();
            DataGrid.ItemsSource = db.Blogs.ToList();
        }
       

        private void Change_OnClick(object sender, RoutedEventArgs e)
        {
            Blog changeBlog = db.Blogs.Find(Convert.ToInt32(TextBoxIdForChange.Text));
            changeBlog.Name = TextBoxChangeName.Text;
            db.Entry(changeBlog).State = EntityState.Modified;
            db.SaveChanges();
            DataGrid.ItemsSource = db.Blogs.ToList();
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            Blog changeBlog = db.Blogs.Find(Convert.ToInt32(TextBoxDeleteId.Text));
            db.Blogs.Remove(changeBlog);
            db.Entry(changeBlog).State = EntityState.Deleted;
            db.SaveChanges();
            DataGrid.ItemsSource = db.Blogs.ToList();
        }
    }
}
