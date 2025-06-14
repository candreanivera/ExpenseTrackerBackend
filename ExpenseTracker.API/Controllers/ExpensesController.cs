using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.API.Models;
using ExpenseTracker.API.Data;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ExpensesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
        => await _context.Expenses.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Expense>> PostExpense(Expense expense)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetExpenses), new { id = expense.Id }, expense);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null) return NotFound();

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutExpense(int id, Expense updatedExpense)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(new { message = "Errors were found", errors });
        }

        if (id != updatedExpense.Id)
        {
            return BadRequest(new { message = "The ID in the URL does not match the ID in the request body." });
        }

        var existingExpense = await _context.Expenses.FindAsync(id);
        if (existingExpense == null)
        {
            return NotFound();
        }

        // Update the properties
        existingExpense.Description = updatedExpense.Description;
        existingExpense.Amount = updatedExpense.Amount;
        existingExpense.Date = updatedExpense.Date;
        existingExpense.Category = updatedExpense.Category;

        await _context.SaveChangesAsync();

        return Ok(existingExpense);
    }

}