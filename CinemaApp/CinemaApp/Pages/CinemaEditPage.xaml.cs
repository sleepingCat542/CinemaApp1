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
    /// Логика взаимодействия для CinemaEditPage.xaml
    /// </summary>
    public partial class CinemaEditPage : Page
    {
        SqlConnection cn;
        public Model.Admin admin;

        public CinemaEditPage(Admin admin)
        {
            this.admin = admin;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            BindComboBoxRows(Name);
        }

        public void BindComboBoxRows(ComboBox comboBoxName)
        {
            cn.Open();
            DataSet dataResults = Connection.GetCinemaInfo(cn);
            comboBoxName.ItemsSource = dataResults.Tables[0].DefaultView;
            comboBoxName.DisplayMemberPath = dataResults.Tables[0].Columns["Name"].ToString();
            Connection.CloseConnection(cn);
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {                
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("UpdateCinema", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter check2 = new SqlParameter();
                    check2.ParameterName = "@check2";
                    check2.Value = this.check2.IsChecked == true ? true : false;

                    SqlParameter check3 = new SqlParameter();
                    check3.ParameterName = "@check3";
                    check3.Value = this.check3.IsChecked == true ? true : false;

                    SqlParameter check4 = new SqlParameter();
                    check4.ParameterName = "@check4";
                    check4.Value = this.check4.IsChecked == true ? true : false;

                    SqlParameter check5 = new SqlParameter();
                    check5.ParameterName = "@check5";
                    check5.Value = this.check5.IsChecked == true ? true : false;

                    SqlParameter check6 = new SqlParameter();
                    check6.ParameterName = "@check6";
                    check6.Value = this.check6.IsChecked == true ? true : false;

                    SqlParameter name = new SqlParameter();
                    name.ParameterName = "@name";
                    name.Value = this.Name.Text;

                    SqlParameter address = new SqlParameter();
                    address.ParameterName = "@address";
                    address.Value = this.Address.Text;

                    SqlParameter city = new SqlParameter();
                    city.ParameterName = "@city";
                    city.Value = this.Region.Text;

                    SqlParameter website = new SqlParameter();
                    website.ParameterName = "@website";
                    website.Value = this.Website.Text;

                    SqlParameter timetable = new SqlParameter();
                timetable.ParameterName = "@timetable";
                timetable.Value = this.TicketOffice.Text;

                    SqlParameter halls = new SqlParameter();
                    halls.ParameterName = "@halls";
                    halls.Value = this.Halls.Text;

                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(address);
                    cmd.Parameters.Add(city);
                    cmd.Parameters.Add(website);
                    cmd.Parameters.Add(timetable);
                    cmd.Parameters.Add(halls);
                    cmd.Parameters.Add(check2);
                    cmd.Parameters.Add(check3);
                    cmd.Parameters.Add(check4);
                    cmd.Parameters.Add(check5);
                    cmd.Parameters.Add(check6);

                    SqlParameter rc = new SqlParameter();
                    rc.ParameterName = "@rc";
                    rc.SqlDbType = System.Data.SqlDbType.Bit;
                    rc.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(rc);

                    cmd.ExecuteNonQuery();

                    cn.Close();

                    if ((bool)cmd.Parameters["@rc"].Value)
                    {
                        MessageBox.Show("Обновление произошло успешно!");
                    }
                    else MessageBox.Show("Ошибка обновления!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
