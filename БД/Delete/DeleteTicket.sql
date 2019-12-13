CREATE PROCEDURE DeleteTicket
    @unic nvarchar(20),
	@row int,
	@seat int,
	@rc int output
	AS BEGIN
	BEGIN TRY
		begin tran
		SET @rc = 0;
		DECLARE @purch_id INT =(select id from PURCHASE where PURCHASE.UNICK_TICKET=@unic);
		delete TICKETS FROM TICKETS T INNER JOIN PURCHASE P ON T.PURCHASE_ID=P.ID
		WHERE T.ROW=@row AND T.SEAT=@seat AND T.PURCHASE_ID=@purch_id;		
		--if(0=(select COUNT(*) FROM TICKETS WHERE PURCHASE_ID=@purch_id ))
		--delete PURCHASE FROM PURCHASE 
		--WHERE PURCHASE.ID=@purch_id;
		COMMIT TRAN;
		SET @rc = 1;
		END TRY
		BEGIN CATCH
		IF @@TRANCOUNT>0 ROLLBACK TRAN;
		END CATCH;
	END;

	drop procedure DeleteTicket;
	 

