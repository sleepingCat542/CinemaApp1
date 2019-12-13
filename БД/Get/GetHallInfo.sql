CREATE PROCEDURE GetHallInfo
@cinema nvarchar(30)
AS BEGIN
	declare @cinema_id int=(select ID from CINEMA where NAME=@cinema);
	    SELECT NAME	
	        FROM HALL WHERE CINEMA_ID=@cinema_id; 
END;

DROP PROCEDURE GetHallInfo;

exec GetHallInfo;