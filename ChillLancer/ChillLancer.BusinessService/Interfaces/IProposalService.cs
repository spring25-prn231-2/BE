using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface IProposalService
    {
        Task<bool> Add(ProposalBM inputData);
        Task<List<ProposalBM>> GetAll();
        Task<bool> Delete(Guid proposalId);
    }
}
