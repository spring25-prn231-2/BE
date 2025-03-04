using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.Repository.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly ChillLancerDbContext _context;
        public TransactionRepository(ChillLancerDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
