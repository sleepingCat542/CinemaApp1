CREATE PROCEDURE DeleteSession
    @id int,
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		BEGIN
		    DELETE SESSION WHERE ID = @id;
		    SET @rc = 1;
		END
	END;
	 

DROP PROCEDURE DeleteSession;