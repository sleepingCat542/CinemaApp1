CREATE PROCEDURE DeleteCinema
    @name nvarchar(30),
	@city nvarchar(30),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		DECLARE @cinema_id int;
		SET @cinema_id = (SELECT ID FROM CINEMA WHERE NAME = @name AND CITY = @city);
		BEGIN TRY
		BEGIN TRAN
		    DELETE HALL WHERE CINEMA_ID = @cinema_id;
		    DELETE CINEMA WHERE ID=@cinema_id;
		    SET @rc = 1;
		COMMIT TRAN;
		END TRY
		BEGIN CATCH		
		IF @@TRANCOUNT>0 ROLLBACK TRAN;
		END CATCH;
	END;
	 
EXEC DeleteCinema @name = 'Центральный', @city = 'Минск', @rc = 1;
select * from CINEMA;
select * from HALL;
insert into CINEMA(NAME,REGION) values ('Центральный', 'Центральный');
insert into HALL(NAME,CINEMA_ID, SEATS, ROWS) values ('Главный', 3, 100, 10);
DROP PROCEDURE DeleteCinema;