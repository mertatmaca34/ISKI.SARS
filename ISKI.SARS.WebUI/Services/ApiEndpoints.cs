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
            public const string Update = "/api/Users";
            public const string ChangePassword = "/api/Users/change-password";
        }

        public static class Template
        {
            public const string CreateTemplate = "/api/ReportTemplates";
        }
        public static class Report
        {
            public const string ListReportTemplates = "/api/ReportTemplates/list";
            public const string TagList = "/api/ReportTemplateTags/list";
        }

        public static class InstantValues
        {
            public const string List = "/api/InstantValues/list";
        }
    }
}
