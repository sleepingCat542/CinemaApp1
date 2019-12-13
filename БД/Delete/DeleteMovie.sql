CREATE PROCEDURE DeleteMovie
    @name nvarchar(max),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		BEGIN
		    DELETE MOVIE WHERE NAME = @name;
		    SET @rc = 1;
		END
	END;
	 
EXEC DeleteMovie @name = 'Веном', @rc = 1;
select * from MOVIE;
DROP PROCEDURE DeleteMovie;