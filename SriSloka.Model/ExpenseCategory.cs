using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SriSloka.Model
{
    public class ExpenseCategory
    {
        public ExpenseCategory()
        {
            Expenses = new List<Expenses>();
            Liabilitieses = new List<Liabilities>();
        }

        [Key]
        public int ExpenseCategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Liabilities> Liabilitieses { get; set; }

        public virtual ICollection<Expenses> Expenses { get; set; }
    }
}
