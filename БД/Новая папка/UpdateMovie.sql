CREATE PROCEDURE UpdateMovie
 @check1 bit,
	@check2 bit,
	@check3 bit,
	@check4 bit,
	@check5 bit,
	@check6 bit,
	@check7 bit,
	@check8 bit,
	@check9 bit,
    @name nvarchar(max),
	@release date,
	@country nvarchar(70),
	@genre nvarchar(30),
	@runningtime nvarchar(20),
	@directorname nvarchar(20),
	@directorsurname nvarchar(20),
	@screenplay nvarchar(30),
	@composer nvarchar(30),
	@actorname nvarchar(20),
	@actorsurname nvarchar(20),
	@plot nvarchar(max),
	@rc int output
	AS BEGIN
	    SET @rc = 1;
	    DECLARE  @country_id varchar(10);
		SET @country_id = (SELECT ID FROM COUNTRY WHERE NAME = @country);
		DECLARE  @genre_id int;
		SET @genre_id = (SELECT ID FROM GENRE WHERE NAME = @genre);
		DECLARE  @director_id uniqueidentifier;
		SET @director_id = (SELECT ID FROM DIRECTOR WHERE NAME = @directorname or SURNAME = @directorsurname);
		DECLARE  @actor_id uniqueidentifier;
		SET @actor_id = (SELECT ID FROM ACTOR WHERE NAME = @actorname or SURNAME = @actorsurname);
		BEGIN TRY
		IF @check1 = 1
		BEGIN
		    UPDATE MOVIE SET RELEASE = @release WHERE NAME = @name;
		END
		IF @check2 = 1
		BEGIN
		    UPDATE MOVIE SET COUNTRY_ID = @country_id WHERE NAME = @name;
		END
		IF @check3 = 1
		BEGIN
		    UPDATE MOVIE SET GENRE_ID = @genre_id WHERE NAME = @name;
		END
		IF @check4 = 1
		BEGIN
		    UPDATE MOVIE SET RUNNING_TIME = @runningtime WHERE NAME = @name;
		END
		IF @check5 = 1
		BEGIN
		    UPDATE MOVIE SET DIRECTOR_ID = @director_id WHERE NAME = @name;
		END
		IF @check6 = 1
		BEGIN
		    UPDATE MOVIE SET SCREENPLAY = @screenplay WHERE NAME = @name;
		END
		IF @check7 = 1
		BEGIN
		    UPDATE MOVIE SET COMPOSER = @composer WHERE NAME = @name;
		END
		IF @check8 = 1
		BEGIN
		    UPDATE MOVIE SET ACTOR_ID = @actor_id WHERE NAME = @name;
		END
		IF @check9 = 1
		BEGIN
		    UPDATE MOVIE SET PLOT = @plot WHERE NAME = @name;
		END
		END TRY
		BEGIN CATCH
		SET @rc = 0;
	END CATCH
	END;

select * from MOVIE;
DROP PROCEDURE InsertMovie;