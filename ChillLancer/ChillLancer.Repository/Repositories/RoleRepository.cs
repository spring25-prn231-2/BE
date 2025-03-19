using ChillLancer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ChillLancerDbContext _context;
        public RoleRepository(ChillLancerDbContext context)
        {
            _context = context;
        }
        public List<string> GetPermissionSlugsByRoleId(string role)
        {
            return ChillLancerDbContext.GetPermissionsById(role);
        }
    }
}
