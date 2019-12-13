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
    /// Логика взаимодействия для Log_in.xaml
    /// </summary>
    public partial class Log_in : Window
    {
        public Log_in()
        {
            InitializeComponent();
        }

        private void btnRegestration_Click(object sender, RoutedEventArgs e)
        {
            Regestration registraition = new Regestration();
            registraition.Show();
            Close();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //добавить проверку на макс длинну
                if (Validator.ValidTextBoxes(Password.Password, Login.Text))
                {
                    if (Login.Text=="admin")
                    {
                        SqlConnection cn = Connection.GetConnectionAdmin(Password.Password);
                        SqlConnectionStringBuilder sqlbuilder = new SqlConnectionStringBuilder(cn.ConnectionString);

                        Model.Admin admin = new Model.Admin(sqlbuilder.UserID, sqlbuilder.Password);
                        MainWindow mainWnd = new MainWindow(admin);
                        mainWnd.Show();
                        this.Close();
                    }
                    else
                    {
                        using (SqlConnection cn = Connection.GetConnectionUser())
                        {
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("Authorisation", cn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter password = new SqlParameter();
                            password.ParameterName = "@password";
                            password.Value = Password.Password;

                            SqlParameter login = new SqlParameter();
                            login.ParameterName = "@login";
                            login.Value = Login.Text;

                            cmd.Parameters.Add(login);
                            cmd.Parameters.Add(password);

                            SqlParameter rc = new SqlParameter();
                            rc.ParameterName = "@rc";
                            rc.SqlDbType = SqlDbType.Bit;
                            rc.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(rc);

                            cmd.ExecuteNonQuery();

                            

                            if ((bool)cmd.Parameters["@rc"].Value)
                            {

                                cmd = new SqlCommand("UserInfo", cn);
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlParameter login2 = new SqlParameter();
                                login2.ParameterName = "@login";
                                login2.Value = Login.Text;

                                SqlParameter password2 = new SqlParameter();
                                password2.ParameterName = "@password";
                                password2.Value = Password.Password;

                                cmd.Parameters.Add(login2);
                                cmd.Parameters.Add(password2);

                                SqlParameter id = new SqlParameter();
                                id.ParameterName = "@id";
                                id.SqlDbType = SqlDbType.UniqueIdentifier;
                                id.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(id);

                                SqlParameter email = new SqlParameter();
                                email.ParameterName = "@email";
                                email.SqlDbType = SqlDbType.NVarChar;
                                email.Size = 50;
                                email.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(email);

                                cmd.ExecuteNonQuery();

                                Model.User user = new Model.User(cmd.Parameters["@id"].Value, Login.Text, Password.Password, cmd.Parameters["@email"].Value);
                                MainWindow mainWnd = new MainWindow(user);
                                mainWnd.Show();
                                this.Close();
                            }                           
                            else MessageBox.Show("Ошибка авторизации! Неверный логин или пароль!");
                            cn.Close();
                        }
                    }
                }
                else MessageBox.Show("Введите все данные!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
