CREATE PROCEDURE InsertHall
    @name nvarchar(30),
	@cinema nvarchar(30),
	@city nvarchar(30)=null,
	@rows int,
	@seats int,
	@message nvarchar(200) output
	AS BEGIN
		declare @rc int= 0;
		DECLARE  @cinema_id int;
		set @message='';
		if( @city is not null)
		SET @cinema_id = (SELECT ID FROM CINEMA WHERE NAME = @cinema and CITY=@city);
		else
		SET @cinema_id = (SELECT ID FROM CINEMA WHERE NAME = @cinema);
		if(@name=any(select NAME from HALL where CINEMA_ID=@cinema_id))
			set @message='Такой зал в этом кинотеатре уже существует!';
		else if(((select COUNT(*) from HALL where CINEMA_ID=@cinema_id)+1)>(SELECT NUMBER_OF_HALLS FROM CINEMA WHERE ID=@cinema_id))
			set @message='Нельзя добавить ещё один зал!';
		ELSE
		BEGIN
		    INSERT INTO HALL(NAME, CINEMA_ID, ROWS, SEATS)
			    VALUES (@name, @cinema_id, @rows, @seats);
			SET @rc = 1;
		END
		return @rc;
	END;

select * from HALL;
delete HALL;
DROP PROCEDURE InsertHall;

declare @r int=0;
declare @mes varchar(100)='';
exec @r=InsertHall @name = 'Главный', @cinema = 'Центральный', @city = 'Минск', @rows = 15, @seats =20, @message=@mes output; print @r; PRINT @MES; 
exec @r=InsertHall @name = 'Большой', @cinema = 'Аврора', @city = 'Минск', @rows = 15, @seats =39, @message=@mes output; print @r; PRINT @MES; 
exec @r=InsertHall @name = 'Комфортный', @cinema = 'Аврора', @city = 'Минск', @rows = 8, @seats =11, @message=@mes output; print @r; PRINT @MES; 
exec @r=InsertHall @name = 'Лазурный', @cinema = 'Аврора', @city = 'Минск', @rows = 12, @seats =25, @message=@mes output; print @r; PRINT @MES; 
exec @r=InsertHall @name = 'Главный', @cinema = 'Восток', @city = 'Гродно', @rows = 15, @seats =30, @message=@mes output; print @r; PRINT @MES; 
exec @r=InsertHall @name = 'Главный', @cinema = 'Дом Кино', @city = 'Витебск', @rows = 20, @seats =40, @message=@mes output; print @r; PRINT @MES; 
exec @r=InsertHall @name = 'Главный', @cinema = 'Кинотеатр им. Калинина', @city = 'Гомель', @rows = 15, @seats =20, @message=@mes output; print @r; PRINT @MES; 
exec @r=InsertHall @name = 'Первый', @cinema = 'Беларусь', @city = 'Минск', @rows = 13, @seats =20, @message=@mes output; print @r; PRINT @MES; 
exec @r=InsertHall @name = 'Второй', @cinema = 'Беларусь', @city = 'Минск', @rows = 12, @seats =21, @message=@mes output; print @r; PRINT @MES;
exec @r=InsertHall @name = 'Третий', @cinema = 'Беларусь', @city = 'Минск', @rows = 15, @seats =23, @message=@mes output; print @r; PRINT @MES; 
exec @r=InsertHall @name = 'Четвёртый', @cinema = 'Беларусь', @city = 'Минск', @rows = 15, @seats =25, @message=@mes output; print @r; PRINT @MES; 
