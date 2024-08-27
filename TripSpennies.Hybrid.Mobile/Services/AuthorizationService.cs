namespace TripSpennies.Hybrid.Mobile.Services
{
	public class AuthorizationService
	{
        private const string LoggedInKey = "logged-in";

		private readonly IPreferences _preferences;
        public AuthorizationService()
        {
            _preferences = Preferences.Default;
        }

        public bool IsSignedIn => _preferences.ContainsKey(LoggedInKey);

        public void SignIn()
        {
            //Checking user cred from database
            _preferences.Set(LoggedInKey, true);
        }

        public void SignOut()
        {
            _preferences.Remove(LoggedInKey);
        }
    }

}
