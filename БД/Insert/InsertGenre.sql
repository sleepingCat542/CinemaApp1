--insert Genre
CREATE PROCEDURE InsertGenre
    @name nvarchar(30)
	as begin
	    INSERT INTO GENRE(NAME)
		    VALUES (@name);
	end;

exec InsertGenre @name='Aниме';
exec InsertGenre @name='Биография';
exec InsertGenre @name='Боевик';
exec InsertGenre @name='Вестерн';
exec InsertGenre @name='Военный';
exec InsertGenre @name='Детектив';
exec InsertGenre @name='Детский';
exec InsertGenre @name='Документальный';
exec InsertGenre @name='Драма';
exec InsertGenre @name='Исторический';
exec InsertGenre @name='Комедия';
exec InsertGenre @name='Криминал';
exec InsertGenre @name='Мелодрама';
exec InsertGenre @name='Мистика';
exec InsertGenre @name='Музыка';
exec InsertGenre @name='Мультфильм';
exec InsertGenre @name='Мюзикл';
exec InsertGenre @name='Научный';
exec InsertGenre @name='Приключения';
exec InsertGenre @name='Семейный';
exec InsertGenre @name='Спорт';
exec InsertGenre @name='Ток-шоу';
exec InsertGenre @name='Триллер';
exec InsertGenre @name='Ужасы';
exec InsertGenre @name='Фантастика';
exec InsertGenre @name='Фильм-нуар';
exec InsertGenre @name='Фэнтези';

DELETE GENRE;
SELECT * FROM GENRE;
DROP PROCEDURE InsertGenre;