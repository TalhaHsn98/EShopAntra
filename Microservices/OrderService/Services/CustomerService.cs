using AutoMapper;
using OrderService.DTO;
using OrderService.Models;
using OrderService.RepositoryContracts;
using OrderService.ServiceContracts;

namespace OrderService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(
            ICustomerRepository customerRepository,
            IUserAddressRepository userAddressRepository,
            IRepository<Address> addressRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _userAddressRepository = userAddressRepository;
            _addressRepository = addressRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CustomerAddressResponse>> GetCustomerAddressByUserIdAsync(int userId)
        {
            var customer = await _customerRepository.GetWithAddressesByUserIdAsync(userId);
            if (customer == null)
            {
                return new List<CustomerAddressResponse>();
            }

            var responses = new List<CustomerAddressResponse>();
            foreach (var link in customer.UserAddresses)
            {
                var dto = _mapper.Map<CustomerAddressResponse>(link.Address);
                dto.IsDefaultAddress = link.IsDefaultAddress;
                responses.Add(dto);
            }

            return responses;
        }

        public async Task<int> SaveCustomerAddressAsync(CustomerAddressSaveRequest request)
        {
            var customer = await _customerRepository.GetByUserIdAsync(request.UserId);
            if (customer == null)
            {
                customer = new Customer
                {
                    UserId = request.UserId,
                    FirstName = string.Empty,
                    LastName = string.Empty
                };
                await _customerRepository.AddAsync(customer);
                await _unitOfWork.SaveChangesAsync();
            }

            var address = _mapper.Map<Address>(request.Address);
            await _addressRepository.AddAsync(address);
            await _unitOfWork.SaveChangesAsync();

            if (request.IsDefaultAddress)
            {
                var existingDefault = await _userAddressRepository.GetDefaultByCustomerIdAsync(customer.Id);
                if (existingDefault != null)
                {
                    existingDefault.IsDefaultAddress = false;
                    await _userAddressRepository.UpdateAsync(existingDefault);
                }
            }

            var link = new UserAddress
            {
                CustomerId = customer.Id,
                AddressId = address.Id,
                IsDefaultAddress = request.IsDefaultAddress
            };
            await _userAddressRepository.AddAsync(link);
            await _unitOfWork.SaveChangesAsync();

            return address.Id;
        }
    }
}
