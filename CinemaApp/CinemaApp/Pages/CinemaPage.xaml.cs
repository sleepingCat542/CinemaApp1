using CinemaApp.Model;
using CinemaApp.UserControls;
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
    /// Логика взаимодействия для CinemaPage.xaml
    /// </summary>
    public partial class CinemaPage : Page
    {
        public int countOfFilms = 0;
        public List<filmButton> filmButtons = new List<filmButton>();
        List<string> filmNames = new List<string>();
        SqlConnection cn;
        bool isAdmin = false;

        

        public Model.User user;
        public CinemaPage(User user)
        {
            this.user = user;
            cn = Connection.GetConnectionUser();            
            InitializeComponent();
            FillFilms();                       
        }

        public Model.Admin admin;
        public CinemaPage(Admin admin)
        {
            this.admin = admin;
            cn = Connection.GetConnectionAdmin(admin.password);           
            isAdmin = true;
            InitializeComponent();
            FillFilms();                          
        }

        public void FillFilms()
        {
            countOfFilms = 0;
            filmNames.Clear();
            SqlCommand cmd = new SqlCommand("GetMovieInfo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader data = cmd.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    BitmapImage newBitmapImage = new BitmapImage();
                    if (data[5].GetType().ToString() != "System.DBNull")
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(data[5] as byte[]);
                        ms.Seek(0, System.IO.SeekOrigin.Begin);                       
                        newBitmapImage.BeginInit();
                        newBitmapImage.StreamSource = ms;
                        newBitmapImage.EndInit();
                    }
                    DateTime date = (DateTime)data[2];

                    SqlParameter genres= Connection.GetSetGenres(data[1].ToString(), cn);
                    SqlParameter actors = Connection.GetSetActors(data[1].ToString(), cn);

                  Movie movie = new Movie(data[0].ToString(), data[1].ToString(),
                        date.ToString("yy/MM/dd"), Convert.ToInt32(data[3].ToString()), data[4].ToString(), newBitmapImage, data[6] as byte[],
                        data[7].ToString(), genres.Value.ToString(), data[9].ToString(), actors.Value.ToString());
                    if (isAdmin)
                    {
                        filmButtons.Add(new filmButton(movie, admin));
                        filmButtons[countOfFilms] = new filmButton(movie, admin);
                    }
                    else
                    {
                        filmButtons.Add(new filmButton(movie, user));
                        filmButtons[countOfFilms] = new filmButton(movie, user);
                    }
                    listOfFilms.Children.Add(filmButtons[countOfFilms]);
                    countOfFilms++;
                }
                cn.Close();
            }

        }

        private void FullTextSearch_Click(object sender, RoutedEventArgs e)
        {

            if (tbSearch.Text == String.Empty)
            {
                FillFilms();                
            }
            else
            {
                countOfFilms = 0;
                filmNames.Clear();
                listOfFilms.Children.Clear();
                SqlCommand cmd = new SqlCommand("TextSearch", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@search", tbSearch.Text);

                cn.Open();
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        BitmapImage newBitmapImage = new BitmapImage();
                        if (data[5].GetType().ToString() != "System.DBNull")
                        {
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(data[5] as byte[]);
                            ms.Seek(0, System.IO.SeekOrigin.Begin);
                            newBitmapImage.BeginInit();
                            newBitmapImage.StreamSource = ms;
                            newBitmapImage.EndInit();
                        }
                        DateTime date = (DateTime)data[2];

                        SqlParameter genres = Connection.GetSetGenres(data[1].ToString(), cn);
                        SqlParameter actors = Connection.GetSetActors(data[1].ToString(), cn);

                        Movie movie = new Movie(data[0].ToString(), data[1].ToString(),
                            date.ToString("yy/MM/dd"), Convert.ToInt32(data[3].ToString()), data[4].ToString(), newBitmapImage, data[6] as byte[],
                            data[7].ToString(), genres.Value.ToString(), data[9].ToString(), actors.Value.ToString());
                        if (isAdmin)
                        {
                            filmButtons.Add(new filmButton(movie, admin));
                            filmButtons[countOfFilms] = new filmButton(movie, admin);
                        }
                        else
                        {
                            filmButtons.Add(new filmButton(movie, user));
                            filmButtons[countOfFilms] = new filmButton(movie, user);
                        }
                        listOfFilms.Children.Add(filmButtons[countOfFilms]);
                        countOfFilms++;
                    }
                    cn.Close();
                }
                else
                {
                    MessageBox.Show("Ничего не найдено! Проверьте правильность введённых данных.");
                }
            }
        }
    }
}
