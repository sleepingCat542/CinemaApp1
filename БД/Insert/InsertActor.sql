
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

exec InsertActor @name = N'����', @surname = N'�������', @country = '������',  @rc = 1;
exec InsertActor @name = N'�������', @surname = N'�����', @country = '������',  @rc = 1;
exec InsertActor @name = N'����������', @surname = N'����������', @country = '������',  @rc = 1;
exec InsertActor @name = N'������', @surname = N'��������', @country = '������',  @rc = 1;
exec InsertActor @name = N'�����', @surname = N'�����', @country = '��������������',  @rc = 1;
exec InsertActor @name = N'���', @surname = N'�����', @country = '��������������',  @rc = 1;
exec InsertActor @name = N'�����', @surname = N'����', @country = '����� ��������',  @rc = 1;
exec InsertActor @name = N'������', @surname = N'�������', @country = '�������',  @rc = 1;
exec InsertActor @name = N'��������', @surname = N'����', @country = '��������������',  @rc = 1; 
exec InsertActor @name = N'����', @surname = N'������', @country = '���',  @rc = 1;
exec InsertActor @name = N'�������', @surname = N'����', @country = '��������������',  @rc = 1;
exec InsertActor @name = N'����', @surname = N'�����', @country = '���',  @rc = 1;
exec InsertActor @name = N'�����', @surname = N'������', @country = '��������������',  @rc = 1; 
exec InsertActor @name = N'����', @surname = N'������', @country = '��������������',  @rc = 1;
exec InsertActor @name = N'���', @surname = N'���������', @country = '��������������',  @rc = 1;
exec InsertActor @name = N'������', @surname = N'����', @country = '��������������',  @rc = 1;