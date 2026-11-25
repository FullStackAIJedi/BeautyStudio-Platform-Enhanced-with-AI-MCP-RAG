namespace Salon.Domain.Models.Clients
{
    using Salon.Domain.Exceptions;
    using SharedKernel.Models;

    public class Client : Entity<int>, IAggregateRoot
    {
        internal Client(
            int userId,
            string firstName,
            string lastName,
            string? email = null,
            string? phone = null)
        {
            this.Validate(firstName, lastName);

            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.AvailablePoints = 0;
            this.LifetimePoints = 0;
            this.TotalVisits = 0;
            this.Status = 1;
        }

        private Client()
        {
            this.FirstName = default!;
            this.LastName = default!;
        }

        public void UpdateProfile(string? firstName, string? lastName, string? phone)
        {
            if (firstName != null) this.FirstName = firstName;
            if (lastName != null) this.LastName = lastName;
            if (phone != null) this.Phone = phone;
        }

        public void UpdateHairProfile(
            string? hairType,
            string? hairLength,
            string? hairColor,
            string? scalpType,
            string? allergies,
            string? sensitivities)
        {
            if (hairType != null) this.HairType = hairType;
            if (hairLength != null) this.HairLength = hairLength;
            if (hairColor != null) this.HairColor = hairColor;
            if (scalpType != null) this.ScalpType = scalpType;
            if (allergies != null) this.Allergies = allergies;
            if (sensitivities != null) this.Sensitivities = sensitivities;
        }

        public int UserId { get; private set; } 
        public string FirstName { get; private set; } // Available for client update
        public string LastName { get; private set; } // Available for client update
        public string? Email { get; private set; } // Available for client update
        public string? Phone { get; private set; } // Available for client update
        public string? Notes { get; private set; } // Available for client update
        public string? HairType { get; private set; } // Available for client update
        public string? HairLength { get; private set; } // Available for client update
        public string? HairColor { get; private set; } // Available for client update
        public string? ScalpType { get; private set; } // Available for client update
        public string? Allergies { get; private set; } // Available for client update
         
        public string? Sensitivities { get; private set; } 
        public int AvailablePoints { get; private set; }
        public int LifetimePoints { get; private set; }
        public int? ClientLevelId { get; private set; }
        public int TotalVisits { get; private set; }
        public int TotalSpentMinor { get; private set; }
        public int Status { get; private set; }

        public void UpdateNotes(string notes) => this.Notes = notes;

        public void AddPoints(int points, int reason)
        {
            this.AvailablePoints += points;
            this.LifetimePoints += points;
        }

        public void RedeemPoints(int points)
        {
            if (points > this.AvailablePoints)
                throw new InvalidClientException("Not enough available points.");

            this.AvailablePoints -= points;
        }

        public void RecordVisit(int spentMinor)
        {
            this.TotalVisits++;
            this.TotalSpentMinor += spentMinor;
        }

        private void Validate(string firstName, string lastName)
        {
            Guard.ForStringLength<InvalidClientException>(
                firstName,
                ModelConstants.Client.MinNameLength,
                ModelConstants.Client.MaxNameLength,
                nameof(this.FirstName));

            Guard.ForStringLength<InvalidClientException>(
                lastName,
                ModelConstants.Client.MinNameLength,
                ModelConstants.Client.MaxNameLength,
                nameof(this.LastName));
        }
    }
}
