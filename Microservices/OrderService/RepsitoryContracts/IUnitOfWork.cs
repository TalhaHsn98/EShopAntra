using System;

namespace OrderService.RepositoryContracts
{

    public interface IUnitOfWork
    {
            Task<int> SaveChangesAsync();
    }


}
