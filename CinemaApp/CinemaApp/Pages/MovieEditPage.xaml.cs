using CinemaApp.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Логика взаимодействия для MovieEditPage.xaml
    /// </summary>
    public partial class MovieEditPage : Page
    {
        string strName, imageName;
        string strNameVideo, videoName;
        public Model.Admin admin;
        SqlConnection cn;

        public MovieEditPage(Admin admin)
        {
            this.admin = admin;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            BindComboBoxCountry(Country);
            BindComboBoxName(Name);
            BindComboBoxStudio(Studio);
        }

        public void BindComboBoxCountry(ComboBox comboBoxName)
        {
            DataSet ds = Connection.GetCountry(cn);
            Country.ItemsSource = ds.Tables[0].DefaultView;
            Country.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
        }

        public void BindComboBoxName(ComboBox comboBoxName1)
        {
            DataSet ds = Connection.GetMovies(cn);
            comboBoxName1.ItemsSource = ds.Tables[0].DefaultView;
            comboBoxName1.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
        }

        public void BindComboBoxStudio(ComboBox comboBoxName1)
        {
            DataSet ds = Connection.GetStudioInfo(cn);
            comboBoxName1.ItemsSource = ds.Tables[0].DefaultView;
            comboBoxName1.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Video File (*.mp4)|*.mp4";
                fldlg.ShowDialog();
                {
                    strNameVideo = fldlg.SafeFileName;
                    videoName = fldlg.FileName;
                    Trailer.Text = "add";
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnBrowseVideo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.jpeg;*.bmp;*.gif;)|*.jpg;*.jpeg;*.bmp;*.gif;";
                fldlg.ShowDialog();
                {
                    strName = fldlg.SafeFileName;
                    imageName = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    image1.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnMovie(object sender, RoutedEventArgs e)
        {
            byte[] imgByteArr = null;
            byte[] videoByteArr = null;

            if (imageName != "")
            {
                FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
                imgByteArr = new byte[fs.Length];
                fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                fs.Close();
            }

            if (videoName != "")
            {
                FileStream fs = new FileStream(videoName, FileMode.Open, FileAccess.Read);
                videoByteArr = new byte[fs.Length];
                fs.Read(videoByteArr, 0, Convert.ToInt32(fs.Length));
                fs.Close();
            }
            try
            {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("UpdateMovie", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

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

                    SqlParameter check7 = new SqlParameter();
                    check7.ParameterName = "@check7";
                    check7.Value = this.check7.IsChecked == true ? true : false;

                    SqlParameter name = new SqlParameter();
                    name.ParameterName = "@name";
                    name.Value = this.Name.Text;

                SqlParameter country = new SqlParameter();
                    country.ParameterName = "@country";
                    country.Value = this.Country.Text;

                    SqlParameter time = new SqlParameter();
                    time.ParameterName = "@runningtime";
                    time.Value = this.Running_time.Text;

                    SqlParameter directorname = new SqlParameter();
                    directorname.ParameterName = "@studio";
                    directorname.Value = this.Studio.Text;

                    SqlParameter plot = new SqlParameter();
                    plot.ParameterName = "@plot";
                    plot.Value = this.Screenplay.Text;

                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(country);
                    cmd.Parameters.Add(time);
                    cmd.Parameters.Add(directorname);
                    cmd.Parameters.Add(plot);
                    cmd.Parameters.Add(check2);
                    cmd.Parameters.Add(check3);
                    cmd.Parameters.Add(check4);
                    cmd.Parameters.Add(check5);
                    cmd.Parameters.Add(check6);
                    cmd.Parameters.Add(check7);
                cmd.Parameters.Add(new SqlParameter("@image", imgByteArr));
                cmd.Parameters.Add(new SqlParameter("@trailer", videoByteArr));

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
