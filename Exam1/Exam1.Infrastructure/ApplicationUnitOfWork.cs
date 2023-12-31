using Exam1.Application;
using Exam1.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IProductRepository ProductRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext, IProductRepository productRepository, ICategoryRepository categoryRepository) 
            : base((DbContext)dbContext)
        {
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
        }

    }
}
