using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.API.Models
{
    public class Category
    {
        public int Id_Category { get; set; }
        [MaxLength(15)]
        public string Name { get; set; }

        public string Description { get; set; }

        //1 to Many, 1 category can belong to many expenses
        public ICollection<Expense> Expenses { get; set; }
    }
    
    
}