CREATE PROCEDURE AddGenre
    @name nvarchar(max),
	@genre nvarchar(30),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		DECLARE  @movie_id uniqueidentifier;
		SET @movie_id = (SELECT ID FROM MOVIE WHERE NAME = @name);	 
		DECLARE  @genre_id int;
		SET @genre_id = (SELECT ID FROM GENRE WHERE NAME = @genre);
		BEGIN
				INSERT INTO GENRE_MOVIE(GENRE_ID, MOVIE_ID)
					VALUES (@genre_id, @movie_id);		
				SET @rc = 1;
		END
	END;