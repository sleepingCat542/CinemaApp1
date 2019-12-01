CREATE PROCEDURE GetSetActors
@movie nvarchar(20),
@reslt nvarchar(400)='' output
AS BEGIN
DECLARE @name nvarchar(20), @surname nvarchar(30);
DECLARE ActorSub CURSOR FOR SELECT A.NAME, A.SURNAME
		FROM MOVIE M INNER JOIN ACTOR_MOVIE AM ON AM.MOVIE_ID = M.ID
			INNER JOIN ACTOR A ON A.ID = AM.ACTOR_ID where M.NAME=@movie;
OPEN ActorSub;
	FETCH ActorSub INTO @name, @surname;
	while @@FETCH_STATUS=0
	begin
		if (@reslt!='')
		set @reslt=@reslt+', '+RTRIM(@name)+' '+RTRIM(@surname);	
		else
		set @reslt=RTRIM(@name)+' '+RTRIM(@surname);
		FETCH ActorSub INTO @name, @surname
	end;
	close ActorSub;
	deallocate ActorSub;
end;

drop PROCEDURE GetSetActors;

declare @answer nvarchar(400);
exec GetSetActors @movie='Малыш Джо', @reslt=@answer output;
print @answer;