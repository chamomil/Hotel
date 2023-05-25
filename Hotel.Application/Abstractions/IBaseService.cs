using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Abstractions
{
    public interface IBaseService<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T> DeleteAsync(int id);
        Task GetConnections();
    }
}
