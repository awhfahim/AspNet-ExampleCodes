﻿using StockData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Domain.Repositories
{
    public interface ICompanyRepository : IRepositoryBase<Company, int>
    {
        Task<int> GetCompanyId(string tradeCode);
    }
}