CREATE PROCEDURE InsertStudio	
    @name nvarchar(20),
	@country nvarchar(70),
	@year int,
	@rc int output
	AS BEGIN
	    SET @rc = 0;
	    DECLARE  @country_id varchar(10);
		SET @country_id = (SELECT ID FROM COUNTRY WHERE NAME = @country);
		BEGIN
		    INSERT INTO STUDIO (NAME, COUNTRY_ID, YEAR_OF_FOUNDATION)
			SELECT @name, @country_id, @year
			SET @rc = 1;
		END
	END;

DROP PROCEDURE InsertStudio;


exec InsertStudio @name = 'Netflix',  @country = 'США', @year = 1997, @rc = 1;


declare @countryId varchar(10)= (SELECT ID FROM COUNTRY WHERE NAME = 'США');
INSERT INTO STUDIO (NAME, COUNTRY_ID, YEAR_OF_FOUNDATION, IMAGE) select 'Netflix', @countryId, 1997,  BulkColumn
from OpenRowSet(BULK N'H:\Курсач\Проект\Images\Studio\Netflix.png', SINGLE_BLOB ) AS Файл; 
select Name from STUDIO;
