using AutoMapper;
using Mentoria.Application.Dtos;
using Mentoria.Domain;
using Mentoria.Domain.Interfaces;

namespace Mentoria.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;


        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var entity = await _customerRepository.GetByIdAsync(id);
            var map = _mapper.Map<CustomerDto>(entity);
            return map;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var entities = await _customerRepository.GetAllAsync();
            var map = _mapper.Map<List<CustomerDto>>(entities);
            return map;
        }

        public async Task UpdateAsync(CustomerDto customer)
        {
            var entity = await _customerRepository.GetByIdAsync(customer.Id);
            if (entity == null)
            {
                throw new ArgumentOutOfRangeException(nameof(customer));
            }
            var map = _mapper.Map<Customer>(customer);
            await _customerRepository.UpdateAsync(map);
        }

        public async Task DeleteAsync(CustomerDto customer)
        {
            var entity = await _customerRepository.GetByIdAsync(customer.Id);
            if (entity == null)
            {
                throw new ArgumentOutOfRangeException(nameof(customer));
            }
            var map = _mapper.Map<Customer>(customer);
            await _customerRepository.DeleteAsync(map);
        }

        public async Task InsertAsync(CustomerDto customer)
        {
            var map = _mapper.Map<Customer>(customer);
            await _customerRepository.AddAsync(map);

        }

    }
}
