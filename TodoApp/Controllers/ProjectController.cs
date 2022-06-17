using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using LogicLayer.services;
using TodoApp.Models;
using LogicLayer.Intities;
using LogicLayer.Exceptions;
using log4net;
using TodoApp.entity;
using System;

namespace TodoApp.Controllers
{
    public class ProjectController : Controller
    {
        private static ILog loggerProject;
        private ProjectService service;
        private TaskService taskService;

        public ProjectController(ProjectService service, TaskService tService, ILog logger)
        {
            this.service = service;
            this.taskService = tService;
            loggerProject = logger;
        }

        [HttpGet]
        public ActionResult Index(bool error = false)
        {
            List<ProjectDTO> projects = service.getProjects().OrderBy(s => s.idProject).ToList();
            loggerProject.Info("getting all projects");
            ViewData["error"] = error;
            return View(projects);
        }



        [HttpPost]
        public JsonResult create(string name)
        {
            service.insert(name);
            loggerProject.Info($"create new project {name}");
            return Json(new Status(200));
        }

        [HttpPost]
        public JsonResult finish(int id)
        {
            service.finish(id);
            loggerProject.Info($"comlited project #{id}");
            return Json(new Status(200));
        }

        [HttpPost]
        public JsonResult finishTask(int id)
        {
            taskService.finish(id);
            loggerProject.Info($"comlited task #{id}");
            return Json(new Status(200));
        }

        [HttpPost]
        public JsonResult delete(int id)
        {
            service.delete(id);
            loggerProject.Info($"deleted project #{id}");
            return Json(new Status(200));
        }

        [HttpPost]
        public JsonResult deleteTask(int id)
        {
            taskService.delete(id);
            loggerProject.Info($"deleted task #{id}");
            return Json(new Status(200));
        }

        [HttpGet]
        public ActionResult details(int id)
        {
            ProjectDTO project = service.getProjectById(id);
            if (!project.isEmpty())
            {
                List<TaskDTO> tasks = taskService.getAll(id).OrderBy(s => s.date).ToList();
                ProjectDetails details = new ProjectDetails(project, tasks);
                loggerProject.Info($"getting info about project #{id}");
                return View(details);
            }
            return RedirectToAction("Index", new { error = true });
        }

        [HttpPost]
        public JsonResult rename(int id, string name)
        {
            service.rename(id, name);
            loggerProject.Info($"renamed project #{id}");
            return Json(new Status(200));
        }

        [HttpPost]
        public JsonResult renameTask(int id, string name)
        {
            taskService.rename(id, name);
            loggerProject.Info($"renamed task #{id}");
            return Json(new Status(200));
        }

        [HttpPost]
        public JsonResult createTask(int id, string name)
        {
            taskService.insert(id, name);
            loggerProject.Info($"created task #{name} at project #{id}");
            return Json(new Status(200));
        }

        [HttpGet]
        public ActionResult detailsTask(int id)
        {
            TaskDTO task = taskService.getById(id);
            if (!task.isEmpty())
            {
                loggerProject.Info($"getting info about task #{id}");
                return View(task);
            }
            return RedirectToAction("Index", new { error = true });
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            loggerProject.Error(filterContext.Exception.Message);
            if (filterContext.Exception != null)
            {
                filterContext.Result = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new Status(509, filterContext.Exception.Message)
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}