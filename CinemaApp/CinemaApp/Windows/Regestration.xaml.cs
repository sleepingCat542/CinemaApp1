using CinemaApp.Windows;
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

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для Regestration.xaml
    /// </summary>
    public partial class Regestration : Window
    {
        public Regestration()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            Log_in signin = new Log_in();
            signin.Show();
            this.Close();
        }

        private void btnRegestration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validator.ValidTextBoxes(Password.Password, Login.Text, EMail.Text, RepPassword.Password))
                {
                    using (SqlConnection cn = Connection.GetConnectionUser())
                    {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand("Registration", cn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter password = new SqlParameter();
                        password.ParameterName = "@password";
                        password.Value = Password.Password;

                        SqlParameter login = new SqlParameter();
                        login.ParameterName = "@login";
                        login.Value = Login.Text;

                        SqlParameter email = new SqlParameter();
                        email.ParameterName = "@email";
                        email.Value = EMail.Text;

                        cmd.Parameters.Add(login);
                        cmd.Parameters.Add(email);
                        cmd.Parameters.Add(password);

                        SqlParameter rc = new SqlParameter();
                        rc.ParameterName = "@rc";
                        rc.SqlDbType = SqlDbType.Bit;
                        rc.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(rc);

                        SqlParameter message = new SqlParameter();
                        message.ParameterName = "@message";
                        message.SqlDbType = SqlDbType.NVarChar;
                        message.Size = 200;
                        message.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(message);

                        cmd.ExecuteNonQuery();

                        if ((bool)cmd.Parameters["@rc"].Value)
                        {
                            MessageBox.Show("Вы успешно зарегистрированы!/n Теперь вы можете войти в систему");
                            Regestration regestrationWnd = new Regestration();
                            regestrationWnd.Show();
                            this.Close();
                        }
                        else MessageBox.Show((string)cmd.Parameters["@message"].Value);
                        cn.Close();
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
