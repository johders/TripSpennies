using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripSpennies.Hybrid.Mobile.Data
{
    public class Expense
    {
        public long Id { get; set; }
        public int TripId { get; set; }
        public string Justification { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime SpentOn { get; set; }
    }
}
