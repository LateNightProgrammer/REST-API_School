using System.Collections.Generic;
using SriSloka.Model;

namespace SriSloka.ViewModel
{
    public class ExpenseCategoryDto
    {
        public ExpenseCategoryDto()
        {
            Expenses = new List<Expenses>();
            Liabilitieses = new List<Liabilities>();
        }
        
        public int ExpenseCategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Liabilities> Liabilitieses { get; set; }

        public ICollection<Expenses> Expenses { get; set; }
    }
}
