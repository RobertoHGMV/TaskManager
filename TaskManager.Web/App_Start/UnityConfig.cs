using System.Web.Mvc;
using TaskManager.Shared;
using Unity;
using Unity.Mvc5;
using TaskManager.Infra.Contexts;
using TaskManager.Domain.Models.Tasks;
using TaskManager.Infra.Repositories;

namespace TaskManager.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<TaskDataContext, TaskDataContext>();
            container.RegisterType<IVerify, Verify>();
            container.RegisterType<IUserTaskRepository, UserTaskRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}