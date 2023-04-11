using Mentoria.Domain;

namespace Mentoria.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer entity);
        Task DeleteAsync(Customer entity);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task UpdateAsync(Customer entity);
    }
}