using CinemaApp.Pages;
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

namespace CinemaApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для AddSeat.xaml
    /// </summary>
    public partial class AddSeat : UserControl
    {
        SqlConnection cn = Connection.GetConnectionUser();
        DataRowView rowViewer;
        string hall;
        int session;
        public bool submit=false; 

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

        public AddSeat(DataRowView r, string hall, int session_id)
        {
            this.rowViewer = r;
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
            DataSet dataResults = Connection.GetRows(hall, session, cn);
            comboBoxName.ItemsSource = dataResults.Tables[0].DefaultView;
            comboBoxName.DisplayMemberPath = dataResults.Tables[0].Columns["ROW_F"].ToString();
            Connection.CloseConnection(cn);
        }


        private void btnOk(object sender, RoutedEventArgs e)
        {
            if (Row1.Text != String.Empty && Seat1.Text != String.Empty)
            {
                sendingRow1 = Convert.ToInt32(Row1.Text);
                sendingSeat1 = Convert.ToInt32(Seat1.Text);
            }
            if (Row2.Text != String.Empty && Seat2.Text != String.Empty)
            {
                sendingRow2 = Convert.ToInt32(Row2.Text);
                sendingSeat2 = Convert.ToInt32(Seat2.Text);
            }
            if (Row3.Text != String.Empty && Seat3.Text != String.Empty)
            {
                sendingRow3 = Convert.ToInt32(Row3.Text);
                sendingSeat3 = Convert.ToInt32(Seat3.Text);
            }
            if (Row4.Text != String.Empty && Seat4.Text != String.Empty)
            {
                sendingRow4 = Convert.ToInt32(Row4.Text);
                sendingSeat4 = Convert.ToInt32(Seat4.Text);
            }
            if (Row5.Text != String.Empty && Seat5.Text != String.Empty)
            {
                sendingRow5 = Convert.ToInt32(Row5.Text);
                sendingSeat5 = Convert.ToInt32(Seat5.Text);
            }

            submit = true;
            Grid g = (Grid)this.Parent;
            Grid gr = (Grid)g.Parent;
            ByePage p = (ByePage)gr.Parent;
            p.Bying(this, rowViewer);
        }

        private void SetSeats(object sender, SelectionChangedEventArgs e)
        {
        }

        private void SetSeats(object sender, DragEventArgs e)
        {
            
        }

        private void SetSeats(object sender, MouseButtonEventArgs e)
        {
            cn.Open();
            ComboBox combo = null;
            ComboBox comboSender = (ComboBox)sender;
            if (comboSender.Name=="Seat1")
            combo = Row1;
            else if (comboSender.Name == "Seat5")
                combo = Row5;
            else if (comboSender.Name == "Seat2")
                combo = Row2;
            else if (comboSender.Name == "Seat3")
                combo = Row3;
            else if (comboSender.Name == "Seat4")
                combo = Row4;
            int row = Convert.ToInt32(combo.Text);
            //int row = Convert.ToInt32(combo.Text);
            DataSet dataResults = Connection.GetSeats(hall, session, row, cn);

            switch (Convert.ToInt32(combo.Uid))
            {
                case 1:
                    {
                        Seat1.ItemsSource = dataResults.Tables[0].DefaultView;
                        Seat1.DisplayMemberPath = dataResults.Tables[0].Columns["FREESEAT"].ToString();
                        break;
                    }
                case 2:
                    {
                        Seat2.ItemsSource = dataResults.Tables[0].DefaultView;
                        Seat2.DisplayMemberPath = dataResults.Tables[0].Columns["FREESEAT"].ToString();
                        break;
                    }
                case 3:
                    {
                        Seat2.ItemsSource = dataResults.Tables[0].DefaultView;
                        Seat2.DisplayMemberPath = dataResults.Tables[0].Columns["FREESEAT"].ToString();
                        break;
                    }
                case 4:
                    {
                        Seat2.ItemsSource = dataResults.Tables[0].DefaultView;
                        Seat2.DisplayMemberPath = dataResults.Tables[0].Columns["FREESEAT"].ToString();
                        break;
                    }
                case 5:
                    {
                        Seat2.ItemsSource = dataResults.Tables[0].DefaultView;
                        Seat2.DisplayMemberPath = dataResults.Tables[0].Columns["FREESEAT"].ToString();
                        break;
                    }

            }

            Connection.CloseConnection(cn);
        }
    }
}
