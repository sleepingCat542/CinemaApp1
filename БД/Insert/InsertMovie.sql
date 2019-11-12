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
insert into MOVIE(NAME, RELEASE, PLOT) values ('�����', '12.12.2018', '��� ���� � ���� ���������� ���� � ���� ��������� ��������-�������, ������� �������� ���� ������������������ �������������? ��� ������ ����� - ������� ������ ��������, � ������������ � ��� ����������. ���� ����� �� ��������������?.. ���� � �����-�� ������ �� ���������, ��� ���� ������ ����� �� ��� �� � �����. ��� ���� �������. � ���� � ��� ������� ����� �����������! �� - �����!');
insert into MOVIE(NAME, RELEASE, PLOT) values ('������', '21.01.2016', '���� ������ � ������. ������ �������� ��������� ��������� ���������� ��� ��� ��������� ������� X�, ������ ������� ����������� ����, ���������� � ����������� � ���������. �� �������� �����: ��� ��������� ��������� ��������� ��������, � ������������ �����������. ��, ���� ������ �����, � ��� ��������� �� ����� � ���������� ��������� ���. �� ������� � ��� ������� �������.');
insert into MOVIE(NAME, RELEASE, PLOT) values ('������', '16.06.2008', '���� �����, ���� ����������, � ���� ������. ��������� ������������������ ������������ ���������������, ��� ����� ��� � ����� ����. �� ����� ������ �� ������ � ����� � ������� �����������, ������� ����� ����� � ����� �������������� ���������� � ������������� ������. � ����� ������, �������� �������������� �������� � �����: ���� ���������� ������ �������� �����, �� ������ �� ��������, ��� ��������� ����� ���������.');

select * from MOVIE;
delete MOVIE WHERE NAME = '�����';
DROP PROCEDURE InsertMovie;


select * from movie;