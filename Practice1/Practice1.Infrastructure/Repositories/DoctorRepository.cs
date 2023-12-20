﻿using Microsoft.EntityFrameworkCore;
using Practice1.Domain.Entities;
using Practice1.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Infrastructure.Repositories
{
    public class DoctorRepository : Repository<Doctor, Guid>, IDoctorRepository
    {
        public DoctorRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }

        public async Task<(IList<Doctor> records, int total, int totalDisplay)> GetTableDataAsync(string searchText, string orderBy, int pageIndex, int pageSize)
        {
             return await GetDynamicAsync(x => x.Name!.Contains(searchText),
                 orderBy, null, pageIndex, pageSize, true);
        }

        public async Task<bool> IsDuplicateAsync(string name, Guid? id = null)
        {
            if(id.HasValue)
            {
                return (await GetCountAsync(x => x.Id == id && x.Name == name)) > 0;
            }
            else
            {
                return (await GetCountAsync(x => x.Name == name)) > 0;
            }
        }
    }
}
