namespace Shop.Domain.Models
{
    public static class ModelConstants
    {
        public static class Product
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 200;
            public const int MinDescriptionLength = 0;
            public const int MaxDescriptionLength = 2000;
        }

        public static class Cart
        {
            public const int MaxItems = 100;
            public const int MaxQuantityPerItem = 100;
        }

        public static class Payment
        {
            public const int MaxIdempotencyKeyLength = 100;
        }

        public static class Order
        {
            public const int MaxOrderNumberLength = 50;
        }
    }
}
