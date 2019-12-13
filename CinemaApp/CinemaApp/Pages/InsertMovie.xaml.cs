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
using System.Windows.Shapes;

namespace CinemaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для InsertMovie.xaml
    /// </summary>
    public partial class InsertMovie : Page
    {
        string strName, imageName;
        string strNameVideo, videoName;
        public Model.Admin admin;
        SqlConnection cn;

        public InsertMovie(Admin admin)
        {
            this.admin = admin;
            cn = Connection.GetConnectionAdmin(admin.password);
            InitializeComponent();
            BindComboBoxCountry(Country);
            BindComboBoxGenre(Genre);
            BindComboBoxStudio(Studio);
        }

        public void BindComboBoxCountry(ComboBox comboBoxName)
        {
            DataSet ds = Connection.GetCountry(cn);
            Country.ItemsSource = ds.Tables[0].DefaultView;
            Country.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
        }

        public void BindComboBoxGenre(ComboBox comboBoxName1)
        {
            DataSet ds = Connection.GetGenres(cn);
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
            try
            {
                if (Validator.ValidTextBoxes(this.Name.Text, this.Country.Text, this.Genre.Text, this.Running_time.Text, this.Studio.Text,  this.Screenplay.Text))
                {
                    

                    byte[] imgByteArr=null;
                    byte[] videoByteArr=null;

                    if (imageName != "")
                    {
                        //Initialize a file stream to read the image file
                        FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);

                        //Initialize a byte array with size of stream
                        imgByteArr = new byte[fs.Length];

                        //Read data from the file stream and put into the byte array
                        fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));

                        //Close a file stream
                        fs.Close();
                    }

                    if (videoName != "")
                    {
                        FileStream fs = new FileStream(videoName, FileMode.Open, FileAccess.Read);

                        videoByteArr = new byte[fs.Length];

                        fs.Read(videoByteArr, 0, Convert.ToInt32(fs.Length));

                        fs.Close();
                    }

                            cn.Open();
                            SqlCommand cmd = new SqlCommand("InsertMovie", cn);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            SqlParameter name = new SqlParameter();
                            name.ParameterName = "@name";
                            name.Value = this.Name.Text;

                            SqlParameter surname = new SqlParameter();
                            surname.ParameterName = "@release";
                            surname.Value = this.pick.SelectedDate;

                            SqlParameter country = new SqlParameter();
                            country.ParameterName = "@country";
                            country.Value = this.Country.Text;

                            SqlParameter genre = new SqlParameter();
                            genre.ParameterName = "@genre";
                            genre.Value = this.Genre.Text;

                            SqlParameter time = new SqlParameter();
                            time.ParameterName = "@runningtime";
                            time.Value = this.Running_time.Text;

                            SqlParameter directorname = new SqlParameter();
                            directorname.ParameterName = "@studioname";
                            directorname.Value = this.Studio.Text;

                            SqlParameter screenplay = new SqlParameter();
                            screenplay.ParameterName = "@plot";
                            screenplay.Value = this.Screenplay.Text;

                            cmd.Parameters.Add(name);
                            cmd.Parameters.Add(surname);
                            cmd.Parameters.Add(country);
                            cmd.Parameters.Add(genre);
                            cmd.Parameters.Add(time);
                            cmd.Parameters.Add(directorname);
                            cmd.Parameters.Add(screenplay);
                            cmd.Parameters.Add(new SqlParameter("@image", imgByteArr));
                            cmd.Parameters.Add(new SqlParameter("@video", videoByteArr));

                            SqlParameter rc = new SqlParameter();
                            rc.ParameterName = "@rc";
                            rc.SqlDbType = SqlDbType.Bit;
                            rc.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(rc);

                            cmd.ExecuteNonQuery();

                            cn.Close();

                            if ((bool)cmd.Parameters["@rc"].Value)
                            {
                                MessageBox.Show("Добавление произошло успешно!");
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
