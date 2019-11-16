CREATE PROCEDURE GetCinemaInfo
@name nvarchar(30) = null
AS BEGIN
	IF (@name IS NOT NULL)
    SELECT NAME[Название], ADDRESS[Адрес], WEBSITE[Сайт], REGION[Район], NUMBER_OF_HALLS[Количество залов], TICKET_OFFICE[Время работы билетных касс]
	FROM CINEMA WHERE NAME = @name;
	ELSE IF (@name IS NULL)
	BEGIN
	SELECT NAME[Название], ADDRESS[Адрес], WEBSITE[Сайт], REGION[Район], NUMBER_OF_HALLS[Количество залов], TICKET_OFFICE[Время работы билетных касс] FROM CINEMA;
	END
END;

DROP PROCEDURE GetCinemaInfo;

EXEC GetCinemaInfo @name = 'Центральный';
EXEC GetCinemaInfo;