namespace TripSpennies.Hybrid.Mobile.Data
{
    public class Trip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string CategoryImage { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public TripStatus Status { get; set; }

    }
}
