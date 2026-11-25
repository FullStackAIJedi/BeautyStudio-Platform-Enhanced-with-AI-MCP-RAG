namespace Salon.Domain.Models.Employees
{
    using Salon.Domain.Exceptions;
    using SharedKernel.Models;

    public class Employee : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<EmployeeSkill> skills;
        private readonly HashSet<EmployeeCertification> certifications;

        internal Employee(
            int userId,
            string firstName,
            string lastName,
            int roleId,
            int locationId,
            string? bio = null,
            string? profilePhotoUrl = null)
        {
            this.Validate(firstName, lastName, roleId);

            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.RoleId = roleId;
            this.LocationId = locationId;
            this.Bio = bio;
            this.ProfilePhotoUrl = profilePhotoUrl;
            this.ExperienceYears = 0;
            this.EmploymentStatus = 1;
            this.CanReceiveAppointments = true;
            this.IsVisibleInBooking = true;
            this.Points = 0;

            this.skills = new HashSet<EmployeeSkill>();
            this.certifications = new HashSet<EmployeeCertification>();
        }

        private Employee()
        {
            this.FirstName = default!;
            this.LastName = default!;
            this.skills = new HashSet<EmployeeSkill>();
            this.certifications = new HashSet<EmployeeCertification>();
        }

        public int LocationId { get; private set; }    

        public int UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int RoleId { get; private set; }
        public string? Bio { get; private set; }
        public string? ProfilePhotoUrl { get; private set; }
        public int ExperienceYears { get; private set; }
        public int EmploymentStatus { get; private set; }
        public bool CanReceiveAppointments { get; private set; }
        public bool IsVisibleInBooking { get; private set; }
        public int Points { get; private set; }

        public IReadOnlyCollection<EmployeeSkill> Skills => this.skills.ToList().AsReadOnly();
        public IReadOnlyCollection<EmployeeCertification> Certifications => this.certifications.ToList().AsReadOnly();

        public void UpdateProfile(string firstName, string lastName, string? bio, string? photoUrl)
        {
            this.ValidateName(firstName, nameof(this.FirstName));
            this.ValidateName(lastName, nameof(this.LastName));

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Bio = bio;
            this.ProfilePhotoUrl = photoUrl;
        }

        public void ChangeRole(int roleId)
        {
            Guard.AgainstOutOfRange<InvalidEmployeeException>(roleId, 1, 10, nameof(this.RoleId));
            this.RoleId = roleId;
        }

        public void ChangeLocation(int locationId)
        {
            this.LocationId = locationId;
        }

        public void AdjustPoints(int delta, int reason, string? description, int createdByUserId)
        {
            this.Points += delta;
        }

        public void AddSkill(EmployeeSkill skill) => this.skills.Add(skill);
        public void AddCertification(EmployeeCertification cert) => this.certifications.Add(cert);

        private void Validate(string firstName, string lastName, int roleId)
        {
            this.ValidateName(firstName, nameof(this.FirstName));
            this.ValidateName(lastName, nameof(this.LastName));
            Guard.AgainstOutOfRange<InvalidEmployeeException>(roleId, 1, 10, nameof(this.RoleId));
        }

        private void ValidateName(string name, string propertyName)
            => Guard.ForStringLength<InvalidEmployeeException>(
                name,
                ModelConstants.Employee.MinNameLength,
                ModelConstants.Employee.MaxNameLength,
                propertyName);
    }
}
