using Task.Infra.Contexts;
using Task.Infra.Repositories;
using TaskManager.Shared;
using TasksManager.Domain.Models.Tasks;
using Unity;
using Unity.Lifetime;

namespace DependencyResolver
{
    public class Resolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<TaskDataContext, TaskDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IVerify, Verify>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserTaskRepository, UserTaskRepository>(new HierarchicalLifetimeManager());
        }
    }
}
