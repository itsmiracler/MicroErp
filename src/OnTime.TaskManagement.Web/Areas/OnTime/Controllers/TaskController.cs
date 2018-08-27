using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Merp.Web.Site.Areas.OnTime.WorkerServices;
using Merp.Web.Site.Areas.OnTime.Model.Task;

namespace Merp.Web.Site.Areas.OnTime.Controllers
{
    [Area("OnTime")]
    [Authorize(Roles ="TaskManagement")]
    public class TaskController : Controller
    {
        public TaskControllerWorkerServices WorkerServices { get; private set; }

        public TaskController(TaskControllerWorkerServices workerServices)
        {
            if (workerServices == null)
                throw new ArgumentNullException(nameof(workerServices));

            WorkerServices = workerServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<IncompleteViewModel> Backlog()
        {
            return WorkerServices.GetBacklogModel();
        }

        [HttpGet]
        public IEnumerable<IncompleteViewModel> NextSevenDays()
        {
            return WorkerServices.GetNextSevenDaysModel();
        }

        [HttpGet]
        public IEnumerable<IncompleteViewModel> Today()
        {
            return WorkerServices.GetTodayModel();
        }

        [HttpPost]
        public IActionResult Create(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return BadRequest();

            try
            {
                WorkerServices.Create(text);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult MarkAsComplete(Guid? id)
        {
            if (!id.HasValue)
                return BadRequest();

            try
            {
                WorkerServices.MarkAsComplete(id.Value);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
                return BadRequest();

            try
            {
                WorkerServices.Delete(id.Value);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}