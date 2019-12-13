CREATE PROCEDURE InsertTicket
    @movie nvarchar(max),
	@cinema nvarchar(30),
	@hall nvarchar(30),
	@date date,
	@time time,
	@pass nvarchar(10),
	@row1 int = null, @seat1 int = null, @row2 int = null, @seat2 int = null, @row3 int = null, @seat3 int = null, @row4 int = null, @seat4 int = null, @row5 int = null, @seat5 int = null,
	@mess nvarchar(50)=NULL output,
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
		exec CheckSeats @row1, @seat1, @hall, @message=@mess output;;		
		if (@mess IS NULL)
		begin
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row1, @seat1);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
               SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost where ID = @purchase_id; 
			   SET @rc = 1;
			   end;
		END;
		IF (@seat2 IS NOT NULL AND @row2 IS NOT NULL)
		BEGIN 
		exec CheckSeats @row2, @seat2, @hall, @message=@mess output;;		
		if (@mess is null)
		begin
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row2, @seat2);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
			   SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost where ID = @purchase_id; 
			   SET @rc = 1;
			   end;
		END;
		IF (@seat3 IS NOT NULL AND @row3 IS NOT NULL)
		BEGIN
		exec CheckSeats @row3, @seat3, @hall, @message=@mess output;;		
		if (@mess is null)
		begin
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row3, @seat3);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
			   SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost where ID = @purchase_id;
			   SET @rc = 1;
			   end;
		END;
	    IF (@seat4 IS NOT NULL AND @row4 IS NOT NULL)
		BEGIN
		exec CheckSeats @row4, @seat4, @hall, @message=@mess output;;		
		if (@mess is null)
		begin
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row4, @seat4);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
		       SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost where ID = @purchase_id; 
			   SET @rc = 1;
			   end;
		END;
		IF (@seat5 IS NOT NULL AND @row5 IS NOT NULL)
		BEGIN
		exec CheckSeats @row5, @seat5, @hall, @message=@mess output;;		
		if (@mess is null)
		begin
		   INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
		       VALUES (@session_id, @purchase_id, @row5, @seat5);
		   UPDATE SESSION SET FREESEATS = FREESEATS - 1 WHERE (MOVIE_ID = @movie_id and HALL_ID = @hall_id and DATE = @date and TIME = @time);
		       SET @count =  (SELECT COUNT(*) SEAT FROM TICKETS WHERE PURCHASE_ID = @purchase_id);
		   UPDATE PURCHASE SET PRICE = @count * @cost where ID = @purchase_id;
			   SET @rc = 1;
			   END;
		END;	
END;
	

DROP PROCEDURE InsertTicket;



EXEC InsertTicket @movie = 'Аванпост', @cinema = 'Аврора', @hall = 'Большой', 
@date = '26.11.2019', @time = '20:50', @pass = 'LSFc',
@row1 = 6, @seat1 = 7, @row2 = 6, @seat2 = 8, @rc = 0;
--EXEC InsertTicket @movie = 'Аванпост', @cinema = 'Аврора', @hall = 'Большой', 
--@date = '29.11.2019', @time = '13:30', @pass = 'AVTb',
--@row1 = 8, @seat1 = 8, @row2 = 8, @seat2 = 9, @rc = 0;
--EXEC InsertTicket @movie = 'Аванпост', @cinema = 'Аврора', @hall = 'Большой', 
--@date = '29.11.2019', @time = '13:30', @pass = 'AVTb',
--@row1 = 8, @seat1 = 8, @row2 = 8, @seat2 = 9, @rc = 0;
--EXEC InsertTicket @movie = 'Аванпост', @cinema = 'Аврора', @hall = 'Большой', 
--@date = '29.11.2019', @time = '13:30', @pass = 'AVTb',
--@row1 = 8, @seat1 = 8, @row2 = 8, @seat2 = 9, @rc = 0;
--EXEC InsertTicket @movie = 'Аванпост', @cinema = 'Аврора', @hall = 'Большой', 
--@date = '29.11.2019', @time = '13:30', @pass = 'AVTb',
--@row1 = 8, @seat1 = 8, @row2 = 8, @seat2 = 9, @rc = 0;
--EXEC InsertTicket @movie = 'Аванпост', @cinema = 'Аврора', @hall = 'Большой', 
--@date = '29.11.2019', @time = '13:30', @pass = 'AVTb',
--@row1 = 8, @seat1 = 8, @row2 = 8, @seat2 = 9, @rc = 0;
--EXEC InsertTicket @movie = 'Аванпост', @cinema = 'Аврора', @hall = 'Большой', 
--@date = '29.11.2019', @time = '13:30', @pass = 'AVTb',
--@row1 = 8, @seat1 = 8, @row2 = 8, @seat2 = 9, @rc = 0;



select * from SESSION;
select * from TICKETS;
SELECT * FROM PURCHASE;
DELETE TICKETS;
DELETE PURCHASE;


