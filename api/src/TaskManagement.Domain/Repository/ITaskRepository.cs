using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TaskDomain = TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Repository
{
    public interface ITaskRepository
    {
        IEnumerable<TaskDomain.Task> GetAllTasks();
        void Delete(object id);
        IEnumerable<TaskDomain.Task> Get(Expression<Func<TaskDomain.Task, bool>> filter = null);
        TaskDomain.Task GetByID(object id);
        IEnumerable<TaskDomain.Task> GetWithRawSql(string query,
            params object[] parameters);
        int Insert(TaskDomain.Task entity);
        int Update(TaskDomain.Task entityToUpdate);
    }
}
