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
	exec AddActor @name='Ксения', @surname='Кутепова', @nameFilm='Аванпост', @rc=@rrc output;
	exec AddActor @name = N'Петр', @surname = N'Федоров', @nameFilm='Аванпост', @rc=@rrc output;
	exec AddActor @name = N'Алексей', @surname = N'Чадов', @nameFilm='Аванпост', @rc=@rrc output;
	exec AddActor @name = N'Константин', @surname = N'Лавроненко', @nameFilm='Аванпост', @rc=@rrc output;
	exec AddActor @name = N'Эмили', @surname = N'Бичем', @nameFilm='Малыш Джо', @rc=@rrc output;
	exec AddActor @name = N'Бен', @surname = N'Уишоу', @nameFilm='Малыш Джо', @rc=@rrc output;
	exec AddActor @name = N'Керри', @surname = N'Фокс',  @nameFilm='Малыш Джо', @rc=@rrc output;
	exec AddActor @name = N'Феникс', @surname = N'Броссар', @nameFilm='Малыш Джо', @rc=@rrc output;
	exec AddActor @name = N'Кристиан', @surname = N'Бэйл', @nameFilm='Ford против Ferrari', @rc=@rrc output;
	exec AddActor @name = N'Мэтт', @surname = N'Дэймон', @nameFilm='Ford против Ferrari', @rc=@rrc output;
	exec AddActor @name = N'Катрина', @surname = N'Балф', @nameFilm='Ford против Ferrari', @rc=@rrc output;
	exec AddActor @name = N'Джош', @surname = N'Лукас', @nameFilm='Ford против Ferrari', @rc=@rrc output;
	exec AddActor @name = N'Хелен', @surname = N'Миррен', @nameFilm='Хороший лжец', @rc=@rrc output;
	exec AddActor @name = N'Джим', @surname = N'Картер', @nameFilm='Хороший лжец', @rc=@rrc output;
	exec AddActor @name = N'Иэн', @surname = N'Маккеллен', @nameFilm='Хороший лжец', @rc=@rrc output;
	exec AddActor @name = N'Рассел', @surname = N'Тови', @nameFilm='Хороший лжец', @rc=@rrc output;