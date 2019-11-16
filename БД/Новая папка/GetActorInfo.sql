CREATE PROCEDURE GetActorInfo
@name nvarchar(20) = null,
@surname nvarchar(20) = null
AS BEGIN
    IF (@name IS NOT NULL AND @surname IS NOT NULL)
	    SELECT
	        a.NAME[���],
			a.SURNAME[�������],
			b.NAME[������], 
			a.AGE[�������]
			FROM ACTOR[a] inner join COUNTRY[b] on a.COUNTRY_ID = b.ID where a.NAME = @name and a.SURNAME = @surname; 
	ELSE IF (@name IS NULL AND @surname IS NULL)
	BEGIN
	    SELECT
	        a.NAME[���],
			a.SURNAME[�������],
			b.NAME[������], 
			a.AGE[�������]
			FROM ACTOR[a] inner join COUNTRY[b] on a.COUNTRY_ID = b.ID; 
	END
END;
DROP PROCEDURE GetActorInfo;
exec GetActorInfo @name = '���', @surname = '�����';
exec GetActorInfo;
SELECT * FROM ACTOR;
insert into GENRE(NAME) values ('�������������� �����');
select * from GENRE;

select * from MOVIE;