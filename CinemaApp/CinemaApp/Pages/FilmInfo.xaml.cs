using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
            {
                btnTrailer.Opacity = 0.5;
                btnTrailer.IsEnabled = false;
            }
        }

        private void BtnBye_Click(object sender, RoutedEventArgs e)
        {
            if(!isAdmin) this.NavigationService.Navigate(new ByePage(user, movie));
            else this.NavigationService.Navigate(new ByePage(admin, movie));
        }

        private void btnTrailer_Click(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = new StackPanel();

            Border videoBorder = new Border();
            videoBorder.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/icon2.png")));

            MediaElement media = new MediaElement();
            media.Width = 600;
            media.Height = 400;
            System.IO.File.WriteAllBytes("temp.mp4", movie.video);
            media.Source = new Uri("temp.mp4", UriKind.Relative);
            media.LoadedBehavior = MediaState.Manual;
            media.UnloadedBehavior = MediaState.Stop;

            DockPanel dockPanel = new DockPanel();

            Button btn1 = new Button();
            btn1.Width = 150;
            btn1.HorizontalAlignment = HorizontalAlignment.Left;
            btn1.Margin = new Thickness(5, 2, 5, 2);
            btn1.FontFamily=new FontFamily("Segoe Print Bold");
            btn1.BorderThickness = new Thickness(0);
            btn1.Click += PlayClick;
            btn1.Content = "Воспроизвести";

            Button btn2 = new Button();
            btn2.HorizontalAlignment = HorizontalAlignment.Right;
            btn2.Width = 150;
            btn2.Margin = new Thickness(5, 2, 5, 2);
            btn2.FontFamily = new FontFamily("Segoe Print Bold");
            btn2.BorderThickness = new Thickness(0);
            btn2.Click += StopClick;
            btn2.Content = "Стоп";

         
            videoBorder.Child = media;
            dockPanel.Children.Add(btn1);
            dockPanel.Children.Add(btn2);
            stackPanel.Children.Add(videoBorder);
            stackPanel.Children.Add(dockPanel);
            mainGrid.Children.Add(stackPanel);
        }

        void PlayClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DockPanel dp = (DockPanel)btn.Parent;
            StackPanel sp = (StackPanel)dp.Parent;
            Border border = (Border)sp.Children[0];
            MediaElement me = (MediaElement)border.Child;
            me.Play();
        }

        void StopClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DockPanel dp = (DockPanel)btn.Parent;
            StackPanel sp = (StackPanel)dp.Parent;
            Border border = (Border)sp.Children[0];
            MediaElement me = (MediaElement)border.Child;
            me.Stop();
        }
    }
}
