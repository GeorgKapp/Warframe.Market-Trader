namespace Warframe.Market_Api.Api.Data
{
    internal static class EndPoints
    {
        private const string BaseApiUrl = "https://api.warframe.market/";
        private const string ApiVersion = "v1";
        private const string BaseUrl = BaseApiUrl + ApiVersion;

        private const string OrdersUrl = "/orders";
        private const string ItemsUrl = "/items";
        private const string LoginUrl = "/auth/signin";
        private const string LogoutUrl = "/auth/signout";
        private const string ProfileUrl = "/profile";

        private const string MyProfile = "Ivoken";

        public static string GetAllItemsUrl() 
            => $"{BaseUrl}{ItemsUrl}";

        public static string GetItemInformationUrl(string itemUrl) 
            => $"{BaseUrl}{ItemsUrl}/{itemUrl}";

        public static string GetItemOrdersUrl(string itemUrl)
            => $"{BaseUrl}{ItemsUrl}/{itemUrl}{OrdersUrl}";

        public static string GetProfileOrdersUrl(string profileName = null)
        {
            var ordersUrl = profileName == null
                ? $"/{MyProfile}{OrdersUrl}"
                : $"/{profileName}{OrdersUrl}";

            return $"{BaseUrl}{ProfileUrl}{ordersUrl}";
        }

        public static string GetProfileOrderUrl()
            => $"{BaseUrl}{ProfileUrl}{OrdersUrl}";

        public static string GetProfileOrderUrlByID(string OrderID)
            => $"{BaseUrl}{ProfileUrl}{OrdersUrl}/{OrderID}";

        public static string GetLoginUrl() 
            => $"{BaseUrl}{LoginUrl}";

        public static string GetLogoutUrl()
            => $"{BaseUrl}{LogoutUrl}";
    }
}
