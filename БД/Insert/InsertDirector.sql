CREATE PROCEDURE InsertDirector
    @name nvarchar(20),
	@surname nvarchar(20),
	@country nvarchar(70),
	@age tinyint,
	@image varbinary(max),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
	    DECLARE  @country_id varchar(10);
		SET @country_id = (SELECT ID FROM COUNTRY WHERE NAME = @country);
		BEGIN
		    INSERT INTO DIRECTOR (NAME, SURNAME, COUNTRY_ID, AGE, IMAGE)
			    VALUES (@name, @surname, @country_id, @age, @image);
			SET @rc = 1;
		END
	END;

DROP PROCEDURE InsertDirector;
--exec InsertDirector @name = 'Том', @surname = 'Харди', @country = 'Великобритания', @age = 41, @pic = 'C:\Cinema\Images\Actor\Tom_Hardy.jpg', @rc = 1;
