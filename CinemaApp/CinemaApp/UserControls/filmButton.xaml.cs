using CinemaApp.Model;
using CinemaApp.Pages;
using System;
using System.Collections.Generic;
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

namespace CinemaApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для filmButton.xaml
    /// </summary>
    public partial class filmButton : UserControl
    {
        bool isAdmin = false;
        SqlConnection cn;
        public Model.Movie movie;
        

        public Model.Admin admin;
        public filmButton(Movie movie, Admin admin)
        {
            this.admin = admin;
            isAdmin = true;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            FillPage(movie);         
        }

        public Model.User user;
        public filmButton(Movie movie, User user)
        {
            this.user = user;
            cn = Connection.GetConnectionUser();
            InitializeComponent();
            FillPage(movie);
            
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
            Page p=new Page();
            StackPanel sp = (StackPanel)this.Parent;
            ScrollViewer sw = (ScrollViewer)sp.Parent;
            Grid gr = (Grid)sw.Parent;
            Grid g = (Grid)gr.Parent;
            if(sp.Name== "listOfFilmsByGenres")
                p = (Page)g.Parent;
            else if(sp.Name == "listOfFilms")
                {
                Grid ggr = (Grid)g.Parent;
                p = (Page)ggr.Parent;
            }
            
            if (isAdmin)
            {                
                p.NavigationService.Navigate(new FilmInfo(movie, admin));
            }
            else
            {
                p.NavigationService.Navigate(new FilmInfo(movie, user));
            }
            
        }

        private void Btnfilm_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isAdmin)
            {
                MessageBoxResult resul = MessageBox.Show("Вы уверены, что хотите удалить фильм?", "Удаление", MessageBoxButton.OKCancel);
                if (resul != MessageBoxResult.Cancel)
                {
                    cn.Open();
                    int result = Connection.DeleteMovie(name.Text, cn);
                    if (result == 1)
                    {
                        MessageBox.Show("Удаление прошло успешно!");
                    }
                    else
                        MessageBox.Show("Ошибка удаления!");
                    cn.Close();
                }


            }
        }
    }
}
