exec master.dbo.sp_configure 'show advanced options', 1;
RECONFIGURE;
exec master.dbo.sp_configure 'xp_cmdshell', 1;
RECONFIGURE;
GO
CREATE PROCEDURE ExportToXML
	@path nvarchar(256),
	@log nvarchar(50),
	@r int,
	@s int,
	@u nvarchar(20),
	@rc bit output
	AS BEGIN
	set @rc = 0;
	BEGIN TRANSACTION
	    declare @sql nvarchar(500);
		SET @sql = 'bcp "Exec ExportIntoXML @login='+@log+', @row='+cast(@r as nvarchar(3))+
		', @seat='+cast(@s as nvarchar(3))+', @unik='+@u+'" queryout "'+@path+'" -S .\SQLEXPRESS -E -dCinema -w -C1251 -r -T';
		EXEC xp_cmdshell @sql;
		set @rc = 1;
	COMMIT;
END;
DROP PROCEDURE ExportToXML;
exec ExportToXML  @rc = 1, @log='User1', @r=8, @s=8, @u='AVTb', @path='H:\Курсач\Проект\Export.xml';


CREATE PROCEDURE ExportIntoXML
	@login nvarchar(50),
	@row nvarchar(3),
	@seat nvarchar(3),
	@unik nvarchar(20)
	AS BEGIN
	SELECT  M.NAME[Name], C.NAME[Cinema], H.NAME[Hall], S.DATE[Date], TIME[Time], ROW, SEAT,  PRICE, UNICK_TICKET[Unick] 
	FROM USERS U INNER JOIN 
	PURCHASE P ON U.ID=P.USER_ID INNER JOIN
	TICKETS T ON P.ID=T.PURCHASE_ID INNER JOIN 
	SESSION S ON S.ID=T.SESSION_ID INNER JOIN 
	MOVIE M ON M.ID = S.MOVIE_ID INNER JOIN 
	HALL H ON H.ID = S.HALL_ID INNER JOIN 
	CINEMA C ON C.ID = H.CINEMA_ID 
	where U.Login=@login AND UNICK_TICKET=@unik AND SEAT=cast(@seat as int) and ROW=cast(@row as int) FOR XML PATH('Ticket'), ROOT('Root');
	END;
DROP PROCEDURE ExportIntoXML;

select * from tickets;
select * from PURCHASE;