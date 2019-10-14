using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TaskManagement.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using TaskDomain = TaskManagement.Domain.Entities;
using System.Threading.Tasks;

namespace TaskManagement.Repository.Repository
{
    public class TasksRepository : ITaskRepository, IExternalTasksRepository
    {
        private Context.TaskContext _db;
        public TasksRepository(Context.TaskContext db)
        {
            _db = db;
        }

        public void Delete(TaskDomain.Task entityToDelete)
        {
            _db.Tasks.Remove(entityToDelete);
            var result = _db.SaveChanges();
        }

        public void Delete(object id)
        {
            var task = _db.Tasks.Find(id);
            _db.Tasks.Remove(task);
            var result = _db.SaveChanges();
        }

        public IEnumerable<TaskDomain.Task> Get(Expression<Func<TaskDomain.Task, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskDomain.Task> GetAllTasks()
        {
            return _db.Tasks.ToList();
        }

        public TaskDomain.Task GetByID(object id)
        {
            return _db.Tasks.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
        }

        public IEnumerable<TaskDomain.Task> GetWithRawSql(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public int Insert(TaskDomain.Task entity)
        {
            _db.Tasks.Add(entity);
            return _db.SaveChanges();
        }

        public async Task<bool> IsUniqueName(string name)
        {
            var isUnique = !(await _db.Tasks.AnyAsync(x => x.Name.ToLower() == name.ToLower()));
            return isUnique;
        }

        public int Update(TaskDomain.Task entityToUpdate)
        {



            _db.Entry(entityToUpdate).State = EntityState.Modified;
            return _db.SaveChanges();
        }
    }
}
