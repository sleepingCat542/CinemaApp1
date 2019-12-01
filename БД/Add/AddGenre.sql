CREATE PROCEDURE AddGenre
    @nameGenre nvarchar(30),
	@nameFilm nvarchar(max),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		DECLARE  @genre_id int;
		SET @genre_id = (SELECT ID FROM GENRE WHERE NAME = @nameGenre);
		DECLARE  @movie_id uniqueidentifier;
		SET @movie_id = (SELECT ID FROM MOVIE WHERE NAME = @nameFilm);		
		BEGIN
				INSERT INTO GENRE_MOVIE(GENRE_ID, MOVIE_ID)
					VALUES (@genre_id, @movie_id);			
				SET @rc = 1;
		END
	END;

	drop PROCEDURE AddGenre;

	
	exec AddGenre @nameGenre='Боевик', @nameFilm='Аванпост', @rc=@rrc output;
	exec AddGenre @nameGenre='Триллер', @nameFilm='Аванпост', @rc=@rrc output;	
	exec AddGenre @nameGenre='Драма', @nameFilm='Ford против Ferrari', @rc=@rrc output;
	exec AddGenre @nameGenre='Драма', @nameFilm='Малыш Джо', @rc=@rrc output;
	declare @rrc int=0;
	exec AddGenre @nameGenre='Драма', @nameFilm='Хороший Лжец', @rc=@rrc output;