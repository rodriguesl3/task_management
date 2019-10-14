using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskDomain = TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Application
{
    public interface ITasksApplication
    {
        Task<IEnumerable<TaskDomain.Task>> GetAllTasks();
        Task<TaskDomain.Task> GetTaskById(int id);
        Task<KeyValuePair<bool, string>> InsertTasks(TaskDomain.Task taskObject);
        Task<KeyValuePair<bool, string>> UpdateTask(TaskDomain.Task taskObject);
        Task<Dictionary<string, int>> GetCreateUpdateTimes();
    }
}
