CREATE PROCEDURE Registration
    @login nvarchar(50),
	@password nvarchar(max),
	@email nvarchar(50),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		BEGIN
		    INSERT INTO USERS (LOGIN, PASSWORD, EMAIL)
				VALUES (@login, @password, @email);
		    SET @rc = 1;
		END
    END;

drop procedure Registration;

select * from USERS;
delete from USERS;