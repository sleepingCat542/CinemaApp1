CREATE PROCEDURE ImportFromXML
@path nvarchar(256),
@rc bit output
AS BEGIN 
    SET @rc = 0; 
	    SET NOCOUNT ON;
		SET XACT_ABORT ON;
        BEGIN TRAN
		    declare @result table(x xml);
			declare @sql nvarchar(300);
			set @sql = 'SELECT CAST(REPLACE(CAST(x AS VARCHAR(MAX)), ''encoding="utf-16"'', ''encoding="utf-8"'') AS XML)
					    FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)';
			INSERT INTO @result EXEC(@sql);
			declare @xml XML;
			set @xml = (SELECT TOP 1 x FROM @result);

			declare @hall_id int=(select id from HALL where NAME=(select C3.value('Hall[1]', 'nvarChar(30)') AS TICKET_OFFICE
				FROM @xml.nodes('Root/Ticket') AS T3(C3)));
			declare @cinema_id int=(select id from CINEMA where NAME=(select C3.value('Cinema[1]', 'nvarChar(30)') AS TICKET_OFFICE
				FROM @xml.nodes('Root/Ticket') AS T3(C3)));
			declare @movie_id uniqueidentifier=(select id from MOVIE where NAME=(select C3.value('Name[1]', 'nvarChar(max)') AS TICKET_OFFICE
				FROM @xml.nodes('Root/Ticket') AS T3(C3)));
			declare @session_id int=(select id from SESSION where MOVIE_ID=@movie_id AND HALL_ID=@hall_id AND 
			DATE=(select C3.value('Date[1]', 'date') AS TICKET_OFFICE
				FROM @xml.nodes('Root/Ticket') AS T3(C3)) and TIME=(select C3.value('Time[1]', 'time') AS TICKET_OFFICE
				FROM @xml.nodes('Root/Ticket') AS T3(C3)));
			declare @purchase_id int=(select id from PURCHASE where UNICK_TICKET=(select C3.value('Unick[1]', 'nvarChar(20)') AS TICKET_OFFICE
				FROM @xml.nodes('Root/Ticket') AS T3(C3)));


			INSERT INTO TICKETS(SESSION_ID, PURCHASE_ID, ROW, SEAT)
			    SELECT 
				    @session_id, @purchase_id,
					C3.value('ROW[1]', 'int') AS ROW,
					C3.value('SEAT[1]', 'int') AS SEAT
				FROM @xml.nodes('Root/Ticket') AS T3(C3);
				   SET @rc = 1; 
		COMMIT;
END;


--drop procedure ImportFromXML;


--exec ImportFromXML
--	@path='H:\Курсач\Проект\Export.xml',
--	@rc=1;

--	select * from CINEMA;

select id from SESSION where MOVIE_ID=@movie_id AND HALL_ID=@hall_id AND 
			DATE=(select C3.value('Date[1]', 'date'