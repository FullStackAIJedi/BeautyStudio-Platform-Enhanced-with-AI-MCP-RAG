namespace Salon.Infrastructure.Persistence.InitialData
{ 
    using Salon.Domain.Models.Roles;

    public class RoleRulesInitialData : IInitialData
    {
        public Type EntityType => typeof(RoleRule);

        public IEnumerable<object> GetData()
        { 
            var rules = new List<RoleRule>();
             
            rules.Add(new RoleRule(1, 1, 1001)); // VIEW_OWN_PROFILE
            rules.Add(new RoleRule(1, 1, 1002)); // EDIT_OWN_PROFILE
            rules.Add(new RoleRule(1, 1, 1003)); // CHANGE_OWN_PASSWORD
            rules.Add(new RoleRule(1, 2, 2001)); // CLEAN_WORKSTATION
            rules.Add(new RoleRule(1, 2, 2002)); // DISINFECT_TOOLS

            // Role 10 (Boss)  
            for (int code = 1001; code <= 1164; code++)
            {
                rules.Add(new RoleRule(10, 1, code));
            }

            return rules;
        }
    }
}
