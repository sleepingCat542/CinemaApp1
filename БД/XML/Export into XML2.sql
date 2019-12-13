exec master.dbo.sp_configure 'show advanced options', 1;
RECONFIGURE;
exec master.dbo.sp_configure 'xp_cmdshell', 1;
RECONFIGURE;
GO
CREATE PROCEDURE ExportToXML
    @path nvarchar(256),
	@login nvarchar(50),
	@rc bit output
	AS BEGIN
	set @rc = 0;
	BEGIN TRANSACTION
	    declare @sql nvarchar(500);
		SET @sql = 'bcp.exe "SELECT [ID], [NAME], [ADDRESS], [WEBSITE] FROM CINEMA FOR XML PATH(''List''), ROOT(''Root'') " queryout "'+@path+'" -d Cinema -w';
	--	SET @sql ='bcp "SELECT  M.NAME[Name], C.NAME[Cinema], H.NAME[Hall], S.DATE[Date], TIME[Time], ROW, SEAT,  PRICE, UNICK_TICKET[Unick]  FROM USERS U INNER JOIN PURCHASE P ON U.ID=P.USER_ID INNER JOIN
 -- TICKETS T ON P.ID=T.PURCHASE_ID INNER JOIN SESSION S ON S.ID=T.SESSION_ID INNER JOIN MOVIE M ON M.ID = S.MOVIE_ID 
	--INNER JOIN HALL H ON H.ID = S.HALL_ID INNER JOIN CINEMA C ON C.ID = H.CINEMA_ID FOR XML PATH(''Ticket''), ROOT(''Root'') " queryout "'+@path+'" -d Cinema -w -T';
		EXEC xp_cmdshell @sql;
		set @rc = 1;
	COMMIT;
END;
DROP PROCEDURE ExportToXML;
exec ExportToXML @path = 'H:\Курсач\Проект\Export.xml', @rc = 1, @login='User1';



