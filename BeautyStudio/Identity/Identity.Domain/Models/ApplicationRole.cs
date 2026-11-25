namespace Identity.Domain.Models
{ 
    using Identity.Domain.Exceptions;

    using SharedKernel.Models;

    public class ApplicationRole : Entity<int>
    {
        public ApplicationRole(string name, int roleLevel, string? description = null)
        {
            this.Validate(name, roleLevel);
            this.Name = name;
            this.RoleLevel = roleLevel;
            this.Description = description;
        }

        private ApplicationRole()
        {
            this.Name = default!;
        }

        public string Name { get; private set; }
        public int RoleLevel { get; private set; } // 0-10, Titles
        public string? Description { get; private set; }

        private void Validate(string name, int roleLevel)
        {
            Guard.ForStringLength<InvalidRoleException>(
                name,
                ModelConstants.Role.MinNameLength,
                ModelConstants.Role.MaxNameLength,
                nameof(this.Name));

            Guard.AgainstOutOfRange<InvalidRoleException>(
                roleLevel,
                0,
                10,
                nameof(this.RoleLevel));
        }
    }
}
