using CinemaApp.Model;
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

namespace CinemaApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для filmButton.xaml
    /// </summary>
    public partial class filmButton : UserControl
    {
        bool isAdmin = false;
        public Model.Movie movie;

        public Model.Admin admin;
        public filmButton(Movie movie, Admin admin)
        {
            this.admin = admin;
            isAdmin = true;
            InitializeComponent();
            FillPage(movie);         
        }

        public Model.User user;
        public filmButton(Movie movie, User user)
        {
            this.user = user;
            FillPage(movie);
            InitializeComponent();
        }

        public void FillPage(Movie movie)
        {
            name.Text = movie.name;
            date.Text = movie.date;
            country.Text = movie.country;
            genre.Text = movie.genres.ToString();
            img.Source = movie.image;
            studio.Text = movie.studio;
            this.movie = movie;
        }

        private void btnChoseFilm(object sender, RoutedEventArgs e)
        {
            //Button s = (Button)sender;
            //Grid g = (Grid)s.Parent;

            MainWindow main;
            if (isAdmin)
            {
                StackPanel sp = (StackPanel) this.Parent;
                ScrollViewer sw = (ScrollViewer)sp.Parent;
                Grid gr = (Grid)sw.Parent;
                Grid g = (Grid)gr.Parent;
                Grid ggr = (Grid)g.Parent;
                Page p = (Page)ggr.Parent;
                p.NavigationService.Navigate(new FilmInfo(movie, admin));

                //Application.Current.MainWindow.
                //main = new MainWindow(admin);
                //Application.Current.MainWindow.MainFrame.Navigate(new FilmInfo(movie, admin));
                //main.MainFrame.Navigate(new FilmInfo(movie, admin));
            }
            else
            {
                main = new MainWindow(user);
                main.MainFrame.Navigate(new FilmInfo(movie, user));
            }
            
        }
    }
}
