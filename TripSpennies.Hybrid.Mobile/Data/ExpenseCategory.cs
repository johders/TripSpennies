using SQLite;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace TripSpennies.Hybrid.Mobile.Data
{
    public class ExpenseCategory
    {
        [PrimaryKey, MaxLength(100)]
        public string Name { get; set; }

        public ExpenseCategory()
        {
        }

        public ExpenseCategory(string name)
        {
            Name = name;
        }
    }
}
