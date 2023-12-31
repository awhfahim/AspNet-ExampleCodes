﻿using Exam1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Domain.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<Category, Guid>
    {
    }
}
