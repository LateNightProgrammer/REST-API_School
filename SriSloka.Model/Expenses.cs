using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SriSloka.Model
{
    public class Expenses: TrackableEntity
    {
        [Key]
        public int ExpensesId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool IsPaid { get; set; }

        public bool IsProofSubmitted { get; set; }

        public bool IsRecurring { get; set; }

        public RecurringFrequency Frequency { get; set; }

        [ForeignKey("ExpenseCategory")]
        public int ExpenseCategoryId { get; set; }
    }

    public enum RecurringFrequency
    {
        OneTimePayment,
        Forthnightly,
        Monthly,
        Yearly
    }
}
