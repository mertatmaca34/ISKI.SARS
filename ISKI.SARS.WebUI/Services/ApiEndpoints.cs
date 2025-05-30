namespace ISKI.SARS.WebUI.Services
{
    public static class ApiEndpoints
    {
        public const string BaseUrl = "https://localhost:7094";

        public static class Auth
        {
            public const string Login = "/api/Auth/login";
            public const string Register = "/api/Auth/register";
        }

        public static class Users
        {
            public const string GetById = "/api/Users/{0}";
        }
    }
}
