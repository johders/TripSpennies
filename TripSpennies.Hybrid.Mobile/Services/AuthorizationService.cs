namespace TripSpennies.Hybrid.Mobile.Services
{
	public class AuthorizationService
	{
        private const string LoggedInKey = "logged-in";
		private readonly IPreferences _preferences;
        private readonly DbContext _dbContext;
        public AuthorizationService(DbContext dbContext)
        {
            _preferences = Preferences.Default;
            _dbContext = dbContext;
        }

        public bool IsSignedIn => _preferences.ContainsKey(LoggedInKey);

        public LoggedInUser CurrentUser => LoggedInUser.LoadFromJson(_preferences.Get<string>(LoggedInKey, string.Empty));

        public async Task<MethodResult> RegisterAsync(RegisterModel model)
        {
            var user = new User
            {
                Name = model.Name,
                Username = model.Username,
                Password = model.Password
            };

            if(await _dbContext.AddItemAsync<User>(user))
            {
                SetUser(user);
                return MethodResult.Success();
            }

            return MethodResult.Fail(null);
        }

        private void SetUser(User user)
        {
            var loggedInUser = new LoggedInUser(user.Id, user.Name);
            _preferences.Set(LoggedInKey, loggedInUser.ToJson());
        }

        public async Task ChangeNameAsync(string newName)
        {
            var dbUser = await _dbContext.FindAsync<User>(CurrentUser.Id);
            dbUser.Name = newName;
            await _dbContext.UpdateItemAsync(dbUser);
            SetUser(dbUser);
        }

		public async Task ChangePasswordAsync(string newPassword)
		{
			var dbUser = await _dbContext.FindAsync<User>(CurrentUser.Id);
			dbUser.Password = newPassword;
			await _dbContext.UpdateItemAsync(dbUser);
		}

		public async Task<MethodResult> SignInAsync(SigninModel model)
        {
            var dbUsers = await _dbContext.GetFilteredAsync<User>(u => u.Username == model.Username && u.Password == model.Password);
            var dbUser = dbUsers.FirstOrDefault();
            
            if(dbUser is not null)
            {
                SetUser(dbUser);
                return MethodResult.Success();
            }

            return MethodResult.Fail("Incorrect Credentials");
        }

        public void SignOut()
        {
            _preferences.Remove(LoggedInKey);
        }
    }

}
