using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.Repository.Interfaces
{
    public interface IRoleRepository
    {
        List<string> GetPermissionSlugsByRoleId(string role);
    }
}
