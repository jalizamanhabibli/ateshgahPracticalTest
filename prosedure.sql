Create Procedure  dbo.[GetInvoiceListByLoanDataProc]
(	
	-- Add the parameters for the function here
-- 	@pClientId	int,
	@pAmount		money,
	@pInterestRate	int,
	@pLoanPeriod	int,
	@pPayoutDate	datetime2,
	@pResult		nvarchar(max) out
)
AS
Begin
	declare @tblResult table (InvoiceNo int,DueDate datetime2,Amount money);
	declare @pLastInvoiceId  int = (select IDENT_CURRENT('Invoices'));
	declare @pLoanId int;
	declare @pLoop int	= 1;

	
	while(@pAmount > 0)
	begin	
		insert into @tblResult(InvoiceNo,DueDate, Amount) values(@pLastInvoiceId + @pLoop,DATEADD(M,@pLoop,@pPayoutDate),@pAmount/@pLoanPeriod + @pAmount*@pInterestRate/100.0)
		
		set @pAmount = @pAmount - @pAmount/@pLoanPeriod;
		set @pLoanPeriod = @pLoanPeriod - 1;
		set @pLoop = @pLoop + 1;
	end

	set @pResult = (select InvoiceNo Id,DueDate,Amount from @tblResult for json path);
End