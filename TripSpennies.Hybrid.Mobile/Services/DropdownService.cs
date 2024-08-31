namespace TripSpennies.Hybrid.Mobile.Services
{
	public class DropdownService
	{
        private readonly DbContext _dbContext;
        public DropdownService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LocationCategory[]> GetLocationCategoriesAsync()
        {
            return (await _dbContext.GetAllAsync<LocationCategory>()).ToArray();
        }

        public string[] GetTripStatuses() => Enum.GetNames<TripStatus>();

        public async Task<string[]> GetExpenseCategoriesAsync()
        {
            return (await _dbContext.GetAllAsync<ExpenseCategory>())
                .Select(e => e.Name)
                .ToArray();
        }
    }
}
