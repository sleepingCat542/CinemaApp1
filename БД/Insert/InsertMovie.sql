CREATE PROCEDURE InsertMovie
    @name nvarchar(max),
	@release date,
	@country nvarchar(70),
	@genre nvarchar(30),
	@runningtime int,
	@studioname nvarchar(20),
	@plot nvarchar(max),
	@image varbinary(max)=null,
	@video varbinary(max)=null,
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
		--Declare @sql as varchar(max);
		DECLARE @movie_id uniqueidentifier;
		BEGIN
			BEGIN TRAN		
				INSERT INTO MOVIE(NAME, RELEASE, COUNTRY_ID, RUNNING_TIME, STUDIO_ID, PLOT, IMAGE, TRAILER)
					VALUES (@name, @release, @country_id, @runningtime, @studio_id, @plot, @image, @video);			
				SET @movie_id=(select id from movie where name=@name);
				INSERT INTO GENRE_MOVIE(GENRE_ID, MOVIE_ID)
					VALUES (@genre_id, @movie_id);			
				SET @rc = 1;
			COMMIT TRAN;
			IF @@TRANCOUNT>0 ROLLBACK TRAN;
		END
	END;
	

declare @rrc int=0;
exec InsertMovie @name='��������', @release='15.03.2019', @country='������', @runningtime=150, @studioname='��3', @genre='����������', 
@plot='� ��������� ������� ���-�� ���������. ����� � ������� ������ ���������� ������� ����� ����������. ���������� �������� � ������, ��� ����� ������ ��������� ����� � ��������� ������, �� ����� ���������� ������������ ����. 
��, ��� ������� ������� �� �������� ����� �����, ��������. � ���������, � �����������, �� �������, � ������� ������� � ��������, ������� � ����� ������������. ��� ��� ��� ���������� ��� �����?
 � ��� ����� ����������� ��������� �������� ������������?', @rc=@rrc output;

 declare @rrc int=0;
 exec InsertMovie @name='����� ���', @release='17.05.2019', @country='��������������', @runningtime=105, @studioname='Coop99', @genre='����������', 
@plot='����-�������� ����, ���������� ������ �� ��������� ����� ����� ��������, ������ ��������� ������ � ���� �� ��� ��������� ���������,
 �� ������ ������ ��������� ����������. �� �� �� ��� ������, � �����������, ��� �� �������, ���� �����������, ������� ���������,
  � ���� ����� ��������� ������� �������.', @rc=@rrc output;

 declare @rrc int=0;
 exec InsertMovie @name='Ford ������ Ferrari', @release='11.11.2019', @country='���', @runningtime=152, @studioname='20th Century Fox', @genre='���������', 
@plot='����� ������������ � ���������������� ������������� �������������� ������������ �������� ����� � ��������� ����������� ������� ���� ������,
 ������� ������ ������� ����� ����������� � ����������� �������, ����� ������� ��������� ����� ��������, ������� ���� ������������� � Ferrari �� 
 ���������� ����, ��������� �� ������� � �������� 1960-�.', @rc=@rrc output;

 declare @rrc int=0;
 exec InsertMovie @name='������� ����', @release='08.11.2019', @country='���', @runningtime=108, @studioname='New Line Cinema', @genre='��������', 
@plot='���������������� �������� ��� ������ ���� ����� ����� �����, ����� ���������� � ���� � ������� ������ ����� ������.
 �������� ����� � ������� ������ �� ���� �� ��������, ��� ����� ���� �� ���, ��� ��� ��� �������������.', @rc=@rrc output;

-- declare @rrc int=0;
-- exec InsertMovie @name='��������', @release='15.03.2019', @country='������', @runningtime=150, @studioname='����������', @genre='����������', 
--@plot='� ��������� ������� ���-�� ���������. ����� � ������� ������ ���������� ������� ����� ����������. ���������� �������� � ������, ��� ����� ������ ��������� ����� � ��������� ������, �� ����� ���������� ������������ ����. 
--��, ��� ������� ������� �� �������� ����� �����, ��������. � ���������, � �����������, �� �������, � ������� ������� � ��������, ������� � ����� ������������. ��� ��� ��� ���������� ��� �����?
-- � ��� ����� ����������� ��������� �������� ������������?', @rc=@rrc output;

