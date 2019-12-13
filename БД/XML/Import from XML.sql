CREATE PROCEDURE ImportFromXML
@path nvarchar(256),
@rc bit output
AS BEGIN 
  SET @rc = 0; 
	 --   SET NOCOUNT ON;
		--SET XACT_ABORT ON;
  --      BEGIN TRAN
		--    declare @result table(x xml);
		--	declare @sql nvarchar(300);
		--	set @sql = 'SELECT CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
		--			    FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)';
		--	INSERT INTO @result EXEC(@sql);
		--	declare @xml XML;
		--	set @xml = (SELECT TOP 1 x FROM @result);

		--	create view TicketsView as
		--	SELECT 
		--		    C3.value('name[1]', 'nvarChar(30)') As NAME,
		--			C3.value('address[1]', 'nvarChar(max)') AS ADDRESS,
		--			C3.value('website[1]', 'nvarChar(max)') AS WEBSITE,
		--			C3.value('region[1]', 'nvarChar(30)') AS REGION,
		--			C3.value('number_of_halls[1]', 'int') AS NUMBER_OF_HALLS,
		--			C3.value('ticket_office[1]', 'nvarChar(30)') AS TICKET_OFFICE
		--		FROM @xml.nodes('dataroot/cinema') AS T3(C3);

		--	exec InsertTicket @movie =TicketsView.Name,  @cinema = 'Аврора', @hall = 'Большой', @date = '29.11.2019', @time = '13:30', @pass = 'AVTb',
		--		@row1 = 8, @seat1 = 8, @row2 = 8, @seat2 = 9, @rc = 0;

			    
		--		   SET @rc = 1; 
		--COMMIT;
END;

drop procedure ImportFromXML;
exec ImportFromXML
	@path='D:\CINEMA\COURSE\Import_Cinema_XML.xml',
	@rc=1;
	select * from CINEMA;