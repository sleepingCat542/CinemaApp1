CREATE PROCEDURE GetSetGenres
@movie nvarchar(20),
@reslt nvarchar(120)='' output
AS BEGIN
DECLARE @genre nvarchar(30);
DECLARE GenreSub CURSOR FOR SELECT G.NAME
		FROM MOVIE M INNER JOIN GENRE_MOVIE GM ON GM.MOVIE_ID = M.ID
			INNER JOIN GENRE G ON G.ID = GM.GENRE_ID where M.NAME=@movie;
OPEN GenreSub;
	FETCH GenreSub INTO @genre;
	while @@FETCH_STATUS=0
	begin
	if (@reslt!='')
		set @reslt=@reslt+', ' +RTRIM(@genre);
		else
		set @reslt=RTRIM(@genre);
		FETCH GenreSub INTO @genre;
	end;
	close GenreSub;
	deallocate GenreSub;
end;

drop PROCEDURE GetSetGenres;


declare @answer nvarchar(100);
exec GetSetGenres @movie='Малыш Джо', @reslt=@answer output;
print @answer;



