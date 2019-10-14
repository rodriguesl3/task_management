using Flurl.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Application;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repository;

namespace TaskManagement.Application.Implmentation
{
    public class TasksApplication : ITasksApplication
    {

        private readonly ITaskRepository _taskRepo;
        private static int _createTimes = 0;
        private static int _updateTimes = 0;
        private readonly object lockQuantity = new object();

        public TasksApplication(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasks()
        {
            return _taskRepo.GetAllTasks();
        }

        public async Task<Dictionary<string, int>> GetCreateUpdateTimes()
        {
            return new Dictionary<string, int>{
                { "create", _createTimes},
                { "update", _updateTimes}
            };
        }

        public async Task<Domain.Entities.Task> GetTaskById(int id)
        {
            return _taskRepo.GetByID(id);
        }

        public async Task<KeyValuePair<bool, string>> UpdateTask(Domain.Entities.Task taskObject)
        {
            var isUnique = await CheckUniquenessName(taskObject.Name);
            if (!isUnique)
                return new KeyValuePair<bool, string>(false, "task name already exisist");


            lock (lockQuantity)
            {
                var response = _taskRepo.Update(taskObject);
                if (response > 0)
                    _updateTimes++;
                return new KeyValuePair<bool, string>(true, "");
            }
        }

        public async Task<KeyValuePair<bool, string>> InsertTasks(Domain.Entities.Task taskObject)
        {
            var isUnique = await CheckUniquenessName(taskObject.Name);

            if (!isUnique)
                return new KeyValuePair<bool, string>(false, "task name already exisist");

            lock (lockQuantity)
            {
                var response = _taskRepo.Insert(taskObject);
                if (response > 0)
                    _createTimes++;
                return new KeyValuePair<bool, string>(true, "");
            }
        }


        private async Task<bool> CheckUniquenessName(string name)
        {
            try
            {
                var response = await $"http://taskmanagement.externalservice/api/check/{name}".GetAsync();
                var parseResponse = JToken.Parse(await response.Content.ReadAsStringAsync())["isUnique"];
                return Convert.ToBoolean(parseResponse ?? "false");
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
