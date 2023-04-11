using Mentoria.Application.Dtos;

namespace Mentoria.Application.Services
{
    public interface ICustomerService
    {
        Task DeleteAsync(CustomerDto customer);
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByIdAsync(int id);
        Task InsertAsync(CustomerDto customer);
        Task UpdateAsync(CustomerDto customer);
    }
}