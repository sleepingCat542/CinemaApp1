use Cinema;

CREATE PROCEDURE Authorisation
    @login nvarchar(50),
	@password nvarchar(max),
	@rc int output
	AS BEGIN
	    set @rc = 0;
		IF EXISTS(SELECT ID FROM USERS WHERE LOGIN like @login and PASSWORD like @password)
		BEGIN
		    set @rc = 1;
		END
	END;

drop procedure Authorization;