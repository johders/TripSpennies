using SQLite;
using System.ComponentModel.DataAnnotations;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace TripSpennies.Hybrid.Mobile.Data
{
    public class Trip
    {

		[PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Title { get; set; }

        [Required, MaxLength(50)]
        public string Location { get; set; }

        [Required, MaxLength(30)]
        public string CategoryImage { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
		
        private TripStatus _status = TripStatus.Planned;
		public TripStatus Status
        {
            get => _status;
            set
            {
                DisplayStatus = value.ToString();
                _status = value;
            }
        
        }

		[Ignore]
        public string DisplayStatus { get; set; }

    }
}
