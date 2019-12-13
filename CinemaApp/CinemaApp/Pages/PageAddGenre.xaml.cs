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
    /// Логика взаимодействия для PageAddGenre.xaml
    /// </summary>
    public partial class PageAddGenre : Page
    {
        public Model.Admin admin;
        SqlConnection cn;

        public PageAddGenre(Admin admin)
        {
            this.admin = admin;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            BindComboBoxName(Name);
            BindComboBoxGenre(Genre);
        }

        public void BindComboBoxGenre(ComboBox comboBoxName1)
        {
            DataSet ds = Connection.GetGenres(cn);
            comboBoxName1.ItemsSource = ds.Tables[0].DefaultView;
            comboBoxName1.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
        }


        public void BindComboBoxName(ComboBox comboBoxName1)
        {
            DataSet ds = Connection.GetMovies(cn);
            comboBoxName1.ItemsSource = ds.Tables[0].DefaultView;
            comboBoxName1.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
        }


        private void AddCinema(object sender, RoutedEventArgs e)
        {
            try
            {
                cn.Open();
                int answer = Connection.AddGenre(Name.Text, Genre.Text,  cn);
                cn.Close();

                if (answer == 1)
                {
                    MessageBox.Show("Добавление произошло успешно!");
                }
                else MessageBox.Show("Ошибка добавления!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
