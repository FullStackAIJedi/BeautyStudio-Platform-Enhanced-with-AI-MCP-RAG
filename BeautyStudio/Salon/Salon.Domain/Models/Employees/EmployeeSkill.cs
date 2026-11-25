namespace Salon.Domain.Models.Employees
{ 
    using SharedKernel.Models;

    public class EmployeeSkill : Entity<int>
    {
        public EmployeeSkill(int employeeId, string skillName, int skillLevel = 1)
        {
            this.EmployeeId = employeeId;
            this.SkillName = skillName;
            this.SkillLevel = skillLevel;
        }

        private EmployeeSkill() { }

        public int EmployeeId { get; set; }
        public string SkillName { get; private set; } = default!;
        public int SkillLevel { get; private set; }
        public int? VerifiedByEmployeeId { get; private set; }
        public DateTime? VerifiedAt { get; private set; }
    }
}
