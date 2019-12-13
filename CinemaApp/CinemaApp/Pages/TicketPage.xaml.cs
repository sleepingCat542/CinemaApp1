using CinemaApp.Model;
using CinemaApp.Windows;
using Microsoft.Win32;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace CinemaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        SqlConnection cn;
        public Model.User user;
        Movie movie;
        private string FileNameExport { get; set; }
        private string FileName { get; set; }

        public TicketPage(User user)
        {
            this.user = user;
            cn = Connection.GetConnectionUser();
            InitializeComponent();
            FillTickets();
        }

        public void FillTickets()
        {
            cn.Open();
            DataTable tickets = Connection.GetTicketInfo(user.login.ToString(), cn);
            fieldFilm.Visibility = Visibility.Hidden;
            grid.ItemsSource = tickets.DefaultView;
            cn.Close();
        }

        private void ChoosePathOfXML()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == true)
            {
                this.FileName = dlg.FileName;
            }
        }

        private void AddTicketFromXLMFile(object sender, RoutedEventArgs e)
        {
            try
            {
                ChoosePathOfXML();
                cn = Connection.GetConnection();
                cn.Open();
                SqlCommand cmd = new SqlCommand("ImportFromXML", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter path = new SqlParameter();
                path.ParameterName = "@path";
                path.SqlDbType = SqlDbType.NVarChar;
                path.Size = 256;
                path.Value = this.FileName;

                cmd.Parameters.Add(path);

                SqlParameter rc = new SqlParameter();
                rc.ParameterName = "@rc";
                rc.SqlDbType = SqlDbType.Bit;
                rc.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(rc);

                cmd.ExecuteNonQuery();
                cn.Close();

                if ((bool)cmd.Parameters["@rc"].Value)
                    MessageBox.Show("Импорт из XML произошёл успешно!");
                else
                    MessageBox.Show("Ошибка импорта из XML!");
                cn = Connection.GetConnectionUser();
                FillTickets();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChoosePathToXML()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == true)
            {
                this.FileNameExport = dlg.FileName;
            }
        }

        private void OnExportToXML(int row, int seat, string code)
        {
            try
            {
                    cn = Connection.GetConnection();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("ExportToXML", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@path", this.FileNameExport);
                    cmd.Parameters.AddWithValue("@log", user.login.ToString());
                    cmd.Parameters.AddWithValue("@s", seat);
                    cmd.Parameters.AddWithValue("@r", row);
                    cmd.Parameters.AddWithValue("@u", code);

                SqlParameter rc = new SqlParameter();
                    rc.ParameterName = "@rc";
                    rc.SqlDbType = SqlDbType.Bit;
                    rc.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(rc);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                cn = Connection.GetConnectionUser();

                    if ((bool)cmd.Parameters["@rc"].Value)
                        MessageBox.Show("Экспорт в XML произошёл успешно!");
                    else
                        MessageBox.Show("Ошибка экспорта в XML!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
                DataGridRow row = (DataGridRow)sender;
                DataRowView rw = (DataRowView)row.Item;
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите получить ваш билет в электронном виде?", "Экспорт", MessageBoxButton.OKCancel);
                if (result != MessageBoxResult.Cancel)
                {
                ChoosePathToXML();
                OnExportToXML(Convert.ToInt32(rw.Row.ItemArray[5].ToString()), Convert.ToInt32(rw.Row.ItemArray[6]), rw.Row.ItemArray[8].ToString());
            }
            }

        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            Log_in signin = new Log_in();
            signin.Show();
            Window.GetWindow(this).Close();
        }

        private void DataGridRow_PreviewMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = (DataGridRow)sender;
            DataRowView rw = (DataRowView)row.Item;
            MessageBoxResult resul = MessageBox.Show("Вы уверены, что хотите удалить ваш билет?", "Удаление", MessageBoxButton.OKCancel);
            if (resul != MessageBoxResult.Cancel)
            {
                
                cn.Open();
                int result = Connection.DeleteTicket(rw.Row.ItemArray[8].ToString(), rw.Row.ItemArray[5].ToString(), rw.Row.ItemArray[6].ToString(), cn);
                if (result == 1)
                {
                    MessageBox.Show("Удаление прошло успешно!");                  
                }
                else
                    MessageBox.Show("Ошибка удаления!");
                cn.Close();
                FillTickets();
                
                
            }

        }
    }
    }



