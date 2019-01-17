using AspDotNetCoreSecurity.Models;
using AspDotNetCoreSecurity.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreSecurity.Controllers
{
    [RequireHttps]
    public class ConferenceController : Controller
    {
        private readonly ConferenceRepo _repo;

        public ConferenceController(ConferenceRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            //Below code can create task on remote machine
            //using (var taskService = new TaskService("serverName or IP", "userName", "domainName", "password"))
            //{
            //    var task = taskService.AddTask("Test4Task", QuickTriggerType.TaskRegistration, "notepad.exe", "c:\\testTask.txt", null, null, TaskLogonType.InteractiveToken, "Test 3 Task");
            //    task.Run();
                //#region Another way to create task
                //  //var taskDefinition = taskService.NewTask();
                //  //taskDefinition.RegistrationInfo.Description = "Test Task";
                //  ////taskDefinition.Triggers.Add(new)
                //  //taskDefinition.Actions.Add(new ExecAction("notepad.exe", "c:\\testTask.txt"));
                //  //taskService.RootFolder.RegisterTaskDefinition(@"Test1", taskDefinition);
                //#endregion
            //}
            //var process = new ProcessStartInfo();
            //process.FileName = @"C:\Users\shekharr\source\repos\TestAppForRemoteExe\TestAppForRemoteExe\bin\Debug\TestAppForRemoteExe.exe";
            //process.Arguments = @"""C:\Program Files\internet explorer\iexplore.exe"" www.google.com";
            //process.UseShellExecute = false;
            //var p1 = Process.Start(process,);
            //p1.WaitForExit();

            // Below code is working for remotely executing exe

            //var process = new ProcessStartInfo();
            //process.FileName = @"C:\PsExec64.exe";
            //process.Arguments = @"\\serverName -u domain\userName -p password C:\Testing\TestAppForRemoteExe.exe shekhar.txt";
            //var p1 = Process.Start(process);
            ViewBag.Title = "Organizer - Conference Overview";
            return View(_repo.GetAll());

        }

        public IActionResult Add()
        {
            ViewBag.Title = "Organizer - Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ConferenceModel model)
        {
            if (ModelState.IsValid)
                _repo.Add(model);

            return RedirectToAction("Index");
        }
    }
}
