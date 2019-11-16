CREATE PROCEDURE DeleteCinema
    @name nvarchar(30),
	@region nvarchar(30),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		DECLARE @cinema_id int;
		SET @cinema_id = (SELECT ID FROM CINEMA WHERE NAME = @name);
		BEGIN
		    DELETE HALL WHERE CINEMA_ID = @cinema_id;
		    DELETE CINEMA WHERE NAME = @name and REGION = @region;
		    SET @rc = 1;
		END
	END;
	 
EXEC DeleteCinema @name = 'Центральный', @region = 'Центральный', @rc = 1;
select * from CINEMA;
select * from HALL;
insert into CINEMA(NAME,REGION) values ('Центральный', 'Центральный');
insert into HALL(NAME,CINEMA_ID, SEATS, ROWS) values ('Главный', 3, 100, 10);
DROP PROCEDURE DeleteCinema;