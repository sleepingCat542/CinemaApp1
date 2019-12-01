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


exec InsertStudio @name = 'Netflix',  @country = '���', @year = 1997, @rc = 1;
exec InsertStudio @name = 'Netflix',  @country = '���', @year = 1997, @rc = 1;
exec InsertStudio @name = 'Netflix',  @country = '���', @year = 1997, @rc = 1;
exec InsertStudio @name = 'Netflix',  @country = '���', @year = 1997, @rc = 1;

declare @countryId varchar(10)= (SELECT ID FROM COUNTRY WHERE NAME = '���');
INSERT INTO STUDIO (NAME, COUNTRY_ID, YEAR_OF_FOUNDATION, IMAGE) select 'Netflix', @countryId, 1997,  BulkColumn
from OpenRowSet(BULK N'H:\������\������\Images\Studio\Netflix.png', SINGLE_BLOB ) AS ����; 
declare @countryId varchar(10)= (SELECT ID FROM COUNTRY WHERE NAME = '������');
INSERT INTO STUDIO (NAME, COUNTRY_ID, YEAR_OF_FOUNDATION, IMAGE) select '��3', @countryId, 1993,  BulkColumn
from OpenRowSet(BULK N'H:\������\������\Images\Studio\TV3.png', SINGLE_BLOB ) AS ����; 
declare @countryId varchar(10)= (SELECT ID FROM COUNTRY WHERE NAME = '�������');
INSERT INTO STUDIO (NAME, COUNTRY_ID, YEAR_OF_FOUNDATION, IMAGE) select 'Coop99', @countryId, 1999,  BulkColumn
from OpenRowSet(BULK N'H:\������\������\Images\Studio\partner_coop.png', SINGLE_BLOB ) AS ����; 
declare @countryId varchar(10)= (SELECT ID FROM COUNTRY WHERE NAME = '���');
INSERT INTO STUDIO (NAME, COUNTRY_ID, YEAR_OF_FOUNDATION, IMAGE) select '20th Century Fox', @countryId, 1935,  BulkColumn
from OpenRowSet(BULK N'H:\������\������\Images\Studio\media-20th-century-fox.png', SINGLE_BLOB ) AS ����; 
declare @countryId varchar(10)= (SELECT ID FROM COUNTRY WHERE NAME = '���');
INSERT INTO STUDIO (NAME, COUNTRY_ID, YEAR_OF_FOUNDATION, IMAGE) select 'New Line Cinema', @countryId, 1967,  BulkColumn
from OpenRowSet(BULK N'H:\������\������\Images\Studio\520px-New_Line_Cinema.svg.png', SINGLE_BLOB ) AS ����; 

select Name from STUDIO;
