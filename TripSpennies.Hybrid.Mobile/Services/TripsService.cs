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
            trip.Status = Enum.Parse<TripStatus>(trip.DisplayStatus);
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

        public async Task<Trip?> GetTripAsync(int tripId, bool includeExpenses = false)
        {
            var trip = await _dbContext.FindAsync<Trip>(tripId);

            if (includeExpenses)
            {
               trip.Expenses = await _dbContext.GetFilteredAsync<Expense>(e => e.TripId == tripId) ?? Enumerable.Empty<Expense>();
            }

            return trip;
        }

        public async Task<MethodDataResult<Expense>> SaveExpenseAsync(Expense expense)
        {
			
			try
			{
				if (expense.Id == 0)
				{
					await _dbContext.AddItemAsync<Expense>(expense);
				}
				else
				{
					await _dbContext.UpdateItemAsync<Expense>(expense);
				}

				return MethodDataResult<Expense>.Success(expense);
			}
			catch (Exception ex)
			{
				return MethodDataResult<Expense>.Fail(ex.Message);
			}

		}

        public async Task<Expense?> GetExpenseAsync(long expenseId)
        {
            return await _dbContext.FindAsync<Expense>(expenseId);
        }

        public async Task<MethodResult> SaveExpenseCategoryAsync(string categoryName)
        {
            var dbCategory = await _dbContext.FindAsync<ExpenseCategory>(categoryName);

            if(dbCategory is not null)
            {
                return MethodResult.Fail($"Category: {categoryName} already exists");
            }
            await _dbContext.AddItemAsync<ExpenseCategory>(new ExpenseCategory(categoryName));
            return MethodResult.Success(); 
        }

    }
}
