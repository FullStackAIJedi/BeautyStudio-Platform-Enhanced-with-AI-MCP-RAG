namespace Identity.Domain.Models
{
    public static class ModelConstants
    {
        public static class User
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;
            public const int MinEmailLength = 5;
            public const int MaxEmailLength = 100;
            public const int MinUserNameLength = 3;
            public const int MaxUserNameLength = 50;
            public const int MinPasswordLength = 6;
            public const int MaxPasswordLength = 100;
        }

        public static class Role
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;
        }
    }
}
