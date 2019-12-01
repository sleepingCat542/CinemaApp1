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
using System.Windows.Shapes;


namespace CinemaApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddSeat.xaml
    /// </summary>
    public partial class AddSeat : Window
    {
        SqlConnection cn = Connection.GetConnectionUser();
        string hall;
        int session;

        #region SendingSeat
        public int sendingRow1 = 0;
        public int sendingRow2 = 0;
        public int sendingRow3 = 0;
        public int sendingRow4 = 0;
        public int sendingRow5 = 0;
        public int sendingSeat1 = 0;
        public int sendingSeat2 = 0;
        public int sendingSeat3 = 0;
        public int sendingSeat4 = 0;
        public int sendingSeat5 = 0;
        #endregion

        public AddSeat(string hall, int session_id)
        {
            this.hall = hall;
            this.session = session_id;
            InitializeComponent();
            BindComboBoxRows(Row1);
            BindComboBoxRows(Row2);
            BindComboBoxRows(Row3);
            BindComboBoxRows(Row4);
            BindComboBoxRows(Row5);
        }

        public void BindComboBoxRows(ComboBox comboBoxName)
        {
            cn.Open();
            DataTable dataResults=Connection.GetRows(hall, session, cn);
            comboBoxName.ItemsSource = dataResults.DefaultView;
            Connection.CloseConnection(cn);
        }


        private void btnOk(object sender, RoutedEventArgs e)
        {
            if(Row1.Text!=null && Seat1.Text!=null)
            {
                sendingRow1 = Convert.ToInt32(Row1.Text);
                sendingSeat1 = Convert.ToInt32(Seat1.Text);
            }
            if (Row2.Text != null && Seat2.Text != null)
            {
                sendingRow2 = Convert.ToInt32(Row2.Text);
                sendingSeat2 = Convert.ToInt32(Seat2.Text);
            }
            if (Row3.Text != null && Seat3.Text != null)
            {
                sendingRow3 = Convert.ToInt32(Row3.Text);
                sendingSeat3 = Convert.ToInt32(Seat3.Text);
            }
            if (Row4.Text != null && Seat4.Text != null)
            {
                sendingRow4 = Convert.ToInt32(Row4.Text);
                sendingSeat4 = Convert.ToInt32(Seat4.Text);
            }
            if (Row5.Text != null && Seat5.Text != null)
            {
                sendingRow5 = Convert.ToInt32(Row5.Text);
                sendingSeat5 = Convert.ToInt32(Seat5.Text);
            }

            Close();

        }

        private void SetSeats(object sender, SelectionChangedEventArgs e)
        {
            cn.Open();
            ComboBox combo = (ComboBox)sender;
            int row = Convert.ToInt32(combo.Text);
            DataTable dataResults = Connection.GetSeats(hall, session, row, cn);
           
            switch (Convert.ToInt32(combo.Uid))
            {
                case 1:
                    Seat1.ItemsSource= dataResults.DefaultView;
                    break;
                case 2:
                    Seat2.ItemsSource = dataResults.DefaultView;
                    break;
                case 3:
                    Seat3.ItemsSource = dataResults.DefaultView;
                    break;
                case 4:
                    Seat4.ItemsSource = dataResults.DefaultView;
                    break;
                case 5:
                    Seat5.ItemsSource = dataResults.DefaultView;
                    break;

            }
        
            Connection.CloseConnection(cn);
        }
    }
}
