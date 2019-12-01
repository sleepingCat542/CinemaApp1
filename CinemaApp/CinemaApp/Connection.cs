using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp
{
    class Connection
    {      
        static public SqlConnection GetConnectionAdmin(string password)
        {
            SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["CinemaEntitiesAdmin"].ConnectionString);
            myBuilder.Password = password;
            return new SqlConnection(myBuilder.ConnectionString);
        }

        static public SqlConnection GetConnectionUser()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaEntitiesUser"].ConnectionString);
        }

        static public void CloseConnection(SqlConnection connection)
        {
            connection.Close();
        }

        static public DataTable GetRows(string hall_name, int session_id, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("AllowRows", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dataResults = new DataTable();

            SqlParameter session = new SqlParameter();
            session.ParameterName = "@session";
            session.Value = session_id;

            SqlParameter hall = new SqlParameter();
            hall.ParameterName = "@hall";
            hall.Value = hall_name;

            cmd.Parameters.Add(hall);
            cmd.Parameters.Add(session);

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);

            return dataResults;
            
        }

        static public DataTable GetSeats(string hall_name, int session_id, int select_row,SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("AllowSeats", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dataResults = new DataTable();

            SqlParameter session = new SqlParameter();
            session.ParameterName = "@session";
            session.Value = session_id;

            SqlParameter hall = new SqlParameter();
            hall.ParameterName = "@hall";
            hall.Value = hall_name;

            SqlParameter row = new SqlParameter();
            row.ParameterName = "@row";
            row.Value = select_row;

            cmd.Parameters.Add(hall);
            cmd.Parameters.Add(session);
            cmd.Parameters.Add(row);

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);

            return dataResults;

        }

        static public SqlParameter GetSetGenres(string movie, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetSetGenres", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter name = new SqlParameter();
            name.ParameterName = "@movie";
            name.Value = movie;
            cmd.Parameters.Add(name);

            SqlParameter resultGeners = new SqlParameter("@reslt", SqlDbType.NVarChar, 120);
            resultGeners.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(resultGeners);
            cmd.ExecuteNonQuery();

            return resultGeners;
        }

        static public SqlParameter GetSetActors(string movie, SqlConnection cn)
        {
            SqlParameter name = new SqlParameter();
            name.ParameterName = "@movie";
            name.Value = movie;
            SqlCommand cmd = new SqlCommand("GetSetActors", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(name);
            SqlParameter resultActors = new SqlParameter("@reslt", SqlDbType.NVarChar, 400);
            resultActors.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(resultActors);
            cmd.ExecuteNonQuery();

            return resultActors;
        }

        static public DataTable GetSessionInfo(Movie movie, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetSessionInfo", cn);
            DataTable dataResults = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter name = new SqlParameter();
            name.ParameterName = "@name";
            name.Value = movie.name;
     
            cmd.Parameters.Add(name);

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);

            return dataResults;
        }

        static public DataTable GetSessionInfoByCinema(string cinema, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetSessionInfo", cn);
            DataTable dataResults = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter cinema_par = new SqlParameter();
            cinema_par.ParameterName = "@cinema";
            cinema_par.Value = cinema;

            cmd.Parameters.Add(cinema_par);

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);

            return dataResults;
        }

        static public DataTable GetTicketInfo(string usersLogin, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetTicketInfo", cn);
            DataTable dataResults = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter login = new SqlParameter();
            login.ParameterName = "@login";
            login.Value = usersLogin;

            cmd.Parameters.Add(login);

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);

            return dataResults;

        }

        static public DataTable GetActorsInfo(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetActorInfo", cn);
            DataTable dataResults = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);

            return dataResults;
        }

        static public DataTable GetStudiosInfo(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetStudiosInfo", cn);
            DataTable dataResults = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);

            return dataResults;
        }

        static public DataTable GetCinemasInfo(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetCinemaInfo", cn);
            DataTable dataResults = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);

            return dataResults;
        }

    }
}
