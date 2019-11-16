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


--insert into MOVIE(NAME, RELEASE, PLOT) values ('�����', '12.12.2018', '��� ���� � ���� ���������� ���� � ���� ��������� ��������-�������, ������� �������� ���� ������������������ �������������? ��� ������ ����� - ������� ������ ��������, � ������������ � ��� ����������. ���� ����� �� ��������������?.. ���� � �����-�� ������ �� ���������, ��� ���� ������ ����� �� ��� �� � �����. ��� ���� �������. � ���� � ��� ������� ����� �����������! �� - �����!');
--insert into MOVIE(NAME, RELEASE, PLOT) values ('������', '21.01.2016', '���� ������ � ������. ������ �������� ��������� ��������� ���������� ��� ��� ��������� ������� X�, ������ ������� ����������� ����, ���������� � ����������� � ���������. �� �������� �����: ��� ��������� ��������� ��������� ��������, � ������������ �����������. ��, ���� ������ �����, � ��� ��������� �� ����� � ���������� ��������� ���. �� ������� � ��� ������� �������.');
--insert into MOVIE(NAME, RELEASE, PLOT) values ('������', '16.06.2008', '���� �����, ���� ����������, � ���� ������. ��������� ������������������ ������������ ���������������, ��� ����� ��� � ����� ����. �� ����� ������ �� ������ � ����� � ������� �����������, ������� ����� ����� � ����� �������������� ���������� � ������������� ������. � ����� ������, �������� �������������� �������� � �����: ���� ���������� ������ �������� �����, �� ������ �� ��������, ��� ��������� ����� ���������.');

select * from MOVIE;

DROP PROCEDURE InsertMovie;


select * from movie;