-- declare @rrc int=0;
-- exec InsertMovie @name='��������', @release='15.03.2019', @country='������', @runningtime=150, @studioname='����������', @genre='����������', 
--@plot='� ��������� ������� ���-�� ���������. ����� � ������� ������ ���������� ������� ����� ����������. ���������� �������� � ������, ��� ����� ������ ��������� ����� � ��������� ������, �� ����� ���������� ������������ ����. 
--��, ��� ������� ������� �� �������� ����� �����, ��������. � ���������, � �����������, �� �������, � ������� ������� � ��������, ������� � ����� ������������. ��� ��� ��� ���������� ��� �����?
-- � ��� ����� ����������� ��������� �������� ������������?', @rc=@rrc output;

-- declare @rrc int=0;
-- exec InsertMovie @name='��������', @release='15.03.2019', @country='������', @runningtime=150, @studioname='����������', @genre='����������', 
--@plot='� ��������� ������� ���-�� ���������. ����� � ������� ������ ���������� ������� ����� ����������. ���������� �������� � ������, ��� ����� ������ ��������� ����� � ��������� ������, �� ����� ���������� ������������ ����. 
--��, ��� ������� ������� �� �������� ����� �����, ��������. � ���������, � �����������, �� �������, � ������� ������� � ��������, ������� � ����� ������������. ��� ��� ��� ���������� ��� �����?
-- � ��� ����� ����������� ��������� �������� ������������?', @rc=@rrc output;

-- declare @rrc int=0;
-- exec InsertMovie @name='��������', @release='15.03.2019', @country='������', @runningtime=150, @studioname='����������', @genre='����������', 
--@plot='� ��������� ������� ���-�� ���������. ����� � ������� ������ ���������� ������� ����� ����������. ���������� �������� � ������, ��� ����� ������ ��������� ����� � ��������� ������, �� ����� ���������� ������������ ����. 
--��, ��� ������� ������� �� �������� ����� �����, ��������. � ���������, � �����������, �� �������, � ������� ������� � ��������, ������� � ����� ������������. ��� ��� ��� ���������� ��� �����?
-- � ��� ����� ����������� ��������� �������� ������������?', @rc=@rrc output;

-- declare @rrc int=0;
-- exec InsertMovie @name='��������', @release='15.03.2019', @country='������', @runningtime=150, @studioname='����������', @genre='����������', 
--@plot='� ��������� ������� ���-�� ���������. ����� � ������� ������ ���������� ������� ����� ����������. ���������� �������� � ������, ��� ����� ������ ��������� ����� � ��������� ������, �� ����� ���������� ������������ ����. 
--��, ��� ������� ������� �� �������� ����� �����, ��������. � ���������, � �����������, �� �������, � ������� ������� � ��������, ������� � ����� ������������. ��� ��� ��� ���������� ��� �����?
-- � ��� ����� ����������� ��������� �������� ������������?', @rc=@rrc output;

--  declare @rrc int=0;
-- exec InsertMovie @name='��������', @release='15.03.2019', @country='������', @runningtime=150, @studioname='����������', @genre='����������', 
--@plot='� ��������� ������� ���-�� ���������. ����� � ������� ������ ���������� ������� ����� ����������. ���������� �������� � ������, ��� ����� ������ ��������� ����� � ��������� ������, �� ����� ���������� ������������ ����. 
--��, ��� ������� ������� �� �������� ����� �����, ��������. � ���������, � �����������, �� �������, � ������� ������� � ��������, ������� � ����� ������������. ��� ��� ��� ���������� ��� �����?
-- � ��� ����� ����������� ��������� �������� ������������?', @rc=@rrc output;

select * from MOVIE;

DROP PROCEDURE InsertMovie;


select * from movie;