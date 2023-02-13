namespace TaskAPI.Contracts.V1
{
    public static class ApiRouts
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = $"{Root}/{Version}";



        public static class Addresses
        {
            public const string GetAll = Base + "/addresses";
            public const string Get = Base + "/addresses/{addressId}";
            public const string Create = Base + "/addresses";
            public const string Update = Base + "/addresses/{addressId}";
            public const string Delete = Base + "/addresses/{addressId}";

        }
        public static class Values 
        {
            public const string Index = Base + "/values";
        }
        public static class Identity
        {
            public const string Login = Base + "/login";
            public const string Register = Base + "/register";
        }
    }
}
