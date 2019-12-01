CREATE PROCEDURE InsertPurchase
    @login nvarchar(50),
	@date date,
	@rc nvarchar(20) = '' output
	AS BEGIN
		DECLARE @user_id uniqueidentifier;
		SET @user_id = (SELECT ID FROM USERS WHERE LOGIN = @login);
		BEGIN
		   SET @rc = (select char((rand()*20 + 65))+char((rand()*25 + 65))+char((rand()*30 + 65))+char((rand()*35 + 65)));
		   INSERT INTO PURCHASE(USER_ID, DATE, UNICK_TICKET)
		      VALUES (@user_id, @date, @rc);
		END
	END;
	

exec InsertPurchase @login = 'User1', @date = '12.11.2019';
exec InsertPurchase @login = 'User1', @date = '15.11.2019';
exec InsertPurchase @login = 'User2', @date = '13.11.2019';
exec InsertPurchase @login = 'User2', @date = '12.11.2019';
exec InsertPurchase @login = 'User3', @date = '10.11.2019';
exec InsertPurchase @login = 'User3', @date = '09.11.2019';

SELECT * FROM PURCHASE
DELETE PURCHASE;
DROP PROCEDURE InsertPurchase;
