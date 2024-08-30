namespace TripSpennies.Hybrid.Mobile.Services
{
	public class TripsService
	{
		private readonly DbContext _dbContext;

        public TripsService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Trip>> GetTripsAsync(int pageNr = 1, int count = 10)
        {
            var query = await _dbContext.GetTableAsync<Trip>();

            return await query.OrderByDescending(t => t.AddedOn)
                .Skip((pageNr - 1) * count)
                .Take(count)
                .ToArrayAsync();
        }

        public async Task<MethodDataResult<Trip>> SaveTripAsync(Trip trip)
        {
            try
            {
				if (trip.Id == 0)
				{
					//Create trip
					await _dbContext.AddItemAsync<Trip>(trip);
				}
				else
				{
					//Update existing trip
					await _dbContext.UpdateItemAsync<Trip>(trip);
				}

				return MethodDataResult<Trip>.Success(trip);
			}
            catch (Exception ex)
            {
                return MethodDataResult<Trip>.Fail(ex.Message);
            }
        }

        public async Task<Trip?> GetTripAsync(int tripId)
        {
            return await _dbContext.FindAsync<Trip>(tripId);
        }

    }
}
