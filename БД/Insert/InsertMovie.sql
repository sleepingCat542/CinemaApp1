CREATE PROCEDURE InsertMovie
    @name nvarchar(max),
	@release date,
	@country nvarchar(70),
	@genre nvarchar(30),
	@runningtime nvarchar(20),
	@directorname nvarchar(20),
	@directorsurname nvarchar(20),
	@screenplay nvarchar(30),
	@composer nvarchar(30),
	@actorname nvarchar(20),
	@actorsurname nvarchar(20),
	@plot nvarchar(max),
	@image varbinary(max),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
	    DECLARE  @country_id varchar(10);
		SET @country_id = (SELECT ID FROM COUNTRY WHERE NAME = @country);
		DECLARE  @genre_id int;
		SET @genre_id = (SELECT ID FROM GENRE WHERE NAME = @genre);
		DECLARE  @director_id uniqueidentifier;
		SET @director_id = (SELECT ID FROM DIRECTOR WHERE NAME = @directorname or SURNAME = @directorsurname);
		DECLARE  @actor_id uniqueidentifier;
		SET @actor_id = (SELECT ID FROM ACTOR WHERE NAME = @actorname or SURNAME = @actorsurname);
		
		BEGIN
		    INSERT INTO MOVIE(NAME, RELEASE, COUNTRY_ID, GENRE_ID, RUNNING_TIME, DIRECTOR_ID, SCREENPLAY, COMPOSER, ACTOR_ID, PLOT, IMAGE)
			    VALUES (@name, @release, @country_id, @genre_id, @runningtime,
		             @director_id, @screenplay, @composer, @actor_id, @plot, @image);
			SET @rc = 1;
		END
	END;
insert into MOVIE(NAME, RELEASE, PLOT) values ('Веном', '12.12.2018', 'Что если в один прекрасный день в тебя вселяется существо-симбиот, которое наделяет тебя сверхчеловеческими способностями? Вот только Веном - симбиот совсем недобрый, и договориться с ним невозможно. Хотя нужно ли договариваться?.. Ведь в какой-то момент ты понимаешь, что быть плохим вовсе не так уж и плохо. Так даже веселее. В мире и так слишком много супергероев! Мы - Веном!');
insert into MOVIE(NAME, RELEASE, PLOT) values ('Дэдпул', '21.01.2016', 'Уэйд Уилсон — наёмник. Будучи побочным продуктом программы вооружённых сил под названием «Оружие X», Уилсон приобрёл невероятную силу, проворство и способность к исцелению. Но страшной ценой: его клеточная структура постоянно меняется, а здравомыслие сомнительно. Всё, чего Уилсон хочет, — это держаться на плаву в социальной выгребной яме. Но течение в ней слишком быстрое.');
insert into MOVIE(NAME, RELEASE, PLOT) values ('Хэнкок', '16.06.2008', 'Есть герои, есть супергерои, и есть Хэнкок. Обладание сверхспособностями предполагает ответственность, все знают это — кроме него. За любую задачу он берётся с душой и лучшими намерениями, спасает жизни людей — ценой нечеловеческих разрушений и неисчислимого ущерба. В конце концов, терпение общественности подходит к концу: люди благодарны своему местному герою, но иногда не понимают, чем заслужили такое наказание.');

select * from MOVIE;
delete MOVIE WHERE NAME = 'Веном';
DROP PROCEDURE InsertMovie;


select * from movie;