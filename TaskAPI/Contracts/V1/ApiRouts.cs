namespace TaskAPI.Contracts.V1
{
    public static class ApiRouts
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = $"{Root}/{Version}";



        public static class Addresses
        {
            public const string GetAll = Base + "/address";
            public const string Get = Base + "/address/{addressId}";
            public const string Create = Base + "/address";
            public const string Update = Base + "/address/{addressId}";
            public const string Delete = Base + "/address/{addressId}";

        }
    }
}
