using CinemaApp.Pages;
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

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isAdmin=false;

        public Model.User user;
        public MainWindow(Model.User user)
        {
            this.user = user;
            InitializeComponent();
            AdminAction.Visibility = Visibility.Hidden;
            MainFrame.Navigate(new CinemaPage(user));
        }

        public Model.Admin admin;
        public MainWindow(Model.Admin admin)
        {
            this.admin = admin;
            InitializeComponent();
            UsersTickets.Visibility = Visibility.Hidden;
            isAdmin = true;
            MainFrame.Navigate(new CinemaPage(admin));           
        }
       

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnWide_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState== WindowState.Normal)
            WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnThink_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Cinema_Click(object sender, RoutedEventArgs e)
        {
            if(isAdmin)
                MainFrame.Navigate(new CinemaPage(admin));
            else
                MainFrame.Navigate(new CinemaPage(user));

        }

        private void Cinemas_Click(object sender, RoutedEventArgs e)
        {
            if(isAdmin)
                MainFrame.Navigate(new CinemasPage(admin));
            else
                MainFrame.Navigate(new CinemasPage(user));

        }

        private void Actors_Click(object sender, RoutedEventArgs e)
        {
            if(isAdmin)
                MainFrame.Navigate(new ActorsPages(admin));
            else
                MainFrame.Navigate(new ActorsPages(user));

        }

        private void Studios_Click(object sender, RoutedEventArgs e)
        {
            if(isAdmin)
                MainFrame.Navigate(new StudiosPage(admin));
            else
                MainFrame.Navigate(new StudiosPage(user));

        }

        private void Genres_Click(object sender, RoutedEventArgs e)
        {
            if(isAdmin)
                MainFrame.Navigate(new GenresPage(admin));
            else
                MainFrame.Navigate(new GenresPage(user));

        }

        private void Tickets_Click(object sender, RoutedEventArgs e)
        {
                MainFrame.Navigate(new TicketPage(user));
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {

            MainFrame.Navigate(new AdminPage(admin));
        }
    }
}
