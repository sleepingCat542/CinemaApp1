CREATE PROCEDURE InsertStudio2	
	@name nvarchar(20),
	@year int,
	@country nvarchar(70),
	@image varbinary(max),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
	    DECLARE  @country_id varchar(10);
		SET @country_id = (SELECT ID FROM COUNTRY WHERE NAME = @country);
		BEGIN
		    INSERT INTO STUDIO (NAME, COUNTRY_ID, YEAR_OF_FOUNDATION, IMAGE)
			    VALUES (@name, @country_id, @year, @image);
			SET @rc = 1;
		END
	END;

DROP PROCEDURE InsertStudio2;
exec InsertStudio2 @name = 'Netflix',  @country = 'США', @year = 1997, @image= 'H:\Курсач\Проект\Images\Studio\Netflix.png', @rc = 1;
