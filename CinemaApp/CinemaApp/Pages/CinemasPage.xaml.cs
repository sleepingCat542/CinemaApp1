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
    /// Логика взаимодействия для CinemasPage.xaml
    /// </summary>
    public partial class CinemasPage : Page
    {
        SqlConnection cn;
        bool isAdmin = false;
        public Model.Admin admin;
        public Model.User user;
        Movie movie;

        public CinemasPage(User user)
        {
            this.user = user;
            cn = Connection.GetConnectionUser();
            InitializeComponent();
            btnAdmin.Visibility = Visibility.Hidden;
            btnAdminHall.Visibility = Visibility.Hidden;
            btnAdminEdit.Visibility = Visibility.Hidden;
            btnAdminEdit.Visibility = Visibility.Hidden;
            FillCinemas();
        }

        public CinemasPage(Admin admin)
        {
            this.admin = admin;
            isAdmin = true;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            FillCinemas();
        }

        public void FillCinemas()
        {
            cn.Open();
            DataTable cinemas = Connection.GetCinemasInfo(cn);

            grid.ItemsSource = cinemas.DefaultView;
            cn.Close();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = (DataGridRow)sender;
            DataRowView rw = (DataRowView)row.Item;
            if(!isAdmin)
            this.NavigationService.Navigate(new ByePage(user, movie, "Cinema", rw.Row.ItemArray[1].ToString()));
            else
                this.NavigationService.Navigate(new ByePage(admin, movie, "Cinema", rw.Row.ItemArray[1].ToString()));
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new InsertCinema(admin));
        }

        private void btnAdminHall_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new InsertHallPage(admin));
        }

        private void DataGridRow_PreviewMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isAdmin)
            {
                DataGridRow row = (DataGridRow)sender;
                DataRowView rw = (DataRowView)row.Item;
                MessageBoxResult resul = MessageBox.Show("Вы уверены, что хотите удалить кинотеатр?", "Удаление", MessageBoxButton.OKCancel);
                if (resul != MessageBoxResult.Cancel)
                {
                    cn.Open();
                    int result = Connection.DeleteCinema(rw.Row.ItemArray[1].ToString(), rw.Row.ItemArray[0].ToString(), cn);
                    if (result == 1)
                    {
                        MessageBox.Show("Удаление прошло успешно!");
                        FillCinemas();
                    }
                    else
                        MessageBox.Show("Ошибка удаления!");
                    cn.Close();
                }

               
            }
        }

        private void btnAdminEdit_Click(object sender, RoutedEventArgs e)
        {

                this.NavigationService.Navigate(new CinemaEditPage(admin));
           
        }
    }
}
