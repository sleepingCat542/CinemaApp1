CREATE PROCEDURE GetActorInfo
@name nvarchar(20) = null,
@surname nvarchar(20) = null
AS BEGIN
    IF (@name IS NOT NULL AND @surname IS NOT NULL)
	    SELECT
	        a.NAME,
			a.SURNAME,
			c.NAME
			FROM ACTOR[a] inner join COUNTRY[c] on a.COUNTRY_ID = c.ID where a.NAME = @name and a.SURNAME = @surname; 
	ELSE IF (@name IS NULL AND @surname IS NULL)
	BEGIN
	    SELECT
	        a.NAME,
			a.SURNAME,
			c.NAME
			FROM ACTOR[a] inner join COUNTRY[c] on a.COUNTRY_ID = c.ID; 
	END
END;

DROP PROCEDURE GetActorInfo;
--exec GetActorInfo @name = 'Том', @surname = 'Харди';
--exec GetActorInfo;
