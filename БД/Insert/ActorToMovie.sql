CREATE PROCEDURE AddActor
    @name nvarchar(max),
	@actorname nvarchar(20),
	@actorsurname nvarchar(30),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		DECLARE  @movie_id uniqueidentifier;
		SET @movie_id = (SELECT ID FROM MOVIE WHERE NAME = @name);	 
		DECLARE  @actor_id uniqueidentifier;
		SET @actor_id = (SELECT ID FROM ACTOR WHERE NAME = @actorname or SURNAME = @actorsurname);
		BEGIN
				INSERT INTO ACTOR_MOVIE(ACTOR_ID, MOVIE_ID)
					VALUES (@actor_id, @movie_id);		
				SET @rc = 1;
		END
	END;