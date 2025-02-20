﻿using Entities.Models;
using Lamar;

namespace DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContainer _container;

        private readonly EventsDatabaseContext _context;

        public UnitOfWork(IContainer container, EventsDatabaseContext context)
        {
            _context = context;
            _container = container;
        }


        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            return _container.GetInstance<TRepository>();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
      
}
