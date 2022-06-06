using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zealandic_Booking.Services
{
    public interface IDBService<T> where T : class
    {
        Task<IEnumerable<T>> GetObjectsAsync();
        Task AddObjectAsync(T obj);
        Task DeleteObjectAsync(T obj);
        Task UpdateObjectAsync(T obj);
        Task<T> GetObjectByIdAsync(int id);
    }
}