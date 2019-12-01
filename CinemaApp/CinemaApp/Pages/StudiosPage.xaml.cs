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

namespace CinemaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudiosPage.xaml
    /// </summary>
    public partial class StudiosPage : Page
    {

        SqlConnection cn;
        bool isAdmin = false;
        public Model.Admin admin;
        public Model.User user;

        public StudiosPage(Admin admin, Movie movie)
        {
            this.movie = movie;
            this.admin = admin;
            isAdmin = true;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            FillStudios();
        }

        public StudiosPage(User user, Movie movie)
        {
            this.movie = movie;
            this.user = user;
            cn = Connection.GetConnectionUser();
            InitializeComponent();
            FillStudios();
        }

         public void FillStudios()
        {
            cn.Open();
            DataTable studios = Connection.GetStudiosInfo(cn);

            grid.ItemsSource = studios.DefaultView;
            cn.Close();
        } 
    }
}
