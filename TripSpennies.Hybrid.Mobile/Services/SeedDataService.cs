using TripSpennies.Hybrid.Mobile.Data;

namespace TripSpennies.Hybrid.Mobile.Services
{
    public class SeedDataService
    {
        private readonly DbContext _dbContext;

        public SeedDataService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedDataAsync()
        {
            var foodCategory = await _dbContext.FindAsync<ExpenseCategory>("Food");
             
            if (foodCategory is not null) return; //Means seeding already happened

            var expenseCategories = new List<ExpenseCategory>()
            {
                new("Food"), 
                new("Gas"), 
                new("Entertainment"), 
                new("Shopping"), 
                new("Other")
            };

            var locationCategories = new List<LocationCategory>
            {
                new LocationCategory("Beach", "/images/beach.png"),
                new LocationCategory("City", "/images/city.png"),
                new LocationCategory("Nature & Wildlife", "/images/nature.png"),
                new LocationCategory("Mountains", "/images/mountain.png"),
                new LocationCategory("Road Trip", "/images/road-trip.png"),
                new LocationCategory("Religious", "/images/pray.png"),
                new LocationCategory("Other", "/images/route.png")
            };

            foreach(var expenseCategory in expenseCategories)
            {
                await _dbContext.AddItemAsync(expenseCategory);
            }

            foreach(var location in locationCategories)
            {
                await _dbContext.AddItemAsync(location);
            }
        }


    }
}
