CREATE PROCEDURE GetCinemaInfo
AS BEGIN
	    SELECT
		CITY[City],
		NAME[Name],
		ADDRESS[Address],
		WEBSITE[Website],
		NUMBER_OF_HALLS[Number],
		TIMETABLE[Timetable]		
	        FROM CINEMA; 
END;

DROP PROCEDURE GetCinemaInfo;

exec GetCinemaInfo;