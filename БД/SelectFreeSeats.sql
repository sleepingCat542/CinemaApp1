CREATE PROCEDURE SelectFreeSeats
@movie nvarchar(max),
@hall nvarchar(30),
@cinema nvarchar(30), 
@date date,
@time time,
@freeseats int = NULL output
AS BEGIN
    SET @freeseats = (SELECT S.FREESEATS FROM SESSION S INNER JOIN MOVIE M ON M.ID = S.MOVIE_ID
    INNER JOIN HALL H ON H.ID = S.HALL_ID
	INNER JOIN CINEMA C ON C.ID= H.CINEMA_ID
    WHERE M.NAME = @movie AND H.NAME = @hall AND DATE = @date AND TIME = @time);
	PRINT @freeseats;
END;

DROP PROCEDURE SelectFreeSeats;

--exec SelectFreeSeats @movie = 'Веном', @cinema = 'Центральный', @hall = 'Главный', @date = '2018-12-04', @time = '15:00';