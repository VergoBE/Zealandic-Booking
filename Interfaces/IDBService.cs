using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zealandic_Booking.Interfaces
{
    public class IDBService<T>
    {
        Task<IEnumerable<T>> GetObjectsAsync();
        Task AddObjectAsync(T obj);
        Task DeleteObjectAsync(T obj);
        Task UpdateObjectAsync(T obj);
        Task<T> GetObjectByIdAsync(int id);
    }
}
