namespace Salon.Domain.Models.Roles
{
    public class RoleRule
    {
        public RoleRule(int roleId, int type, int code)
        {
            this.RoleId = roleId;
            this.Type = type;
            this.Code = code;
        }

        private RoleRule() { }

        public int RoleId { get; private set; }
        public int Type { get; private set; } // 1 = Permission, 2 = Responsibility
        public int Code { get; private set; }
    }
}
