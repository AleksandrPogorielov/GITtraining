using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebApplication1.DAL
{
    public abstract class BaseRepository<T> where T:class
    {
        protected readonly IDbContext _context;

        public BaseRepository(IDbContext context)
        {
            _context = context;
        }

        public virtual void Add(T entry)
        {
            _context.Set<T>().Add(entry);            
                _context.SaveChanges();            
        }

        public virtual void Delete(T entry)
        {
            _context.Entry(entry).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Update(T entry)
        {
            _context.Entry(entry).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        
    }
}