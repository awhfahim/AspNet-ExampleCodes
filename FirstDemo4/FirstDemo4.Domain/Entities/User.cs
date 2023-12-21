using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Entities
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string UserName { get; set;}
        public string Password { get; set;}
        public List<Expense> Expenses { get; set;}
    }
}
