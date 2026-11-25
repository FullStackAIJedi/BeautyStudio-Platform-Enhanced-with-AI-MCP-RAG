namespace Salon.Domain.Models.Locations
{ 
    using Salon.Domain.Exceptions;

    using SharedKernel.Models;

    public class Location : Entity<int>, IAggregateRoot
    {
        internal Location(
            string name,
            string address,
            string city,
            string country,
            string phone,
            string timeZone,
            string workingHours,
            bool isAvailable = true)
        {
            this.Validate(name, address, city, country, phone, timeZone, workingHours);

            this.Name = name;
            this.Address = address;
            this.City = city;
            this.Country = country;
            this.Phone = phone;
            this.TimeZone = timeZone;
            this.WorkingHours = workingHours;
            this.IsAvailable = isAvailable;
            this.CreatedAt = DateTime.UtcNow;
        }

        private Location()
        {
            this.Name = default!;
            this.Address = default!;
            this.City = default!;
            this.Country = default!;
            this.Phone = default!;
            this.TimeZone = default!;
            this.WorkingHours = default!;
        }

        public string Name { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Phone { get; private set; }
        public string TimeZone { get; private set; }
        public string WorkingHours { get; private set; }   // JSON: {"mon":"09:00-18:00",...}
        public bool IsAvailable { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
         
        // public IReadOnlyCollection<Employee> Employees => ...
        // public IReadOnlyCollection<Appointment> Appointments => ...

        public Location UpdateName(string name)
        {
            this.ValidateName(name);
            this.Name = name;
            this.Touch();
            return this;
        }

        public Location UpdateAddress(string address, string city, string country)
        {
            this.ValidateAddress(address, city, country);
            this.Address = address;
            this.City = city;
            this.Country = country;
            this.Touch();
            return this;
        }

        public Location UpdateContact(string phone)
        {
            this.ValidatePhone(phone);
            this.Phone = phone;
            this.Touch();
            return this;
        }

        public Location UpdateWorkingHours(string workingHours)
        {
            this.ValidateWorkingHours(workingHours);
            this.WorkingHours = workingHours;
            this.Touch();
            return this;
        }

        public Location UpdateTimeZone(string timeZone)
        {
            this.ValidateTimeZone(timeZone);
            this.TimeZone = timeZone;
            this.Touch();
            return this;
        }

        public Location SetAvailability(bool isAvailable)
        {
            this.IsAvailable = isAvailable;
            this.Touch();
            return this;
        }

        private void Touch() => this.UpdatedAt = DateTime.UtcNow;

        private void Validate(string name, string address, string city, string country,
            string phone, string timeZone, string workingHours)
        {
            this.ValidateName(name);
            this.ValidateAddress(address, city, country);
            this.ValidatePhone(phone);
            this.ValidateTimeZone(timeZone);
            this.ValidateWorkingHours(workingHours);
        }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidLocationException>(
                name,
                ModelConstants.Location.MinNameLength,
                ModelConstants.Location.MaxNameLength,
                nameof(this.Name));

        private void ValidateAddress(string address, string city, string country)
        {
            Guard.ForStringLength<InvalidLocationException>(
                address,
                ModelConstants.Location.MinAddressLength,
                ModelConstants.Location.MaxAddressLength,
                nameof(this.Address));
            Guard.ForStringLength<InvalidLocationException>(
                city,
                ModelConstants.Location.MinCityLength,
                ModelConstants.Location.MaxCityLength,
                nameof(this.City));
            Guard.ForStringLength<InvalidLocationException>(
                country,
                ModelConstants.Location.MinCountryLength,
                ModelConstants.Location.MaxCountryLength,
                nameof(this.Country));
        }

        private void ValidatePhone(string phone)
            => Guard.ForStringLength<InvalidLocationException>(
                phone,
                ModelConstants.Location.MinPhoneLength,
                ModelConstants.Location.MaxPhoneLength,
                nameof(this.Phone));

        private void ValidateTimeZone(string timeZone)
            => Guard.ForStringLength<InvalidLocationException>(
                timeZone,
                ModelConstants.Location.MinTimeZoneLength,
                ModelConstants.Location.MaxTimeZoneLength,
                nameof(this.TimeZone));

        private void ValidateWorkingHours(string workingHours)
            => Guard.AgainstEmptyString<InvalidLocationException>(
                workingHours,
                nameof(this.WorkingHours));
    }
}
