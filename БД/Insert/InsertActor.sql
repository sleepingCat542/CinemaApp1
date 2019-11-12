--use Cinema;
CREATE PROCEDURE InsertActor
    @name nvarchar(20),
	@surname nvarchar(20),
	@country nvarchar(70),
	@age tinyint,
	@image varbinary(max),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
	    DECLARE @country_id varchar(10);
		SET @country_id = (SELECT ID FROM COUNTRY WHERE NAME = @country);
	--	SET @image_id = (SELECT ID FROM IMAGES WHERE ID = @image);
		BEGIN
		    INSERT INTO ACTOR (NAME, SURNAME, COUNTRY_ID, AGE, IMAGE)
			    VALUES (@name, @surname, @country_id, @age, @image);
			SET @rc = 1;
		END
	END;

DROP PROCEDURE InsertActor;
select * from actor;
exec InsertActor @name = 'Том', @surname = 'Харди', @country = 'Великобритания', @age = 41, @rc = 1;
insert into MOVIE_ACTOR(ACTOR_ID)
SELECT ACTOR_ID FROM ACTOR WHERE NAME = 'Том'; 
insert into MOVIE_ACTOR(MOVIE_ID)
SELECT MOVIE_ID FROM MOVIE WHERE NAME = 'Веном'; 

SELECT a.NAME[Актер], b.NAME[Фильм] FROM ACTOR AS a INNER JOIN MOVIE_ACTOR AS ab ON a.ACTOR_ID=ab.ACTOR_ID INNER JOIN MOVIE AS b ON ab.MOVIE_ID=b.MOVIE_ID
where a.NAME = 'Том';

insert into MOVIE_ACTOR 
SELECT a.NAME[Актер], ab.ACTOR_ID[ACTOR_ID] FROM ACTOR AS a INNER JOIN MOVIE_ACTOR AS ab ON a.ACTOR_ID=ab.ACTOR_ID
where a.NAME = 'a';


SELECT * FROM MOVIE_ACTOR;
delete MOVIE_ACTOR;

select * from ACTOR;
delete ACTOR;
delete MOVIE_ACTOR;
delete MOVIE;
--delete ACTOR;
--INSERT INTO ACTOR(PIC)
--   SELECT * FROM OPENROWSET(BULK N'C:\Cinema\Images\Actor\Tom_Hardy.jpg', SINGLE_BLOB) AS DATA WHERE NAME = 'Том';
--insert into ACTOR (PIC)
--select BulkColumn
--from Openrowset(Bulk 'C:\Cinema\Images\Actor\Tom_Hardy.jpg', Single_Blob) as img;
--insert into ACTOR (PIC) values ('C:\Cinema\Images\Actor\Tom_Hardy.jpg');
--select * from ACTOR;