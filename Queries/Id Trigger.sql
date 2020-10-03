CREATE TRIGGER IdCreate
   ON SupportUser
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @Username varchar(50)=(select Username from inserted)
    -- Insert statements for trigger here
	update SupportUser set UserID=newID() where Username=@Username
END
