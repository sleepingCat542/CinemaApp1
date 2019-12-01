using CinemaApp.Model;
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
    /// Логика взаимодействия для FilmInfo.xaml
    /// </summary>
    public partial class FilmInfo : Page
    {
        bool isAdmin = false;
        public Model.Admin admin;
        public Model.User user;
        Movie movie;


        public FilmInfo(Movie movie, Admin admin)
        {
            this.movie = movie;
            this.admin = admin;
            isAdmin = true;
            InitializeComponent();
            plot.Width = mainGrid.Width*5/8;
            FillPage();
        }

        public FilmInfo(Movie movie, User user)
        {
            this.movie = movie;
            this.user = user;
            InitializeComponent();
            plot.Width = mainGrid.Width * 5 / 8;
            FillPage();
        }

        public void FillPage()
        {
            name.Text = movie.name;
            plot.Text = movie.plot;
            runtime.Text= movie.runTime.ToString()+" мин";
            studio.Text=movie.studio;
            date.Text = movie.date.ToString();
            country.Text=movie.country;
            actors.Text=movie.actors;
            genres.Text=movie.genres;
            img.Source=movie.image;
            if (movie.video == null)
                btnTrailer.Visibility = Visibility.Hidden;
            if(!isAdmin)
            {
                //радиобатоны
                
            }
        }

        private void BtnBye_Click(object sender, RoutedEventArgs e)
        {
            if(!isAdmin) this.NavigationService.Navigate(new ByePage(user, movie));
            else this.NavigationService.Navigate(new ByePage(admin, movie));
        }
    }
}
