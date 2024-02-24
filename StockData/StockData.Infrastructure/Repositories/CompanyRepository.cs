using Microsoft.EntityFrameworkCore;
using StockData.Domain.Entities;
using StockData.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }

        public async Task<int> GetCompanyId(string tradeCode)
        {
            var r = await GetAsync(x => x.TradeCode == tradeCode, null);
            return r.FirstOrDefault()!.Id;
        }
    }
}
