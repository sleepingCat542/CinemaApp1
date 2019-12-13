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
    /// Логика взаимодействия для InsertCinema.xaml
    /// </summary>
    public partial class InsertCinema : Page
    {
        SqlConnection cn;
        public Model.Admin admin;

        public InsertCinema(Admin admin)
        {
            this.admin = admin;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
        }

        private void AddCinema(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validator.ValidTextBoxes(this.Name.Text, this.Region.Text, this.Halls.Text))
                {
                        cn.Open();
                    SqlCommand cmd = Connection.AddSqlCinema(this.Name.Text, this.Address.Text, this.Region.Text, this.Website.Text, this.TicketOffice.Text, Convert.ToInt32(this.Halls.Text), cn);
                    SqlParameter result = new SqlParameter("@rc", SqlDbType.Int);
                    result.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(result);
                    cmd.ExecuteNonQuery();
                        cn.Close();

                        if (Convert.ToInt32(result.Value) == 1)
                        {
                            MessageBox.Show("Добавление произошло успешно!"+ cmd.Parameters["@message"].Value);
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
