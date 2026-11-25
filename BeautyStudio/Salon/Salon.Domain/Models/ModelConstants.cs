namespace Salon.Domain.Models
{
    public static class ModelConstants
    {
        public static class Service
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 100;
            public const int MinDescriptionLength = 10;
            public const int MaxDescriptionLength = 1000;
            public const int MinDuration = 5;
            public const int MaxDuration = 480;
        }

        public static class Employee
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;
        }

        public static class Appointment
        {
            public const int MinNotesLength = 0;
            public const int MaxNotesLength = 1000;
        }

        public static class Portfolio
        {
            public const int MinTitleLength = 3;
            public const int MaxTitleLength = 200;
            public const int MaxDescriptionLength = 2000;
        }

        public static class Client
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;
        }

        public static class Location
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 100;
            public const int MinAddressLength = 5;
            public const int MaxAddressLength = 200;
            public const int MinCityLength = 2;
            public const int MaxCityLength = 100;
            public const int MinCountryLength = 2;
            public const int MaxCountryLength = 100;
            public const int MinPhoneLength = 5;
            public const int MaxPhoneLength = 30;
            public const int MinTimeZoneLength = 3;
            public const int MaxTimeZoneLength = 100;
        }

        public static class Category
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 100;
            public const int MinDescriptionLength = 5;
            public const int MaxDescriptionLength = 500;
        }
    }
}
