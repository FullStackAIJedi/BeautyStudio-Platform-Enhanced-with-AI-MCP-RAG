namespace Salon.Domain.Models.Portfolio
{ 
    using SharedKernel.Models;

    public class PortfolioTag : Entity<int>
    {
        internal PortfolioTag(string name, int tagType)
        {
            this.Name = name;
            this.TagType = tagType;
            this.IsActive = true;
        }

        private PortfolioTag() { }

        public string Name { get; private set; } = default!;
        public int TagType { get; private set; }
        public bool IsActive { get; private set; }
    }

    public static class PortfolioTagType
    {
        public const int Service = 1;
        public const int Product = 2;
        public const int Brand = 3;
        public const int Color = 4;
        public const int Procedure = 5;
        public const int Technique = 6;
    }
}
