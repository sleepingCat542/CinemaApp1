--insert Genre
CREATE PROCEDURE InsertGenre
    @name nvarchar(30)
	as begin
	    INSERT INTO GENRE(NAME)
		    VALUES (@name);
	end;

exec InsertGenre @name='A����';
exec InsertGenre @name='���������';
exec InsertGenre @name='������';
exec InsertGenre @name='�������';
exec InsertGenre @name='�������';
exec InsertGenre @name='��������';
exec InsertGenre @name='�������';
exec InsertGenre @name='��������������';
exec InsertGenre @name='�����';
exec InsertGenre @name='������������';
exec InsertGenre @name='�������';
exec InsertGenre @name='��������';
exec InsertGenre @name='���������';
exec InsertGenre @name='�������';
exec InsertGenre @name='������';
exec InsertGenre @name='����������';
exec InsertGenre @name='������';
exec InsertGenre @name='�������';
exec InsertGenre @name='�����������';
exec InsertGenre @name='��������';
exec InsertGenre @name='�����';
exec InsertGenre @name='���-���';
exec InsertGenre @name='�������';
exec InsertGenre @name='�����';
exec InsertGenre @name='����������';
exec InsertGenre @name='�����-����';
exec InsertGenre @name='�������';

DELETE GENRE;
SELECT * FROM GENRE;
DROP PROCEDURE InsertGenre;