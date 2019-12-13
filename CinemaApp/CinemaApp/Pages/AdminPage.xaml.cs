using CinemaApp.Model;
using CinemaApp.Windows;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace CinemaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        Admin admin;
        SqlConnection cn;

        public AdminPage(Admin admin)
        {
            cn = Connection.GetConnectionAdmin(admin.password);
            this.admin = admin;
            InitializeComponent();
        }

        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            Log_in signin = new Log_in();
            signin.Show();
            Window.GetWindow(this).Close();
        }

        private void AddFilm(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InsertMovie(admin));
        }

        private void EditFilm(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MovieEditPage(admin));
        }

        private void AddGenre(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddGenre(admin));
        }

        private void AddActor(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddActor(admin));
        }

        private void AddSession(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InsertSessionPage(admin));
        }
    }
}
