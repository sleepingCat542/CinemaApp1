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
		else if(@email not like '%_@__%.__%')
			SET @message = @message + 'Неверный e-mail!/n';
		else
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



DECLARE @r int;  
DECLARE @mes nvarchar(200); 
exec Registration N'Yum','181813Yu',N'yuki.sai@mail.ru', @rc=@r OUTPUT, @message=@mes OUTPUT;
print @r + @mes;

DECLARE @r int;  
DECLARE @mes nvarchar(200); 
DECLARE @count int=1;
while(@count<120)
begin
declare @lo nvarchar(50)=N'User'+cast(@count as nvarchar(3));
declare @pa nvarchar(30)=cast(@count*100 as nvarchar(5))+'U';
declare @e nvarchar(50)=N'User'+cast(@count as nvarchar(3))+N'@mail.ru';
exec Registration 
	@login=@lo,
	@password=@pa,
	@email=@e,
	@rc=@r OUTPUT, @message=@mes OUTPUT;
	print @r + @mes;
	set @count=@count+1;
end;



--DECLARE @p nvarchar(32)=N'181813Yu';
--DECLARE @HashThis nvarchar(32);  
--SET @HashThis = CONVERT(nvarchar(32), @p);  
--SELECT HASHBYTES('SHA2_256', @HashThis);  