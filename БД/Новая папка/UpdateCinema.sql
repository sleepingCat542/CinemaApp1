CREATE PROCEDURE UpdateCinema
	@check2 bit,
	@check3 bit,
	@check4 bit,
	@check5 bit,
	@check6 bit,
    @name nvarchar(30),
	@address nvarchar(max),
	@website nvarchar(max),
	@region nvarchar(30),
	@halls int,
	@ticketoffice nvarchar(30),
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
		    UPDATE CINEMA SET REGION = @region WHERE NAME = @name;
		END
		IF @check4 = 1
		BEGIN
		IF EXISTS (SELECT NAME FROM CINEMA)
		    UPDATE CINEMA SET WEBSITE = @website WHERE NAME = @name;
		END
		IF @check5 = 1
		BEGIN
		IF EXISTS (SELECT NAME FROM CINEMA)
		    UPDATE CINEMA SET TICKET_OFFICE = @ticketoffice WHERE NAME = @name;
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
exec InsertCinema @name = 'Центральный', @address = 'г.Минск, пр-т Независимости, 13', @website = 'https://vk.com/kino_centralny', @region = 'Центральный', @halls = 1,@ticketoffice = 'ПН-ВС с 11.30 до 21.30', @rc = 1;
