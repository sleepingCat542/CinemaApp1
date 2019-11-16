CREATE PROCEDURE GetCinemaInfo
@name nvarchar(30) = null
AS BEGIN
	IF (@name IS NOT NULL)
    SELECT NAME[��������], ADDRESS[�����], WEBSITE[����], REGION[�����], NUMBER_OF_HALLS[���������� �����], TICKET_OFFICE[����� ������ �������� ����]
	FROM CINEMA WHERE NAME = @name;
	ELSE IF (@name IS NULL)
	BEGIN
	SELECT NAME[��������], ADDRESS[�����], WEBSITE[����], REGION[�����], NUMBER_OF_HALLS[���������� �����], TICKET_OFFICE[����� ������ �������� ����] FROM CINEMA;
	END
END;

DROP PROCEDURE GetCinemaInfo;

EXEC GetCinemaInfo @name = '�����������';
EXEC GetCinemaInfo;