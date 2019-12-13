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
    /// Логика взаимодействия для InsertStudioPage.xaml
    /// </summary>
    public partial class InsertStudioPage : Page
    {
        public Model.Admin admin;
        SqlConnection cn;

        public InsertStudioPage(Admin admin)
        {
            this.admin = admin;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            BindComboBoxCountry(Country);
        }

        public void BindComboBoxCountry(ComboBox comboBoxName)
        {
            DataSet ds = Connection.GetCountry(cn);
            Country.ItemsSource = ds.Tables[0].DefaultView;
            Country.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
        }
        //int.TryParse(stringToTest, result);

        private void Add(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validator.ValidTextBoxes(this.Name.Text, this.Year.Text, this.Country.Text))
                {
                    int result;
                    if (!int.TryParse(Year.Text, out result))
                        throw new Exception("Введен неверный год");
                    try
                    {
                        cn.Open();
                        int answer = Connection.InsertStudio(Name.Text,  Country.Text, result, cn);
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
                else MessageBox.Show("Введите данные!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
