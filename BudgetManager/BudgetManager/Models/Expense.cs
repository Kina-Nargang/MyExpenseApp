using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetManager.Models
{
    public enum ExpenseCategory
    {
        Travel,
        Clothing,
        Groceries,
        Education,
        Children
    };
    public class Expense
    {
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }
        public ExpenseCategory Category { get; set; }

    }

}
