
CREATE PROCEDURE InsertActor
    @name nvarchar(20),
	@surname nvarchar(20),
	@country nvarchar(70),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
	    DECLARE @country_id varchar(10);
		SET @country_id = (SELECT ID FROM COUNTRY WHERE NAME = @country);
		BEGIN
		    INSERT INTO ACTOR (NAME, SURNAME, COUNTRY_ID)
			    VALUES (@name, @surname, @country_id);
			SET @rc = 1;
		END
	END;

DROP PROCEDURE InsertActor;
select * from actor;

exec InsertActor @name = '���', @surname = '�����', @country = '��������������',  @rc = 1;

--insert into MOVIE_ACTOR(ACTOR_ID)
--SELECT ACTOR_ID FROM ACTOR WHERE NAME = '���'; 
--insert into MOVIE_ACTOR(MOVIE_ID)
--SELECT MOVIE_ID FROM MOVIE WHERE NAME = '�����'; 

--SELECT a.NAME[�����], b.NAME[�����] FROM ACTOR AS a INNER JOIN MOVIE_ACTOR AS ab ON a.ACTOR_ID=ab.ACTOR_ID INNER JOIN MOVIE AS b ON ab.MOVIE_ID=b.MOVIE_ID
--where a.NAME = '���';

--insert into MOVIE_ACTOR 
--SELECT a.NAME[�����], ab.ACTOR_ID[ACTOR_ID] FROM ACTOR AS a INNER JOIN MOVIE_ACTOR AS ab ON a.ACTOR_ID=ab.ACTOR_ID
--where a.NAME = 'a';


--SELECT * FROM MOVIE_ACTOR;
--delete MOVIE_ACTOR;

--delete ACTOR;
--INSERT INTO ACTOR(PIC)
--   SELECT * FROM OPENROWSET(BULK N'C:\Cinema\Images\Actor\Tom_Hardy.jpg', SINGLE_BLOB) AS DATA WHERE NAME = '���';
--insert into ACTOR (PIC)
--select BulkColumn
--from Openrowset(Bulk 'C:\Cinema\Images\Actor\Tom_Hardy.jpg', Single_Blob) as img;
--insert into ACTOR (PIC) values ('C:\Cinema\Images\Actor\Tom_Hardy.jpg');
--select * from ACTOR;