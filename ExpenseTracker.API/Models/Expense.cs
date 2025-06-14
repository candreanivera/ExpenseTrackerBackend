//DataAnnotations allows the use of validations, like [MaxLength(20)] or [Required]
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
        //Each Expense belongs to 1 category
        public int Id_Category { get; set; }
        //Navegation property, allows acces to the whole category, not only the Id
        public Category Category { get; set; }
    }
}