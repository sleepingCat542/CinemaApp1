using CinemaApp.Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


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

        static public SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaEntities"].ConnectionString);
        }

        static public SqlConnection GetConnectionUser()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["CinemaEntitiesUser"].ConnectionString);
        }

        static public void CloseConnection(SqlConnection connection)
        {
            connection.Close();
        }

        static public DataSet GetRows(string hall_name, int session_id, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("AllowRows", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dataResults = new DataSet();

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

        static public DataSet GetGenres(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetGenres", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dataResults = new DataSet();

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);


            return dataResults;

        }

        static public DataSet GetSeats(string hall_name, int session_id, int select_row,SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("AllowSeats", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dataResults = new DataSet();

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

        static public DataSet GetActorInfo(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetActorInfo", cn);
            DataSet dataResults = new DataSet();
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

        static public DataSet GetStudioInfo(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetStudiosInfo", cn);
            DataSet dataResults = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);

            return dataResults;
        }

        static public DataSet GetMovies(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetMovieInfo", cn);
            DataSet dataResults = new DataSet();
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

        static public DataSet GetCinemaInfo(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetCinemaInfo", cn);
            DataSet dataResults = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);

            return dataResults;
        }

        static public DataSet GetHallInfo(string cinemaName, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetHallInfo", cn);
            DataSet dataResults = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter cinema = new SqlParameter();
            cinema.ParameterName = "@cinema";
            cinema.Value = cinemaName;
            cmd.Parameters.Add(cinema);

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);

            return dataResults;
        }

        static public DataSet GetCountry(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("GetCountry", cn);
            DataSet dataResults = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            adapter1.Fill(dataResults);

            return dataResults;
        }

        static public int AddActor(string name, string actorName, string actorSurname, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("AddActor", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter nameFilm = new SqlParameter();
            nameFilm.ParameterName = "@nameFilm";
            nameFilm.Value = name;
            cmd.Parameters.Add(nameFilm);


            SqlParameter nameA = new SqlParameter();
            nameA.ParameterName = "@name";
            nameA.Value = actorName;
            cmd.Parameters.Add(nameA);

            SqlParameter surnameA = new SqlParameter();
            surnameA.ParameterName = "@surname";
            surnameA.Value = actorSurname;
            cmd.Parameters.Add(surnameA);

            SqlParameter resultGeners = new SqlParameter("@rc", SqlDbType.Int);
            resultGeners.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(resultGeners);
            cmd.ExecuteNonQuery();

            return Convert.ToInt32(resultGeners.Value);
        }

        static public int AddGenre(string name, string genre, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("AddGenre", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter nameFilm = new SqlParameter();
            nameFilm.ParameterName = "@nameFilm";
            nameFilm.Value = name;
            cmd.Parameters.Add(nameFilm);


            SqlParameter nameGenre = new SqlParameter();
            nameGenre.ParameterName = "@nameGenre";
            nameGenre.Value = genre;
            cmd.Parameters.Add(nameGenre);

            SqlParameter resultGeners = new SqlParameter("@rc", SqlDbType.Int);
            resultGeners.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(resultGeners);
            cmd.ExecuteNonQuery();

            return Convert.ToInt32(resultGeners.Value);
        }

        static public int DeleteTicket(string unic, string row, string seat, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("DeleteTicket", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter unic_code = new SqlParameter();
            unic_code.ParameterName = "@unic";
            unic_code.Value = unic;
            cmd.Parameters.Add(unic_code);


            SqlParameter row_id = new SqlParameter();
            row_id.ParameterName = "@row";
            row_id.Value = Convert.ToInt32(row);
            cmd.Parameters.Add(row_id);

            SqlParameter seat_id = new SqlParameter();
            seat_id.ParameterName = "@seat";
            seat_id.Value = Convert.ToInt32(seat);
            cmd.Parameters.Add(seat_id);

            SqlParameter resultGeners = new SqlParameter("@rc", SqlDbType.Int);
            resultGeners.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(resultGeners);
            cmd.ExecuteNonQuery();        

            return Convert.ToInt32(resultGeners.Value);
        }

        static public int DeleteCinema(string name, string city, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("DeleteCinema", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter name_cinema = new SqlParameter();
            name_cinema.ParameterName = "@name";
            name_cinema.Value = name;
            cmd.Parameters.Add(name_cinema);


            SqlParameter city_cinema = new SqlParameter();
            city_cinema.ParameterName = "@city";
            city_cinema.Value = city;
            cmd.Parameters.Add(city_cinema);


            SqlParameter result = new SqlParameter("@rc", SqlDbType.Int);
            result.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(result);
            cmd.ExecuteNonQuery();

            return Convert.ToInt32(result.Value);
        }

        static public int DeleteMovie(string name,  SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("DeleteMovie", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter name_cinema = new SqlParameter();
            name_cinema.ParameterName = "@name";
            name_cinema.Value = name;
            cmd.Parameters.Add(name_cinema);

            SqlParameter result = new SqlParameter("@rc", SqlDbType.Int);
            result.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(result);
            cmd.ExecuteNonQuery();

            return Convert.ToInt32(result.Value);
        }

        static public int DeleteSession(int sessionId, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("DeleteSession", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter session = new SqlParameter();
            session.ParameterName = "@id";
            session.Value = sessionId;
            cmd.Parameters.Add(session);

            SqlParameter result = new SqlParameter("@rc", SqlDbType.Int);
            result.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(result);
            cmd.ExecuteNonQuery();

            return Convert.ToInt32(result.Value);
        }

        static public SqlCommand AddSqlCinema(string cinemaName, string cinemaAddress, string cinemaCity, string cinemaWeb, string cinemaTimetable, int hall, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("InsertCinema", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter name = new SqlParameter();
            name.ParameterName = "@name";
            name.Value = cinemaName;

            SqlParameter address = new SqlParameter();
            address.ParameterName = "@address";
            address.Value = cinemaAddress;

            SqlParameter region = new SqlParameter();
            region.ParameterName = "@city";
            region.Value = cinemaCity;

            SqlParameter website = new SqlParameter();
            website.ParameterName = "@website";
            website.Value = cinemaWeb;

            SqlParameter ticketoffice = new SqlParameter();
            ticketoffice.ParameterName = "@timetable";
            ticketoffice.Value = cinemaTimetable;

            SqlParameter halls = new SqlParameter();
            halls.ParameterName = "@halls";
            halls.Value = hall;

            cmd.Parameters.Add(name);
            cmd.Parameters.Add(address);
            cmd.Parameters.Add(region);
            cmd.Parameters.Add(website);
            cmd.Parameters.Add(ticketoffice);
            cmd.Parameters.Add(halls);

            SqlParameter message = new SqlParameter("@message", SqlDbType.NVarChar, 200);
            message.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(message);

            return cmd;
        }

        static public int AddSqlSession(string movie, string cinema, string hall, DateTime? date, DateTime? time, int cost, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("InsertSession", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter movieS = new SqlParameter();
            movieS.ParameterName = "@movie";
            movieS.Value = movie;

            SqlParameter cinemaS = new SqlParameter();
            cinemaS.ParameterName = "@cinema";
            cinemaS.Value =cinema;

            SqlParameter hallS = new SqlParameter();
            hallS.ParameterName = "@hall";
            hallS.Value = hall;

            SqlParameter dateS = new SqlParameter();
            dateS.ParameterName = "@date";
            dateS.Value = date;

            SqlParameter timeS = new SqlParameter();
            timeS.ParameterName = "@time";
            timeS.Value = time;

            SqlParameter costS = new SqlParameter();
            costS.ParameterName = "@cost";
            costS.Value = cost;

            cmd.Parameters.Add(movieS);
            cmd.Parameters.Add(cinemaS);
            cmd.Parameters.Add(hallS);
            cmd.Parameters.Add(dateS);
            cmd.Parameters.Add(timeS);
            cmd.Parameters.Add(costS);

            SqlParameter rc = new SqlParameter();
            rc.ParameterName = "@rc";
            rc.SqlDbType = System.Data.SqlDbType.Int;
            rc.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(rc);
            cmd.ExecuteNonQuery();

            return Convert.ToInt32(rc.Value);
        }

        static public SqlCommand AddSqlHall(string nameHall, string cinemaHall, int row, int seat, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("InsertHall", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter name = new SqlParameter();
            name.ParameterName = "@name";
            name.Value = nameHall;

            SqlParameter cinema = new SqlParameter();
            cinema.ParameterName = "@cinema";
            cinema.Value = cinemaHall;

            SqlParameter rows = new SqlParameter();
            rows.ParameterName = "@rows";
            rows.Value = row;

            SqlParameter seats = new SqlParameter();
            seats.ParameterName = "@seats";
            seats.Value = seat;

            cmd.Parameters.Add(name);
            cmd.Parameters.Add(cinema);
            cmd.Parameters.Add(rows);
            cmd.Parameters.Add(seats);

            SqlParameter rc = new SqlParameter();
            rc.ParameterName = "@message";
            rc.SqlDbType = System.Data.SqlDbType.NVarChar;
            rc.Size = 200;
            rc.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(rc);

            return cmd;
        }

        static public int InsertActor(string name, string surname, string country, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("InsertActor", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter nameA = new SqlParameter();
            nameA.ParameterName = "@name";
            nameA.Value = name;

            SqlParameter surnameA = new SqlParameter();
            surnameA.ParameterName = "@surname";
            surnameA.Value =surname;

            SqlParameter countryA = new SqlParameter();
            countryA.ParameterName = "@country";
            countryA.Value = country;

            cmd.Parameters.Add(nameA);
            cmd.Parameters.Add(surnameA);
            cmd.Parameters.Add(countryA);

            SqlParameter rc = new SqlParameter();
            rc.ParameterName = "@rc";
            rc.SqlDbType = System.Data.SqlDbType.Int;
            rc.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(rc);
            cmd.ExecuteNonQuery();

            return Convert.ToInt32(rc.Value);
        }

        static public int InsertStudio(string name, string country, int year, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("InsertStudio", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter nameS = new SqlParameter();
            nameS.ParameterName = "@name";
            nameS.Value = name;

            SqlParameter yearS = new SqlParameter();
            yearS.ParameterName = "@year";
            yearS.Value = year;

            SqlParameter countryS = new SqlParameter();
            countryS.ParameterName = "@country";
            countryS.Value = country;

            cmd.Parameters.Add(nameS);
            cmd.Parameters.Add(yearS);
            cmd.Parameters.Add(countryS);

            SqlParameter rc = new SqlParameter();
            rc.ParameterName = "@rc";
            rc.SqlDbType = System.Data.SqlDbType.Int;
            rc.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(rc);
            cmd.ExecuteNonQuery();

            return Convert.ToInt32(rc.Value);
        }

    }
}
