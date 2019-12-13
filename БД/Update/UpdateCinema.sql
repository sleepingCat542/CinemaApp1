CREATE PROCEDURE UpdateCinema
	@check2 bit,
	@check3 bit,
	@check4 bit,
	@check5 bit,
	@check6 bit,
    @name nvarchar(30),
	@address nvarchar(100),
	@website nvarchar(100),
	@city nvarchar(30),
	@halls int,
	@timetable nvarchar(200),
	@rc bit output
	AS BEGIN
	    SET @rc = 1;
		BEGIN TRY
		IF @check2 = 1
		BEGIN
		IF EXISTS (SELECT NAME FROM CINEMA)
		    UPDATE CINEMA SET ADDRESS = @address WHERE NAME = @name;
		END
		IF @check3 = 1
		BEGIN
		IF EXISTS (SELECT NAME FROM CINEMA)
		    UPDATE CINEMA SET CITY = @city WHERE NAME = @name;
		END
		IF @check4 = 1
		BEGIN
		IF EXISTS (SELECT NAME FROM CINEMA)
		    UPDATE CINEMA SET WEBSITE = @website WHERE NAME = @name;
		END
		IF @check5 = 1
		BEGIN
		IF EXISTS (SELECT NAME FROM CINEMA)
		    UPDATE CINEMA SET TIMETABLE = @timetable WHERE NAME = @name;
		END
		IF @check6 = 1
		BEGIN
		IF EXISTS (SELECT NAME FROM CINEMA)
		    UPDATE CINEMA SET NUMBER_OF_HALLS = @halls WHERE NAME = @name;
		END
		END TRY
		BEGIN CATCH
		SET @rc = 0;
	END CATCH
	END;
DROP PROCEDURE UpdateCinema;
select * from CINEMA;

