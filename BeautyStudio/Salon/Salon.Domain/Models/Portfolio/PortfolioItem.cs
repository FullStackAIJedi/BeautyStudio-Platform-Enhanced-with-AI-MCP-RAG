namespace Salon.Domain.Models.Portfolio
{ 
    using Salon.Domain.Exceptions;
    using SharedKernel.Models;

    public class PortfolioItem : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<PortfolioVote> votes;
        private readonly HashSet<int> tagIds;

        internal PortfolioItem(
            int employeeId,
            int? serviceId,
            string title,
            string description,
            int locationId,
            string imageUrl,
            string? thumbnailUrl,
            DateTime serviceDate)
        {
            this.Validate(title, description, imageUrl);

            this.EmployeeId = employeeId;
            this.ServiceId = serviceId;
            this.Title = title;
            this.Description = description;
            this.LocationId = locationId;
            this.ImageUrl = imageUrl;
            this.ThumbnailUrl = thumbnailUrl;
            this.ServiceDate = serviceDate;
            this.IsPublished = true;
            this.IsFeatured = false;
            this.PositiveVotes = 0;
            this.NegativeVotes = 0;

            this.votes = new HashSet<PortfolioVote>();
            this.tagIds = new HashSet<int>();
        }

        private PortfolioItem()
        {
            this.Title = default!;
            this.Description = default!;
            this.ImageUrl = default!;
            this.votes = new HashSet<PortfolioVote>();
            this.tagIds = new HashSet<int>();
        }

        public int EmployeeId { get; private set; }
        public int? ServiceId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int LocationId { get; private set; }
        public string ImageUrl { get; private set; }
        public string? ThumbnailUrl { get; private set; }
        public DateTime ServiceDate { get; private set; }
        public bool IsPublished { get; private set; }
        public bool IsFeatured { get; private set; }
        public int PositiveVotes { get; private set; }
        public int NegativeVotes { get; private set; }

        public IReadOnlyCollection<PortfolioVote> Votes => this.votes.ToList().AsReadOnly();
        public IReadOnlyCollection<int> TagIds => this.tagIds.ToList().AsReadOnly();

        public void ApplyVote(int userId, int vote)
        {
            if (vote != 1 && vote != -1)
                throw new InvalidPortfolioException("Vote must be 1 or -1.");
             
            if (this.votes.Any(v => v.UserId == userId))
                throw new InvalidPortfolioException("User has already voted for this item.");

            var portfolioVote = new PortfolioVote(this.Id, userId, vote);
            this.votes.Add(portfolioVote);

            if (vote == 1) this.PositiveVotes++;
            else this.NegativeVotes++;

            this.AddEvent(new Events.PortfolioVoteCastEvent(this.Id, userId, vote));
        }

        public void AddTag(int tagId) => this.tagIds.Add(tagId);

        private void Validate(string title, string description, string imageUrl)
        {
            Guard.ForStringLength<InvalidPortfolioException>(
                title,
                ModelConstants.Portfolio.MinTitleLength,
                ModelConstants.Portfolio.MaxTitleLength,
                nameof(this.Title));

            Guard.ForStringLength<InvalidPortfolioException>(
                description,
                0,
                ModelConstants.Portfolio.MaxDescriptionLength,
                nameof(this.Description));

            Guard.AgainstEmptyString<InvalidPortfolioException>(imageUrl, nameof(this.ImageUrl));
        }
    }
}
