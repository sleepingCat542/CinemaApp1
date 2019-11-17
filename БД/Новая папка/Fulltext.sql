CREATE FULLTEXT CATALOG MovieCatalog
   with accent_sensitivity = on
   as default
   authorization dbo
go
ALTER FULLTEXT CATALOG TestCatalog
   REBUILD WITH ACCENT_SENSITIVITY=OFF    
GO
   DROP FULLTEXT CATALOG MovieCatalog

GO
   CREATE FULLTEXT INDEX ON MOVIE(PLOT)
        KEY INDEX PK_Movie ON(MovieCatalog)
		WITH (CHANGE_TRACKING AUTO)
GO
   DROP FULLTEXT INDEX ON MOVIE
GO


   
   
