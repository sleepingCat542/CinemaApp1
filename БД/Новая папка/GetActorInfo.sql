CREATE PROCEDURE GetActorInfo
@name nvarchar(20) = null,
@surname nvarchar(20) = null
AS BEGIN
    IF (@name IS NOT NULL AND @surname IS NOT NULL)
	    SELECT
	        a.NAME[Имя],
			a.SURNAME[Фамилия],
			b.NAME[Страна], 
			a.AGE[Возраст]
			FROM ACTOR[a] inner join COUNTRY[b] on a.COUNTRY_ID = b.ID where a.NAME = @name and a.SURNAME = @surname; 
	ELSE IF (@name IS NULL AND @surname IS NULL)
	BEGIN
	    SELECT
	        a.NAME[Имя],
			a.SURNAME[Фамилия],
			b.NAME[Страна], 
			a.AGE[Возраст]
			FROM ACTOR[a] inner join COUNTRY[b] on a.COUNTRY_ID = b.ID; 
	END
END;
DROP PROCEDURE GetActorInfo;
exec GetActorInfo @name = 'Том', @surname = 'Харди';
exec GetActorInfo;
SELECT * FROM ACTOR;
insert into GENRE(NAME) values ('Супергеройский фильм');
select * from GENRE;

select * from MOVIE;