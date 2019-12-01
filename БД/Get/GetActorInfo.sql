CREATE PROCEDURE GetActorInfo
AS BEGIN
	    SELECT
	        a.NAME[Name],
			a.SURNAME[Surname],
			c.NAME[Country]
			FROM ACTOR[a] inner join COUNTRY[c] on a.COUNTRY_ID = c.ID; 
END;

DROP PROCEDURE GetActorInfo;

--exec GetActorInfo;
