using Microsoft.Extensions.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using LogicLayer.services;
using log4net;
using TodoApp.Controllers;

namespace TodoApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            string connection = GetConnectionString();

            ILog logger = LogManager.GetLogger(typeof(ProjectController));
            container.RegisterInstance<ILog>(logger);

            container.RegisterInstance(new ProjectService(connection));
            container.RegisterInstance(new TaskService(connection));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static string GetConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
.AddJsonFile("App_Data/ConnectionSettings.json", optional: true)
.Build();
            return $"DATA SOURCE={configuration["source"]};PASSWORD={configuration["password"]};USER ID={configuration["id"]};Persist Security Info={configuration["security_info"]}";
        }
    }
}