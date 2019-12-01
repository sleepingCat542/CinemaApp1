CREATE PROCEDURE AddActor
    @name nvarchar(20),
	@surname nvarchar(30),
	@nameFilm nvarchar(max),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		DECLARE  @actor_id uniqueidentifier;
		SET @actor_id = (SELECT ID FROM ACTOR WHERE NAME = @name AND SURNAME=@surname);
		DECLARE  @movie_id uniqueidentifier;
		SET @movie_id = (SELECT ID FROM MOVIE WHERE NAME = @nameFilm);		
		BEGIN
				INSERT INTO ACTOR_MOVIE(ACTOR_ID, MOVIE_ID)
					VALUES (@actor_id, @movie_id);			
				SET @rc = 1;
		END
	END;

	DROP PROCEDURE AddActor;

	declare @rrc int=0;
	exec AddActor @name='������', @surname='��������', @nameFilm='��������', @rc=@rrc output;
	exec AddActor @name = N'����', @surname = N'�������', @nameFilm='��������', @rc=@rrc output;
	exec AddActor @name = N'�������', @surname = N'�����', @nameFilm='��������', @rc=@rrc output;
	exec AddActor @name = N'����������', @surname = N'����������', @nameFilm='��������', @rc=@rrc output;
	exec AddActor @name = N'�����', @surname = N'�����', @nameFilm='����� ���', @rc=@rrc output;
	exec AddActor @name = N'���', @surname = N'�����', @nameFilm='����� ���', @rc=@rrc output;
	exec AddActor @name = N'�����', @surname = N'����',  @nameFilm='����� ���', @rc=@rrc output;
	exec AddActor @name = N'������', @surname = N'�������', @nameFilm='����� ���', @rc=@rrc output;
	exec AddActor @name = N'��������', @surname = N'����', @nameFilm='Ford ������ Ferrari', @rc=@rrc output;
	exec AddActor @name = N'����', @surname = N'������', @nameFilm='Ford ������ Ferrari', @rc=@rrc output;
	exec AddActor @name = N'�������', @surname = N'����', @nameFilm='Ford ������ Ferrari', @rc=@rrc output;
	exec AddActor @name = N'����', @surname = N'�����', @nameFilm='Ford ������ Ferrari', @rc=@rrc output;
	exec AddActor @name = N'�����', @surname = N'������', @nameFilm='������� ����', @rc=@rrc output;
	exec AddActor @name = N'����', @surname = N'������', @nameFilm='������� ����', @rc=@rrc output;
	exec AddActor @name = N'���', @surname = N'���������', @nameFilm='������� ����', @rc=@rrc output;
	exec AddActor @name = N'������', @surname = N'����', @nameFilm='������� ����', @rc=@rrc output;