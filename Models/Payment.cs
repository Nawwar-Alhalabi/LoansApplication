public class Payment
{
    public int Id { get; set; }
    public int LoanId { get; set; }
    public Loan Loan { get; set; }
    public DateTime? DateOfPayment  { get; set; }
    public decimal MonthlyAmount { get; set; }
    public bool IsPaid { get; set; } = false;
    public DateTime? PaidAt { get; set; } = null;
}
