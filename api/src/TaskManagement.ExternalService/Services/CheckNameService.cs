using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Domain.Application;
using TaskManagement.Domain.Repository;

namespace TaskManagement.ExternalService.Services
{
    public class CheckNameService : IExternalTasksApplication
    {
        private readonly IExternalTasksRepository _externalRepo;

        public CheckNameService(IExternalTasksRepository externalRepo)
        {
            _externalRepo = externalRepo;
        }

        public async Task<bool> IsUniqueName(string name)
        {
            return await _externalRepo.IsUniqueName(name);
        }
    }
}
