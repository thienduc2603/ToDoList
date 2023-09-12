using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoListBlazorWebAPI.Entities;
using ToDoListBlazorWebAPI.Repositories;
using ToDoListModels;
using ToDoListModels.Enums;
using Task = ToDoListBlazorWebAPI.Entities.Task;

namespace ToDoListBlazorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskRepository.GetTaskList();
            var taskDtos = tasks.Select(x => new TaskDto()
            {
                Status = x.Status,
                TaskName = x.TaskName,
                AssigneeId = x.AssigneeId,
                CreatedDate = x.CreatedDate,
                Priority = x.Priority,
                Id = x.Id,
                AssgineeName =x.Assignee!=null? x.Assignee.FirstName + ' ' + x.Assignee.LastName : "N/A"
            });
            return Ok(taskDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var task = await _taskRepository.CreateTask(new Task()
            {
                TaskName = request.TaskName,
                Priority = request.Priority,
                Status = Status.Open,
                CreatedDate = DateTime.Now,
                Id = request.Id
            });
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id}, task);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTaskById([FromRoute]Guid id)
        {
            var task = await _taskRepository.GetTaskById(id);
            if (task == null)
                return NotFound($"{id} is not found");
            return Ok(new TaskDto()
            {
                TaskName = task.TaskName,
                Status = task.Status,
                Priority = task.Priority,
                AssigneeId = task.AssigneeId,
                Id = task.Id,
                CreatedDate = task.CreatedDate
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, TaskUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existedTask = await _taskRepository.GetTaskById(id);

            if (existedTask == null)
                return NotFound($"{id} is not found");

            existedTask.TaskName = request.TaskName;
            existedTask.Priority = request.Priority;

            var tasks = await _taskRepository.UpdateTask(existedTask);

            return Ok(new TaskDto()
            {
                TaskName = tasks.TaskName,
                Status = tasks.Status,
                Priority = tasks.Priority,
                AssigneeId = tasks.AssigneeId,
                Id = tasks.Id,
                CreatedDate = tasks.CreatedDate
            });
        }
    }
}
