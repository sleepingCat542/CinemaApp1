using CinemaApp.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace CinemaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для InsertSessionPage.xaml
    /// </summary>
    public partial class InsertSessionPage : Page
    {
        public Model.Admin admin;
        SqlConnection cn;

        public InsertSessionPage(Admin admin)
        {
            this.admin = admin;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            BindComboBoxName(Movie);
            BindComboBoxCinema(Cinema);
        }

        public void BindComboBoxName(ComboBox comboBoxName1)
        {
            DataSet ds = Connection.GetMovies(cn);
            comboBoxName1.ItemsSource = ds.Tables[0].DefaultView;
            comboBoxName1.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
        }

        public void BindComboBoxCinema(ComboBox comboBoxName)
        {
            cn.Open();
            DataSet dataResults = Connection.GetCinemaInfo(cn);
            comboBoxName.ItemsSource = dataResults.Tables[0].DefaultView;
            comboBoxName.DisplayMemberPath = dataResults.Tables[0].Columns["Name"].ToString();
            Connection.CloseConnection(cn);
        }

        private void BindComboBoxHall(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            cn.Open();
            DataSet dataResults = Connection.GetHallInfo(Cinema.Text, cn);
            comboBox.ItemsSource = dataResults.Tables[0].DefaultView;
            comboBox.DisplayMemberPath = dataResults.Tables[0].Columns["NAME"].ToString();
            Connection.CloseConnection(cn);
        }

        private void Add(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (Validator.ValidTextBoxes(this.Cinema.Text, this.Hall.Text, this.Movie.Text, pick.Text, timePicker.Text, Cost.Text ))
                {
                    cn.Open();
                    int result = Connection.AddSqlSession(this.Movie.Text, this.Cinema.Text, this.Hall.Text, pick.SelectedDate, timePicker.SelectedTime, Convert.ToInt32(Cost.Text),cn);
                    cn.Close();

                    if (result == 1)
                    {
                        MessageBox.Show("Добавление произошло успешно!");
                    }
                    else MessageBox.Show("Ошибка добавления!");

                }
                else MessageBox.Show("Введите данные!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
