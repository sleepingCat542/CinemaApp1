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
		SET @hall_id = (SELECT ID FROM HALL WHERE CINEMA_ID = @cinema_id);
		DECLARE @free_seats int;
		SET @free_seats = (SELECT SEATS * ROWS FROM HALL WHERE NAME = @hall);
		BEGIN
		   INSERT INTO SESSION(MOVIE_ID, HALL_ID, DATE, TIME, COST, FREESEATS)
		      VALUES (@movie_id, @hall_id, @date, @time, @cost, @free_seats);
		   SET @rc = 1;
		END
	END;

SELECT * FROM SESSION;
SELECT * FROM HALL;
delete hall where cinema_id = 548010;
delete tickets where PURCHASE_ID = 46;
delete purchase where id = 46;

select * from CINEMA;
delete session where ID = 5;
DROP PROCEDURE InsertSession;
exec FullTextSearch @plot = '"Чествование группы"'