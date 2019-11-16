CREATE PROCEDURE InsertTicket
    @movie nvarchar(max),
	@cinema nvarchar(30),
	@hall nvarchar(30),
	@date date,
	@time time,
	@pass nvarchar(10),
	@row1 int = null, @seat1 int = null, @row2 int = null, @seat2 int = null, @row3 int = null, @seat3 int = null, @row4 int = null, @seat4 int = null, @row5 int = null, @seat5 int = null,
	@row6 int = null, @seat6 int = null, @row7 int = null, @seat7 int = null, @row8 int = null, @seat8 int = null, @row9 int = null, @seat9 int = null, @row10 int = null, @seat10 int = null, 
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		DECLARE @movie_id uniqueidentifier;
		SET @movie_id = (SELECT ID FROM MOVIE WHERE NAME = @movie);
		DECLARE @cinema_id int;
		SET @cinema_id = (SELECT ID FROM CINEMA WHERE NAME = @cinema);
		DECLARE @hall_id int;
		SET @hall_id = (SELECT ID FROM HALL WHERE (NAME = @hall and CINEMA_ID = @cinema_id));
		DECLARE @session_id int;
		SET @session_id = (SELECT ID FROM SESSION WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time));
		DECLARE @purchase_id int;
		SET @purchase_id = (SELECT ID FROM PURCHASE WHERE (UNICK_TICKET = @pass));
		DECLARE @count INT;
		DECLARE @cost INT;
        SET @cost = (SELECT COST FROM SESSION WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time));
		IF (@seat1 IS NOT NULL AND @row1 IS NOT NULL)
		BEGIN
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row1, @seat1);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
               SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost; 
			   SET @rc = 1;
		END;
		IF (@seat2 IS NOT NULL AND @row2 IS NOT NULL)
		BEGIN 
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row2, @seat2);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
			   SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost; 
			   SET @rc = 1;
		END;
		IF (@seat3 IS NOT NULL AND @row3 IS NOT NULL)
		BEGIN
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row3, @seat3);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
			   SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost; 
			   SET @rc = 1;
		END;
	    IF (@seat4 IS NOT NULL AND @row4 IS NOT NULL)
		BEGIN
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row4, @seat4);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
		       SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost; 
			   SET @rc = 1;
		END;
		IF (@seat5 IS NOT NULL AND @row5 IS NOT NULL)
		BEGIN
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row5, @seat5);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
		       SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost; 
			   SET @rc = 1;
		END;
		IF (@seat6 IS NOT NULL AND @row6 IS NOT NULL)
		BEGIN
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row6, @seat6);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
		       SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost; 
			   SET @rc = 1;
		END;
		IF (@seat7 IS NOT NULL AND @row7 IS NOT NULL)
		BEGIN
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row7, @seat7);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
		       SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost; 
			   SET @rc = 1;
		END;
		IF (@seat8 IS NOT NULL AND @row8 IS NOT NULL)
		BEGIN
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row8, @seat8);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
		       SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost; 
			   SET @rc = 1;
		END;
		IF (@seat9 IS NOT NULL AND @row9 IS NOT NULL)
		BEGIN
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row9, @seat9);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
		       SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost; 
			   SET @rc = 1;
		END;
	    IF (@seat10 IS NOT NULL AND @row10 IS NOT NULL)
		BEGIN
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row10, @seat10);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
		       SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost; 
			   SET @rc = 1;
		END;
END;
	

DROP PROCEDURE InsertTicket;



EXEC InsertTicket @movie = 'Малифесента', @cinema = 'Беларусь', @hall = 'Второй', 
@date = '4.12.2018', @time = '15:00', @pass = 'QOAMO',
@row1 = 8, @seat1 = 8, @row2 = 8, @seat2 = 9, @rc = 0;



select * from SESSION;
select * from TICKETS;
SELECT * FROM PURCHASE;
DELETE TICKETS;
DELETE PURCHASE;


