using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public async Task Delete(T t)
        {
            _context.Remove(t);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetList()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Insert(T t)
        {
            _context.Add(t);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T t)
        {
            _context.Update(t);
            await _context.SaveChangesAsync();
        }
    }
}
