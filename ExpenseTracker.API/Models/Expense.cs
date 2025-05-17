using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.API.Models
{
    public class Expense
    {
    public int Id { get; set; }
    [MaxLength(20)]
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    [MaxLength(15)]
    public string Category { get; set; }  
    }
}