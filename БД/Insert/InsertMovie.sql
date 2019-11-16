CREATE PROCEDURE InsertMovie
    @name nvarchar(max),
	@release date,
	@country nvarchar(70),
	@genre nvarchar(30),
	@runningtime int,
	@studioname nvarchar(20),
	--@actorname nvarchar(20),
	--@actorsurname nvarchar(20),
	@plot nvarchar(max),
	@image varbinary(max),
	@video varbinary(max),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
	    DECLARE  @country_id varchar(10);
		SET @country_id = (SELECT ID FROM COUNTRY WHERE NAME = @country);
		DECLARE  @genre_id int;
		SET @genre_id = (SELECT ID FROM GENRE WHERE NAME = @genre);
		DECLARE  @studio_id uniqueidentifier;
		SET @studio_id = (SELECT ID FROM STUDIO WHERE NAME = @studioname);
		--DECLARE  @actor_id uniqueidentifier;
		--SET @actor_id = (SELECT ID FROM ACTOR WHERE NAME = @actorname or SURNAME = @actorsurname);
		DECLARE @movie_id uniqueidentifier;
		BEGIN
			BEGIN TRAN
				INSERT INTO MOVIE(NAME, RELEASE, COUNTRY_ID, RUNNING_TIME, DIRECTOR_ID, PLOT, IMAGE, TRAILER)
					VALUES (@name, @release, @country_id, @runningtime, @studio_id, @plot, @image, @video);
				SET @movie_id=SCOPE_IDENTITY();
				INSERT INTO GENRE_MOVIE(GENRE_ID, MOVIE_ID)
					VALUES (@genre_id, @movie_id);			
				SET @rc = 1;
			COMMIT TRAN;
			IF @@TRANCOUNT>0 ROLLBACK TRAN;
		END
	END;


--insert into MOVIE(NAME, RELEASE, PLOT) values ('Веном', '12.12.2018', 'Что если в один прекрасный день в тебя вселяется существо-симбиот, которое наделяет тебя сверхчеловеческими способностями? Вот только Веном - симбиот совсем недобрый, и договориться с ним невозможно. Хотя нужно ли договариваться?.. Ведь в какой-то момент ты понимаешь, что быть плохим вовсе не так уж и плохо. Так даже веселее. В мире и так слишком много супергероев! Мы - Веном!');
--insert into MOVIE(NAME, RELEASE, PLOT) values ('Дэдпул', '21.01.2016', 'Уэйд Уилсон — наёмник. Будучи побочным продуктом программы вооружённых сил под названием «Оружие X», Уилсон приобрёл невероятную силу, проворство и способность к исцелению. Но страшной ценой: его клеточная структура постоянно меняется, а здравомыслие сомнительно. Всё, чего Уилсон хочет, — это держаться на плаву в социальной выгребной яме. Но течение в ней слишком быстрое.');
--insert into MOVIE(NAME, RELEASE, PLOT) values ('Хэнкок', '16.06.2008', 'Есть герои, есть супергерои, и есть Хэнкок. Обладание сверхспособностями предполагает ответственность, все знают это — кроме него. За любую задачу он берётся с душой и лучшими намерениями, спасает жизни людей — ценой нечеловеческих разрушений и неисчислимого ущерба. В конце концов, терпение общественности подходит к концу: люди благодарны своему местному герою, но иногда не понимают, чем заслужили такое наказание.');

select * from MOVIE;

DROP PROCEDURE InsertMovie;


select * from movie;