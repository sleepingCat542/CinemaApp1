CREATE PROCEDURE SelectPrice
@ticket nvarchar(10),
@price int = NULL output
AS BEGIN
    SET @price = (SELECT PRICE FROM PURCHASE WHERE UNICK_TICKET = @ticket);
	PRINT @price;
END;



DROP PROCEDURE SelectPrice;
--exec SelectPrice @pass = 'FCNBL';



