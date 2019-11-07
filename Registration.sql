CREATE PROCEDURE Registration
    @login nvarchar(50),
	@password nvarchar(30),
	@email nvarchar(50),
	@rc int output,
	@message nvarchar(200) output
	AS BEGIN
		DECLARE @check_login int;
		DECLARE @HashThis nvarchar(max);		
	    SET @rc = 0;
		SET @message = ' ';
		set @check_login =(select count(*) FROM Users WHERE LOGIN = @login);
		if(@check_login!= 0)
			SET @message = @message + 'Такой логин уже существует!/n';
		--if(@email not like '%_@__%.__%')
		--	SET @message = @message + 'Неверный e-mail!/n';
		--if(@check_login!= 0 and @email like '_%@__%.__%')
		if(@check_login= 0)
			BEGIN
				SET @HashThis = CONVERT(nvarchar(max), @password); 
				SET @HashThis =	(SELECT HASHBYTES('SHA2_256', @HashThis));  
		    	INSERT INTO USERS (LOGIN, PASSWORD, EMAIL)
				VALUES (@login, @HashThis, @email);
				SET @rc = 1;
			END;
    END;

drop procedure Registration;

select * from USERS;
delete from USERS;

DECLARE @SalesYTDBySalesPerson int;  
DECLARE @SalesYTDBySalesPerson2 nvarchar(200); 
execute Registration 
N'Yum',
'181813Yu',
N'yuki.sai@mail',
@rc=@SalesYTDBySalesPerson OUTPUT,
@message=@SalesYTDBySalesPerson2 OUTPUT;
  print @SalesYTDBySalesPerson + @SalesYTDBySalesPerson2;


--DECLARE @p nvarchar(32)=N'181813Yu';
--DECLARE @HashThis nvarchar(32);  
--SET @HashThis = CONVERT(nvarchar(32), @p);  
--SELECT HASHBYTES('SHA2_256', @HashThis);  