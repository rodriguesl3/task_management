using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Repository
{
    public interface IExternalTasksRepository
    {
        Task<bool> IsUniqueName(string name);
    }
}
