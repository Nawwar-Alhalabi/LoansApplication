using System.ComponentModel.DataAnnotations;

public class Customer
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; }
    public ICollection<Loan> Loans { get; set; }
}