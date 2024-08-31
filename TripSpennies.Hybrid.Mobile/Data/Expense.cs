using SQLite;
using System.ComponentModel.DataAnnotations;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace TripSpennies.Hybrid.Mobile.Data
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public int TripId { get; set; }
        
        [Required, MaxLength(100)]
        public string Justification { get; set; }

        [Range(0.1, double.MaxValue)]
        public double Amount { get; set; }

        [Required]
        public string Category { get; set; }
        public DateTime? SpentOn { get; set; }
    }
}
