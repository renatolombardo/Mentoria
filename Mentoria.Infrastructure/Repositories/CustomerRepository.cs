using Mentoria.Domain;
using Mentoria.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mentoria.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Customer entity)
        {
            await _dataContext.Customers.AddAsync(entity);
            await SaveAsync();
        }

        public async Task UpdateAsync(Customer entity)
        {
            await Task.Run(() => _dataContext.Customers.Update(entity));
            await SaveAsync();
        }

        public async Task DeleteAsync(Customer entity)
        {
            await Task.Run(() => _dataContext.Customers.Remove(entity));
            await SaveAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _dataContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return Task.FromResult(_dataContext.Customers).Result;
        }

        private async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
