CREATE PROCEDURE Authorisation
    @login nvarchar(50),
	@password nvarchar(30),
	@rc int output
	AS BEGIN
		DECLARE @PASSW1 nvarchar(MAX);
		DECLARE @PASSW2 nvarchar(MAX);
	    set @rc = 0;
		SET @PASSW1 =  (select Password FROM USERS where login =@login);  
		SET @PASSW2 =(SELECT HASHBYTES('SHA2_256', @password));
		IF EXISTS(SELECT ID FROM USERS WHERE LOGIN like @login and @PASSW1 like @PASSW2)
		BEGIN
		    set @rc = 1;
		END
	END;

drop procedure Authorisation;

--DECLARE @SalesYTDBySalesPerson int;  
--execute Authorisation
--N'Yum',
--'181813Yu',
--@rc=@SalesYTDBySalesPerson OUTPUT;
--  print @SalesYTDBySalesPerson;