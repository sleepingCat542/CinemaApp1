CREATE PROCEDURE InsertSession
    @movie nvarchar(max),
	@cinema nvarchar(30),
	@hall nvarchar(30),
	@date date,
	@time time,
	@cost int,
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		DECLARE @movie_id uniqueidentifier;
		SET @movie_id = (SELECT ID FROM MOVIE WHERE NAME = @movie);
		DECLARE @cinema_id int;
		SET @cinema_id = (SELECT ID FROM CINEMA WHERE NAME = @cinema);
		DECLARE @hall_id int;
		SET @hall_id = (SELECT ID FROM HALL WHERE CINEMA_ID = @cinema_id and Name=@hall);
		DECLARE @free_seats int;
		SET @free_seats = (SELECT SEATS * ROWS FROM HALL WHERE NAME = @hall);
		BEGIN
		   INSERT INTO SESSION(MOVIE_ID, HALL_ID, DATE, TIME, COST, FREESEATS)
		      VALUES (@movie_id, @hall_id, @date, @time, @cost, @free_seats);
		   SET @rc = 1;
		END
	END;

	drop PROCEDURE InsertSession;

	exec InsertSession @movie='Аванпост', @cinema=N'Аврора', @hall='Большой', @date='23.11.2019', @time='16:30:00', @cost=7, @rc=0;
	exec InsertSession @movie='Аванпост', @cinema=N'Аврора', @hall='Большой', @date='24.11.2019', @time='16:30:00', @cost=7, @rc=0;
	exec InsertSession @movie='Аванпост', @cinema=N'Аврора', @hall='Большой', @date='25.11.2019', @time='20:50:00', @cost=6, @rc=0;
	exec InsertSession @movie='Аванпост', @cinema=N'Аврора', @hall='Большой', @date='26.11.2019', @time='20:50:00', @cost=6, @rc=0;
	exec InsertSession @movie='Аванпост', @cinema=N'Аврора', @hall='Большой', @date='27.11.2019', @time='20:50:00', @cost=6, @rc=0;
	exec InsertSession @movie='Аванпост', @cinema=N'Аврора', @hall='Большой', @date='28.11.2019', @time='13:30:00', @cost=5, @rc=0;
	exec InsertSession @movie='Аванпост', @cinema=N'Аврора', @hall='Большой', @date='29.11.2019', @time='13:30:00', @cost=5, @rc=0;
	exec InsertSession @movie='Аванпост', @cinema=N'Аврора', @hall='Большой', @date='30.11.2019', @time='13:30:00', @cost=5, @rc=0;
	exec InsertSession @movie='Аванпост', @cinema=N'Аврора', @hall='Большой', @date='01.11.2019', @time='13:30:00', @cost=5, @rc=0;

--delete hall where cinema_id = 548010;
--delete tickets where PURCHASE_ID = 46;
--delete purchase where id = 46;
--SELECT * FROM SESSION;
--SELECT * FROM HALL;
--select * from CINEMA;
--delete session where ID = 5;
--DROP PROCEDURE InsertSession;
--exec FullTextSearch @plot = '"Чествование группы"'