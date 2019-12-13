CREATE PROCEDURE GetTicketInfo
@login nvarchar(50)
AS BEGIN
	declare @user_id uniqueidentifier=(select id from users where login=@login);
  SELECT  M.NAME[Name], C.NAME[Cinema], H.NAME[Hall], S.DATE[Date], TIME[Time], ROW[Row], SEAT[Seat],  PRICE[Price], UNICK_TICKET[Unick]  FROM USERS U INNER JOIN PURCHASE P ON U.ID=P.USER_ID INNER JOIN
  TICKETS T ON P.ID=T.PURCHASE_ID INNER JOIN SESSION S ON S.ID=T.SESSION_ID INNER JOIN MOVIE M ON M.ID = S.MOVIE_ID 
	INNER JOIN HALL H ON H.ID = S.HALL_ID INNER JOIN CINEMA C ON C.ID = H.CINEMA_ID where P.USER_ID=@user_id;
END;

DROP PROCEDURE GetTicketInfo;

GetTicketInfo @login='User1';