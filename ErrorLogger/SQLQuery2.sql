USE ErrorDB;
Go
CREATE PROCEDURE AddError(
	 @message nvarchar(50),
	@time smalldatetime)
AS
BEGIN
	INSERT INTO Error(Message,Time)
	VALUES(@message,@time)

	SELECT SCOPE_IDENTITY()

END