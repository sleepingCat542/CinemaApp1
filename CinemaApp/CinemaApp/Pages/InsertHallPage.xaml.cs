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
    /// Логика взаимодействия для InsertHallPage.xaml
    /// </summary>
    public partial class InsertHallPage : Page
    {
        public Model.Admin admin;
        SqlConnection cn;

        public InsertHallPage(Admin admin)
        {
            this.admin = admin;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            BindComboBoxRows(CinemaName);
        }

        public void BindComboBoxRows(ComboBox comboBoxName)
        {
            cn.Open();
            DataSet dataResults = Connection.GetCinemaInfo(cn);
            comboBoxName.ItemsSource = dataResults.Tables[0].DefaultView;
            comboBoxName.DisplayMemberPath = dataResults.Tables[0].Columns["Name"].ToString();
            Connection.CloseConnection(cn);
        }

        private void AddHall(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validator.ValidTextBoxes(this.Name.Text, this.CinemaName.Text,  this.Rows.Text, this.Seats.Text))
                {
                        cn.Open();
                    SqlCommand cmd = Connection.AddSqlHall(this.Name.Text, this.CinemaName.Text, Convert.ToInt32(this.Rows.Text), Convert.ToInt32(this.Seats.Text), cn);
                        int result=cmd.ExecuteNonQuery();

                        cn.Close();

                        if (result==1)
                        {
                            MessageBox.Show("Добавление произошло успешно!");
                        }
                        else MessageBox.Show("Ошибка добавления!"+ cmd.Parameters["@rc"].Value.ToString());
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
