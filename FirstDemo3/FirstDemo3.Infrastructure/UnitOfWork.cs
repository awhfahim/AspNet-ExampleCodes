using FirstDemo3.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo3.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
		private DbContext _dbContext;

		public UnitOfWork(DbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public void Save() => _dbContext.SaveChanges();
		public void Dispose() => _dbContext.Dispose();
	}

}
