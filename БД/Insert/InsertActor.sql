
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

exec InsertActor @name = N'Петр', @surname = N'Федоров', @country = 'Россия',  @rc = 1;
exec InsertActor @name = N'Алексей', @surname = N'Чадов', @country = 'Россия',  @rc = 1;
exec InsertActor @name = N'Константин', @surname = N'Лавроненко', @country = 'Россия',  @rc = 1;
exec InsertActor @name = N'Ксения', @surname = N'Кутепова', @country = 'Россия',  @rc = 1;
exec InsertActor @name = N'Эмили', @surname = N'Бичем', @country = 'Великобритания',  @rc = 1;
exec InsertActor @name = N'Бен', @surname = N'Уишоу', @country = 'Великобритания',  @rc = 1;
exec InsertActor @name = N'Керри', @surname = N'Фокс', @country = 'Новая Зеландия',  @rc = 1;
exec InsertActor @name = N'Феникс', @surname = N'Броссар', @country = 'Франция',  @rc = 1;
exec InsertActor @name = N'Кристиан', @surname = N'Бэйл', @country = 'Великобритания',  @rc = 1; 
exec InsertActor @name = N'Мэтт', @surname = N'Дэймон', @country = 'США',  @rc = 1;
exec InsertActor @name = N'Катрина', @surname = N'Балф', @country = 'Великобритания',  @rc = 1;
exec InsertActor @name = N'Джош', @surname = N'Лукас', @country = 'США',  @rc = 1;
exec InsertActor @name = N'Хелен', @surname = N'Миррен', @country = 'Великобритания',  @rc = 1; 
exec InsertActor @name = N'Джим', @surname = N'Картер', @country = 'Великобритания',  @rc = 1;
exec InsertActor @name = N'Иэн', @surname = N'Маккеллен', @country = 'Великобритания',  @rc = 1;
exec InsertActor @name = N'Рассел', @surname = N'Тови', @country = 'Великобритания',  @rc = 1;