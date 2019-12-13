CREATE PROCEDURE CheckSeats
@row int,
@seat int,
@hall nvarchar(30),
@message nvarchar(50) = NULL output
AS BEGIN
	IF @row>(SELECT HALL.ROWS FROM HALL WHERE NAME=@hall) or @row<0
	set @message='В зале не существует такого ряда';
	else IF @seat>(SELECT HALL.SEATS FROM HALL WHERE NAME=@hall) or @seat<0
	set @message='В зале не существует такого места';
	IF @row=any(SELECT T.ROW FROM TICKETS T INNER JOIN SESSION S ON S.ID=T.SESSION_ID where SEAT=@seat) 
		and @seat=any(SELECT SEAT FROM TICKETS T INNER JOIN SESSION S ON S.ID=T.SESSION_ID where T.ROW=@row) 
	set @message='Это место уже занято';
END;

DROP PROCEDURE CheckSeats;

--declare @mess nvarchar(50);
--exec CheckSeats @row=8, @seat=40, @hall='Большой', @message=@mess output;
--print(@mess);