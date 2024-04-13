namespace api_controller.Authority
{
    public static class AppRepository
    {
        private static List<Application> applications = new List<Application>
        {
            new Application { AppId = 1, AppName = "WebFront", ClientId = "webfront", ClientSecret = "webfrontsecret", Scopes = "read, write" },
            new Application { AppId = 2, AppName = "MobileApp", ClientId = "mobileapp", ClientSecret = "mobileappsecret", Scopes = "read" }
        };

        public static bool Authenticate(string clientId, string clientSecret)
        {
            return applications.Any(a => a.ClientId == clientId && a.ClientSecret == clientSecret);
        }

        public static Application? GetApplicationByClientId(string clientId)
        {
            return applications.FirstOrDefault(x => x.ClientId == clientId);
        }
    }
}
