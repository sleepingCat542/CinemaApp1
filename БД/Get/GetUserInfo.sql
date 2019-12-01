CREATE PROCEDURE UserInfo
    @login nvarchar(50),
	@password nvarchar(30),
	@email nvarchar(50) output,
	@id uniqueidentifier output
	AS BEGIN
		DECLARE @PASSW1 nvarchar(MAX);
		DECLARE @PASSW2 nvarchar(MAX);
		SET @PASSW1 =  (select Password FROM USERS where login =@login);  
		SET @PASSW2 =(SELECT HASHBYTES('SHA2_256', @password));
		IF EXISTS(SELECT ID FROM USERS WHERE LOGIN like @login and @PASSW1 like @PASSW2)
		BEGIN
		   set @id=(SELECT ID FROM USERS WHERE LOGIN like @login and @PASSW1 like @PASSW2);
		   set @email=(SELECT EMAIL FROM USERS WHERE LOGIN like @login and @PASSW1 like @PASSW2);
		END
	END;