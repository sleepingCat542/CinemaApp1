using CinemaApp.Model;
using Microsoft.Win32;
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
    /// Логика взаимодействия для TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        SqlConnection cn;
        public Model.User user;
        Movie movie;
        private string FileNameExport { get; set; }
        private string FileName { get; set; }

        public TicketPage(User user, Movie movie)
        {
            this.movie = movie;
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
                    //cn.Open();
                    //SqlCommand cmd = new SqlCommand("ImportFromXML", cn);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    //SqlParameter path = new SqlParameter();
                    //path.ParameterName = "@path";
                    //path.SqlDbType = SqlDbType.NVarChar;
                    //path.Size = 256;
                    //path.Value = this.FileName;

                    //cmd.Parameters.Add(path);

                    //SqlParameter rc = new SqlParameter();
                    //rc.ParameterName = "@rc";
                    //rc.SqlDbType = SqlDbType.Bit;
                    //rc.Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add(rc);

                    //cmd.ExecuteNonQuery();
                    //cn.Close();

                    //if ((bool)cmd.Parameters["@rc"].Value)
                    //    MessageBox.Show("Импорт из XML произошёл успешно!");
                    //else
                    //    MessageBox.Show("Ошибка импорта из XML!");
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

        private void OnExportToXML()
        {
            try
            {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("ExportToXML", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@path", this.FileNameExport);
                    cmd.Parameters.AddWithValue("@login", user.login.ToString());

                    SqlParameter rc = new SqlParameter();
                    rc.ParameterName = "@rc";
                    rc.SqlDbType = SqlDbType.Bit;
                    rc.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(rc);

                    cmd.ExecuteNonQuery();
                    cn.Close();

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
                OnExportToXML();
            }
            }
        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            Log_in signin = new Log_in();
            signin.Show();
            this.Close();
        }
        }
    }



