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
    /// Логика взаимодействия для GenresPage.xaml
    /// </summary>
    public partial class GenresPage : Page
    {
        SqlConnection cn;
        public int countOfFilms = 0;
        bool isAdmin = false;
        public Model.User user;
        public Model.Admin admin;
        public List<filmButton> filmButtons = new List<filmButton>();

        public GenresPage(Admin admin)
        {
            this.admin = admin;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            BindComboBoxRows(comboGenre1);

            BindComboBoxRows(comboGenre2);
            BindComboBoxRows(comboGenre3);
        }

        public GenresPage(User user)
        {
            this.user = user;
            cn = Connection.GetConnectionUser();
            InitializeComponent();
            BindComboBoxRows(comboGenre1);

            BindComboBoxRows(comboGenre2);
            BindComboBoxRows(comboGenre3);
        }

        public void BindComboBoxRows(ComboBox comboBoxName)
        {
            cn.Open();
            DataSet dataResults = Connection.GetGenres(cn);
            comboBoxName.ItemsSource = dataResults.Tables[0].DefaultView;
            comboBoxName.DisplayMemberPath = dataResults.Tables[0].Columns["NAME"].ToString();
            Connection.CloseConnection(cn);
        }

        public void FillFilms()
        {
            countOfFilms = 0;
            SqlCommand cmd = new SqlCommand("GetMovieInfo", cn);
            cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter genre1 = new SqlParameter();
                genre1.ParameterName = "@genre1";
                genre1.Value = comboGenre1.Text;
                cmd.Parameters.Add(genre1);

                SqlParameter genre2 = new SqlParameter();
                genre2.ParameterName = "@genre2";
                if(comboGenre2.Text == String.Empty)
                {
                    genre2.Value = comboGenre1.Text;
                }
                else
                genre2.Value = comboGenre2.Text;
                cmd.Parameters.Add(genre2);

                SqlParameter genre3 = new SqlParameter();
                genre3.ParameterName = "@genre3";
                if (comboGenre3.Text == String.Empty)
                {
                    genre3.Value = comboGenre1.Text;
                }
                else
                genre3.Value = comboGenre3.Text;
                cmd.Parameters.Add(genre3);
            



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
                    listOfFilmsByGenres.Children.Add(filmButtons[countOfFilms]);
                    countOfFilms++;
                }
                
            }
            cn.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listOfFilmsByGenres.Children.Clear();
            FillFilms();
        }
    }
}
