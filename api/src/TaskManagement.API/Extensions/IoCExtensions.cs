using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Domain.Application;
using TaskManagement.Domain.Repository;

namespace TaskManagement.API.Extensions
{
    public static class IoCExtensions
    {
        public static void ContainerInjection(this IServiceCollection services)
        {
            services.AddTransient<ITasksApplication, Application.Implmentation.TasksApplication>();
            services.AddTransient<ITaskRepository, Repository.Repository.TasksRepository>();
        }
    }
}
