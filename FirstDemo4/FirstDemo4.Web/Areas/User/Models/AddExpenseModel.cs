using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Web.Areas.User.Models
{
	public class AddExpenseModel
	{
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public Domain.Entities.User User { get; set; }
        public Category? Category { get; set; }
    }
}
