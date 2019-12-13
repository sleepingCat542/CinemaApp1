using CinemaApp.Model;
using CinemaApp.UserControls;
using CinemaApp.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для ByePage.xaml
    /// </summary>
    public partial class ByePage : Page
    {
        SqlConnection cn;
        SqlDataAdapter adapter1;
        DataTable dataResults;
        bool isAdmin = false;
        public Model.Admin admin;
        public Model.User user;
        Movie movie;

        public ByePage(Admin admin, Movie movie, string parameter=null, string parameterValue = null)
        {
            this.movie = movie;
            this.admin = admin;
            isAdmin = true;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            if (parameter == "cinema")
                FillSessionsByCinema(parameterValue);
            else
                FillSessions();
        }

        public ByePage(User user, Movie movie, string parameter=null, string parameterValue = null)
        {           
            this.movie = movie;
            this.user = user;
            cn = Connection.GetConnectionUser();
            InitializeComponent();
            if (parameter == "Cinema")
                FillSessionsByCinema(parameterValue);
            else
                FillSessions();
        }

        public void FillSessions()
        {
            cn.Open();
            DataTable sessions = Connection.GetSessionInfo(movie, cn);                          
            grid.ItemsSource = sessions.DefaultView;
            cn.Close();
        }

        public void FillSessionsByCinema(string cinema)
        {
            cn.Open();
            DataTable sessions = Connection.GetSessionInfoByCinema(cinema, cn);

            fieldFilm.Visibility = Visibility.Hidden;

            grid.ItemsSource = sessions.DefaultView;
            cn.Close();
        }

        public void Bying(AddSeat window, DataRowView rw)
        {
            if (window.submit == true)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("InsertPurchase", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter login = new SqlParameter();
                login.ParameterName = "@login";
                login.Value = user.login.ToString();

                SqlParameter date = new SqlParameter();
                date.ParameterName = "@date";
                date.Value = DateTime.Now;

                cmd.Parameters.Add(login);
                cmd.Parameters.Add(date);

                SqlParameter rc = new SqlParameter("@rc", SqlDbType.VarChar, 20);
                rc.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(rc);
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("InsertTicket", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                #region AddSeat
                if (window.sendingRow1 != 0 && window.sendingSeat1 != 0)
                {
                    SqlParameter seat1 = new SqlParameter();
                    seat1.ParameterName = "@seat1";
                    seat1.Value = window.sendingSeat1;

                    SqlParameter row1 = new SqlParameter();
                    row1.ParameterName = "@row1";
                    row1.Value = window.sendingRow1;

                    cmd.Parameters.Add(seat1);
                    cmd.Parameters.Add(row1);
                }
                if (window.sendingRow2 != 0 && window.sendingSeat2 != 0)
                {
                    SqlParameter seat2 = new SqlParameter();
                    seat2.ParameterName = "@seat2";
                    seat2.Value = window.sendingSeat2;

                    SqlParameter row2 = new SqlParameter();
                    row2.ParameterName = "@row2";
                    row2.Value = window.sendingRow2;

                    cmd.Parameters.Add(seat2);
                    cmd.Parameters.Add(row2);
                }
                if (window.sendingRow3 != 0 && window.sendingSeat3 != 0)
                {
                    SqlParameter seat3 = new SqlParameter();
                    seat3.ParameterName = "@seat3";
                    seat3.Value = window.sendingSeat3;

                    SqlParameter row3 = new SqlParameter();
                    row3.ParameterName = "@row3";
                    row3.Value = window.sendingRow3;

                    cmd.Parameters.Add(seat3);
                    cmd.Parameters.Add(row3);
                }
                if (window.sendingRow4 != 0 && window.sendingSeat4 != 0)
                {
                    SqlParameter seat4 = new SqlParameter();
                    seat4.ParameterName = "@seat4";
                    seat4.Value = window.sendingSeat4;

                    SqlParameter row4 = new SqlParameter();
                    row4.ParameterName = "@row4";
                    row4.Value = window.sendingRow4;

                    cmd.Parameters.Add(seat4);
                    cmd.Parameters.Add(row4);
                }
                if (window.sendingRow5 != 0 && window.sendingSeat5 != 0)
                {
                    SqlParameter seat5 = new SqlParameter();
                    seat5.ParameterName = "@seat5";
                    seat5.Value = window.sendingSeat5;

                    SqlParameter row5 = new SqlParameter();
                    row5.ParameterName = "@row5";
                    row5.Value = window.sendingRow5;

                    cmd.Parameters.Add(seat5);
                    cmd.Parameters.Add(row5);
                }
                #endregion

                SqlParameter movieSession = new SqlParameter();
                movieSession.ParameterName = "@movie";
                movieSession.Value = rw.Row.ItemArray[1].ToString();

                SqlParameter cinema = new SqlParameter();
                cinema.ParameterName = "@cinema";
                cinema.Value = rw.Row.ItemArray[7].ToString();

                SqlParameter hall = new SqlParameter();
                hall.ParameterName = "@hall";
                hall.Value = rw.Row.ItemArray[2].ToString();

                SqlParameter dateSession = new SqlParameter();
                dateSession.ParameterName = "@date";
                dateSession.Value = rw.Row.ItemArray[3];

                SqlParameter time = new SqlParameter();
                time.ParameterName = "@time";
                time.Value = rw.Row.ItemArray[4];

                SqlParameter code = new SqlParameter();
                code.ParameterName = "@pass";
                code.Value = rc.Value.ToString();

                cmd.Parameters.Add(movieSession);
                cmd.Parameters.Add(cinema);
                cmd.Parameters.Add(hall);
                cmd.Parameters.Add(time);
                cmd.Parameters.Add(dateSession);
                cmd.Parameters.Add(code);

                SqlParameter message = new SqlParameter("@mess", SqlDbType.NVarChar, 50);
                message.Direction = ParameterDirection.Output;
                SqlParameter success = new SqlParameter("@rc", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(success);
                cmd.Parameters.Add(message);
                cmd.ExecuteNonQuery();
                cn.Close();
                if (Convert.ToInt32(cmd.Parameters["@rc"].Value)==1) MessageBox.Show("Спасибо за покупку!");
                else MessageBox.Show("Произошла ошибка при покупке!"+message.Value.ToString());
            }
            seatsGrid.Children.Remove(window);
            seatsGrid.Visibility = Visibility.Hidden;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!isAdmin)
            {
                DataGridRow row = (DataGridRow)sender;
                DataRowView rw = (DataRowView)row.Item;
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите приобрести билеты на этот сеанс?", "Покупка билета", MessageBoxButton.OKCancel);
                if (result != MessageBoxResult.Cancel)
                {
                    AddSeat window = new AddSeat(rw, rw.Row.ItemArray[2].ToString(), Convert.ToInt32(rw.Row.ItemArray[0].ToString()));
                    seatsGrid.Visibility = Visibility.Visible;
                    seatsGrid.Children.Add(window);
                }                   

                }
            
            else
            {
                MessageBox.Show("Покупка билетов администратором невозможна!");
            }
            }

        private void DataGridRow_PreviewMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isAdmin)
            {
                DataGridRow row = (DataGridRow)sender;
                DataRowView rw = (DataRowView)row.Item;
                MessageBoxResult resul = MessageBox.Show("Вы уверены, что хотите удалить сеанс?", "Удаление", MessageBoxButton.OKCancel);
                if (resul != MessageBoxResult.Cancel)
                {
                    cn.Open();
                    int result = Connection.DeleteSession(Convert.ToInt32(rw.Row.ItemArray[0].ToString()), cn);
                    if (result == 1)
                    {
                        MessageBox.Show("Удаление прошло успешно!");
                        
                    }
                    else
                        MessageBox.Show("Ошибка удаления!");
                    cn.Close();
                    FillSessions();
                }


            }
        }
    }

}
