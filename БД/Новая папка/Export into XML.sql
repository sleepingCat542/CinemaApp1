exec master.dbo.sp_configure 'show advanced options', 1;
RECONFIGURE;
exec master.dbo.sp_configure 'xp_cmdshell', 1;
RECONFIGURE;
GO
CREATE PROCEDURE ExportToXML
    @path nvarchar(256),
	@rc bit output
	AS BEGIN
	set @rc = 0;
	BEGIN TRANSACTION
	    declare @sql nvarchar(500);
		SET @sql = 'bcp.exe "SELECT [ID], [NAME], [ADDRESS], [WEBSITE], [REGION], [NUMBER_OF_HALLS], [TICKET_OFFICE] FROM CINEMA FOR XML PATH(''List''), ROOT(''Root'') " queryout "'+@path+'" -d Cinema -w -T';
		EXEC xp_cmdshell @sql;
		set @rc = 1;
	COMMIT;
END;
DROP PROCEDURE ExportToXML;
exec ExportToXML @path = 'C:\Users\Вероника\Desktop\Cinema\Cinema_XML.xml', @rc = 1;
\Cinema_XML.xml', @rc = 1;
SELECT * FROM CINEMA;
DELETE CINEMA WHERE NAME = 'Беларусь';