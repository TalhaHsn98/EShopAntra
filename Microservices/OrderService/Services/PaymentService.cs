using AutoMapper;
using OrderService.DTO;
using OrderService.Models;
using OrderService.RepositoryContracts;
using OrderService.ServiceContracts;

namespace OrderService.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<PaymentType> _typesRepo;
        private readonly IPaymentMethodRepository _methodsRepo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PaymentService(IRepository<PaymentType> typesRepo, IPaymentMethodRepository methodsRepo, IUnitOfWork uow, IMapper mapper)
        {
            _typesRepo = typesRepo; _methodsRepo = methodsRepo; _uow = uow; _mapper = mapper;
        }

        public async Task<List<PaymentTypeResponse>> ListTypesAsync()
            => (await _typesRepo.ListAsync()).Select(_mapper.Map<PaymentTypeResponse>).ToList();

        public async Task<int> CreateTypeAsync(PaymentTypeRequest dto)
        {
            var entity = _mapper.Map<PaymentType>(dto);
            await _typesRepo.AddAsync(entity);
            await _uow.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<List<PaymentMethodResponse>> GetMethodsByCustomerAsync(int customerId)
            => (await _methodsRepo.GetByCustomerAsync(customerId)).Select(_mapper.Map<PaymentMethodResponse>).ToList();

        public async Task<int> SaveMethodAsync(PaymentMethodRequest dto)
        {
            PaymentMethod entity;
            if (dto.Id.HasValue)
            {
                entity = await _methodsRepo.GetByIdAsync(dto.Id.Value) ?? new PaymentMethod();
                entity.PaymentTypeId = dto.PaymentTypeId;
                entity.Provider = dto.Provider;
                entity.AccountNumber = dto.AccountNumber;
                entity.Expiry = dto.Expiry;
                entity.IsDefault = dto.IsDefault;
                entity.CustomerId = dto.CustomerId;
                await _methodsRepo.UpdateAsync(entity);
            }
            else
            {
                entity = _mapper.Map<PaymentMethod>(dto);
                await _methodsRepo.AddAsync(entity);
            }

            if (entity.IsDefault)
            {
                var existingDefault = await _methodsRepo.GetDefaultForCustomerAsync(entity.CustomerId);
                if (existingDefault != null && existingDefault.Id != entity.Id)
                {
                    existingDefault.IsDefault = false;
                    await _methodsRepo.UpdateAsync(existingDefault);
                }
            }

            await _uow.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteMethodAsync(int id)
        {
            var entity = await _methodsRepo.GetByIdAsync(id);
            if (entity is null) return false;
            await _methodsRepo.DeleteAsync(entity);
            await _uow.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SetDefaultAsync(int id)
        {
            var entity = await _methodsRepo.GetByIdAsync(id);
            if (entity is null) return false;
            var existingDefault = await _methodsRepo.GetDefaultForCustomerAsync(entity.CustomerId);
            if (existingDefault != null && existingDefault.Id != entity.Id)
            {
                existingDefault.IsDefault = false;
                await _methodsRepo.UpdateAsync(existingDefault);
            }
            entity.IsDefault = true;
            await _methodsRepo.UpdateAsync(entity);
            await _uow.SaveChangesAsync();
            return true;
        }
    }
}
