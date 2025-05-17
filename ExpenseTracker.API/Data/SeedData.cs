using ExpenseTracker.API.Models;

namespace ExpenseTracker.API.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Expenses.Any())
            return; // DB already seeded

        var testExpenses = new List<Expense>
        {
            new Expense { Description = "Groceries", Amount = 75.50m, Date = DateTime.Now.AddDays(-3), Category = "Food" },
            new Expense { Description = "Bus Ticket", Amount = 3.20m, Date = DateTime.Now.AddDays(-2), Category = "Transport" },
            new Expense { Description = "Movie Night", Amount = 15.00m, Date = DateTime.Now.AddDays(-1), Category = "Entertainment" },
            new Expense { Description = "Coffee", Amount = 4.80m, Date = DateTime.Now, Category = "Food" },
        };

        context.Expenses.AddRange(testExpenses);
        context.SaveChanges();
    }
}