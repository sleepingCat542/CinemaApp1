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
    /// Логика взаимодействия для PageAddActor.xaml
    /// </summary>
    public partial class PageAddActor : Page
    {
        public Model.Admin admin;
        SqlConnection cn;

        public PageAddActor(Admin admin)
        {
            this.admin = admin;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            BindComboBoxNameActor(NameActor);
            BindComboBoxName(Name);
            BindComboBoxSurnameActor(SurnameActor);
        }

        public void BindComboBoxNameActor(ComboBox comboBoxName)
        {
            DataSet ds = Connection.GetActorInfo(cn);
            comboBoxName.ItemsSource = ds.Tables[0].DefaultView;
            comboBoxName.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
        }

        public void BindComboBoxName(ComboBox comboBoxName1)
        {
            DataSet ds = Connection.GetMovies(cn);
            comboBoxName1.ItemsSource = ds.Tables[0].DefaultView;
            comboBoxName1.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
        }

        public void BindComboBoxSurnameActor(ComboBox comboBoxName)
        {
            DataSet ds = Connection.GetActorInfo(cn);
            comboBoxName.ItemsSource = ds.Tables[0].DefaultView;
            comboBoxName.DisplayMemberPath = ds.Tables[0].Columns["Surname"].ToString();
        }

        private void AddCinema(object sender, RoutedEventArgs e)
        {
            try
            {
                cn.Open();
                int answer = Connection.AddActor(Name.Text, NameActor.Text, SurnameActor.Text, cn);
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
                cn.Close();
            }
        }
    }
}
