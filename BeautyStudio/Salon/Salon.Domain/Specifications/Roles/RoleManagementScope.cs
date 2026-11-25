namespace Salon.Domain.Specifications.Roles
{
    public static class RoleManagementScope
    { 
        private static readonly Dictionary<int, int[]> Scope = new()
        {
            // Apprentice (1) – cannot manage any roles.
            [1] = Array.Empty<int>(),

            // Junior Assistant (2) – cannot manage any roles.
            [2] = Array.Empty<int>(),

            // Junior Stylist (3) – cannot manage any roles.
            [3] = Array.Empty<int>(),

            // Stylist (4) – cannot manage any roles.
            [4] = Array.Empty<int>(),

            // Senior Stylist (5) – cannot manage any roles.
            [5] = Array.Empty<int>(),

            // Top Stylist (6) – can manage roles 1-6.
            [6] = new[] { 1, 2, 3, 4, 5, 6 },

            // Head Stylist (7) – can manage roles 1-7.
            [7] = new[] { 1, 2, 3, 4, 5, 6, 7 },

            // Salon Manager (8) – can manage roles 1-8.
            [8] = new[] { 1, 2, 3, 4, 5, 6, 7, 8 },

            // Salon Director (9) – can manage roles 1-9.
            [9] = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },

            // Boss (10) – can manage all roles 1-10.
            [10] = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
        };

        /// <summary>
        /// Determines whether the specified RoleLevel can manage the rules of a given RoleId.
        /// </summary>
        public static bool CanManage(int actorRoleLevel, int targetRoleId)
        {
            if (!Scope.TryGetValue(actorRoleLevel, out var allowedRoleIds))
                return false;

            return allowedRoleIds.Contains(targetRoleId);
        }
    }
}