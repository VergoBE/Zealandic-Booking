using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zealandic_Booking.Interfaces;
using Zealandic_Booking.Models;

namespace Zealandic_Booking.Services
{
    public class DBService<T> : IDBService<T> where T : class
    {
        public async Task<IEnumerable<T>> GetObjectsAsync()
        {
            using (var context = new ZBDBContext())
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }

        }

        public async Task AddObjectAsync(T obj)
        {
            using (var context = new ZBDBContext())
            {
                context.Set<T>().Add(obj);
                context.SaveChanges();
            }
        }

        public async Task DeleteObjectAsync(T obj)
        {
            using (var context = new ZBDBContext())
            {
                context.Set<T>().Remove(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateObjectAsync(T obj)
        {
            using (var context = new ZBDBContext())
            {
                context.Set<T>().Update(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task<T> GetObjectByIdAsync(int id)
        {
            using (var context = new ZBDBContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }
    }
}
