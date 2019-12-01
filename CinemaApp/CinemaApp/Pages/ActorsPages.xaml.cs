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
    /// Логика взаимодействия для ActorsPages.xaml
    /// </summary>
    /// 

    public partial class ActorsPages : Page
    {
        SqlConnection cn;
        bool isAdmin = false;
        public Model.Admin admin;
        public Model.User user;
        Movie movie;

        public ActorsPages(Admin admin, Movie movie)
        {
            this.movie = movie;
            this.admin = admin;
            isAdmin = true;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            FillSessions();
        }

        public ActorsPages(User user, Movie movie)
        {
            this.movie = movie;
            this.user = user;
            cn = Connection.GetConnectionUser();
            InitializeComponent();
            FillSessions();
        }

        public void FillSessions()
        {
            cn.Open();
            DataTable actors = Connection.GetActorsInfo(cn);

            grid.ItemsSource = actors.DefaultView;
            cn.Close();
        }       
    }
}
