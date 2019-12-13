CREATE PROCEDURE InsertCinema
    @name nvarchar(30),
	@address nvarchar(max)=null,
	@website nvarchar(max)=null,
	@city nvarchar(30),
	@halls int,
	@timetable nvarchar(200)=null,
	@message nvarchar(200) output,
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		if(@name=any(select NAME from CINEMA where CITY=@city))
			set @message='����� ��������� ��� ����������!';
		else
		BEGIN
		    INSERT INTO CINEMA (NAME, ADDRESS, WEBSITE, CITY, NUMBER_OF_HALLS, TIMETABLE)
			    VALUES (@name, @address, @website, @city, @halls, @timetable);
			SET @rc = 1;
		END
		return @rc;
	END;

DROP PROCEDURE InsertCinema;
select * from CINEMA;

declare @r int=0;
declare @mes varchar(100)='';
exec @r=InsertCinema @name = '�����������', @address = '��-� �������������, 13', @website = 'https://vk.com/kino_centralny', @city = '�����', @halls = 1, @timetable = '��-�� � 11.30 �� 21.30', @message=@mes output; print @r;
exec @r=InsertCinema @name = '������', @address = '��. ����������, 23', @website = null, @city = '�����', @halls = 3, @timetable = '�͖�� � 10:00 �� 22:00', @message=@mes output; 
exec @r=InsertCinema @name = '��������', @address = '��. ����������� �������, 28', @website = 'http://kinominska.by/objects/27', @city = '�����', @halls = 5, @timetable = '�͖�� � 10:00 �� 22:00', @message=@mes output; 
exec @r=InsertCinema @name = '��������', @address = '��-� ������ ������, 25', @website = null, @city = '�����', @halls = 2, @timetable = '�͖�� � 10:00 �� 22:00', @message=@mes output;
exec @r=InsertCinema @name = '����', @address = '��. ���������, 31', @website = null, @city = '�����', @halls = 1, @timetable = '�͖�� � 10:00 �� 22:00', @message=@mes output; 
exec @r=InsertCinema @name = '������', @address = '��-� �����������, 13', @website = null, @city = '�����', @halls = 1, @timetable = '�͖�� � 10:00 �� 22:00', @message=@mes output; 
exec @r=InsertCinema @name = '������', @address = '��-� ����������, 10', @website = 'http://mogilevkino.by/cinema/142#11.11.2019/onecinema', @city = '������', @halls = 2, @timetable = '��-�� � 11.00 �� 22.00', @message=@mes output; 
exec @r=InsertCinema @name = '�������� �����', @address = '��. ������������, 14', @website = 'http://mogilevkino.by/cinema/143#11.11.2019/onecinema', @city = '������', @halls = 1, @timetable = '��-�� � 11.00 �� 22.00', @message=@mes output; 
exec @r=InsertCinema @name = '��� ����', @address = '��. ������, 40', @website = 'https://afisha.tut.by/place/dom-kino-v-vitebske/', @city = '�������', @halls = 1, @timetable = '�͖�� � 08:50 �� 21:40', @message=@mes output; 
exec @r=InsertCinema @name = '������', @address = '��-� �����������, 41�', @website = 'https://afisha.tut.by/place/vostok-grodno/', @city = '������', @halls = 1, @timetable = '�͖�� � 21:00 �� 03:00, ����� � 14:00 �� 03:00', @message=@mes output; 
exec @r=InsertCinema @name = '��������� ��. ��������', @address = '��. ����������, 4', @website = 'https://afisha.tut.by/place/kinoteatr-kalinina/', @city = '������', @halls = 1, @timetable = '��-�� � 11.30 �� 21.30', @message=@mes output; print @mes;

