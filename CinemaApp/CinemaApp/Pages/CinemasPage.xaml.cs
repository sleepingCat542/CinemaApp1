using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace CinemaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CinemasPage.xaml
    /// </summary>
    public partial class CinemasPage : Page
    {
        SqlConnection cn;
        bool isAdmin = false;
        public Model.Admin admin;
        public Model.User user;
        Movie movie;

        public CinemasPage(User user, Movie movie)
        {
            this.movie = movie;
            this.user = user;
            cn = Connection.GetConnectionUser();
            InitializeComponent();
            FillCinemas();
        }

        public CinemasPage(Admin admin, Movie movie)
        {
            this.movie = movie;
            this.admin = admin;
            isAdmin = true;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            FillCinemas();
        }

        public void FillCinemas()
        {
            cn.Open();
            DataTable cinemas = Connection.GetCinemasInfo(cn);

            grid.ItemsSource = cinemas.DefaultView;
            cn.Close();
        }
    }
}
