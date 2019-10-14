using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Application
{
    public interface IExternalTasksApplication
    {
        Task<bool> IsUniqueName(string name);
    }
}
