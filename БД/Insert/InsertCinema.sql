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
			set @message='Такой кинотеатр уже существует!';
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
exec @r=InsertCinema @name = 'Центральный', @address = 'пр-т Независимости, 13', @website = 'https://vk.com/kino_centralny', @city = 'Минск', @halls = 1, @timetable = 'ПН-ВС с 11.30 до 21.30', @message=@mes output; print @r;
exec @r=InsertCinema @name = 'Аврора', @address = 'ул. Притыцкого, 23', @website = null, @city = 'Минск', @halls = 3, @timetable = 'ПН–ВС с 10:00 до 22:00', @message=@mes output; 
exec @r=InsertCinema @name = 'Беларусь', @address = 'ул. Романовская Слобода, 28', @website = 'http://kinominska.by/objects/27', @city = 'Минск', @halls = 5, @timetable = 'ПН–ВС с 10:00 до 22:00', @message=@mes output; 
exec @r=InsertCinema @name = 'Берестье', @address = 'пр-т Газеты Правда, 25', @website = null, @city = 'Минск', @halls = 2, @timetable = 'ПН–ВС с 10:00 до 22:00', @message=@mes output;
exec @r=InsertCinema @name = 'Киев', @address = 'ул. Каховская, 31', @website = null, @city = 'Минск', @halls = 1, @timetable = 'ПН–ВС с 10:00 до 22:00', @message=@mes output; 
exec @r=InsertCinema @name = 'Москва', @address = 'пр-т Победителей, 13', @website = null, @city = 'Минск', @halls = 1, @timetable = 'ПН–ВС с 10:00 до 22:00', @message=@mes output; 
exec @r=InsertCinema @name = 'Космос', @address = 'пр-т Пушкинский, 10', @website = 'http://mogilevkino.by/cinema/142#11.11.2019/onecinema', @city = 'Могилёв', @halls = 2, @timetable = 'ПН-ВС с 11.00 до 22.00', @message=@mes output; 
exec @r=InsertCinema @name = 'Чырвоная Зорка', @address = 'ул. Первомайская, 14', @website = 'http://mogilevkino.by/cinema/143#11.11.2019/onecinema', @city = 'Могилёв', @halls = 1, @timetable = 'ПН-ВС с 11.00 до 22.00', @message=@mes output; 
exec @r=InsertCinema @name = 'Дом кино', @address = 'ул. Ленина, 40', @website = 'https://afisha.tut.by/place/dom-kino-v-vitebske/', @city = 'Витебск', @halls = 1, @timetable = 'ПН–ВС с 08:50 до 21:40', @message=@mes output; 
exec @r=InsertCinema @name = 'Восток', @address = 'пр-т Космонавтов, 41Б', @website = 'https://afisha.tut.by/place/vostok-grodno/', @city = 'Гродно', @halls = 1, @timetable = 'ПН–ПТ с 21:00 до 03:00, СБ–ВС с 14:00 до 03:00', @message=@mes output; 
exec @r=InsertCinema @name = 'Кинотеатр им. Калинина', @address = 'ул. Коммунаров, 4', @website = 'https://afisha.tut.by/place/kinoteatr-kalinina/', @city = 'Гомель', @halls = 1, @timetable = 'ПН-ВС с 11.30 до 21.30', @message=@mes output; print @mes;

