CREATE PROCEDURE UpdateMovie
	@check2 bit,
	@check3 bit,
	@check4 bit,
	@check5 bit,
	@check6 bit,
	@check7 bit,
    @name nvarchar(max),
	@country nvarchar(70)=null,
	@genre nvarchar(30)=null,
	@runningtime nvarchar(20)=null,
	@studio nvarchar(20)=null,
	@plot nvarchar(max)=null,
	@image varbinary(max)=null,
	@trailer varbinary(max)=null,
	@rc int output
	AS BEGIN
	    SET @rc = 1;
	    DECLARE  @country_id varchar(10);
		SET @country_id = (SELECT ID FROM COUNTRY WHERE NAME = @country);
		DECLARE  @genre_id int;
		SET @genre_id = (SELECT ID FROM GENRE WHERE NAME = @genre);
		DECLARE  @studio_id uniqueidentifier;
		SET @studio_id = (SELECT ID FROM studio WHERE NAME = @studio);		
		BEGIN TRY
		IF @check2 = 1
		BEGIN
		    UPDATE MOVIE SET COUNTRY_ID = @country_id WHERE NAME = @name;
		END
		IF @check4 = 1
		BEGIN
		    UPDATE MOVIE SET RUNNING_TIME = @runningtime WHERE NAME = @name;
		END
		IF @check5 = 1
		BEGIN
		    UPDATE MOVIE SET STUDIO_ID = @studio_id WHERE NAME = @name;
		END
		IF @check6 = 1
		BEGIN
		    UPDATE MOVIE SET IMAGE = @image WHERE NAME = @name;
		END
		IF @check7 = 1
		BEGIN
		    UPDATE MOVIE SET TRAILER = @trailer WHERE NAME = @name;
		END
		IF @check3 = 1
		BEGIN
		    UPDATE MOVIE SET PLOT = @plot WHERE NAME = @name;
		END
		END TRY
		BEGIN CATCH
		SET @rc = 0;
	END CATCH
	END;

select * from MOVIE;
DROP PROCEDURE UpdateMovie;