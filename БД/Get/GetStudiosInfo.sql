CREATE PROCEDURE GetStudiosInfo
AS BEGIN
	    SELECT
	        s.NAME[Name],
			s.YEAR_OF_FOUNDATION[Year],
			c.NAME[Country],
			s.IMAGE[Image]			
			FROM STUDIO[s] inner join COUNTRY[c] on s.COUNTRY_ID = c.ID; 
END;

DROP PROCEDURE GetStudiosInfo;

--exec GetActorInfo;
