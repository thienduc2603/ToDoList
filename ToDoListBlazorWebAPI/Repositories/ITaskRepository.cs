using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListModels;
using Task = ToDoListBlazorWebAPI.Entities.Task;

namespace ToDoListBlazorWebAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetTaskList();
        Task<Task> CreateTask(Task task);
        Task<Task> UpdateTask(Task task);
        Task<Task> DeleteTask(Task task);
        Task<Task> GetTaskById(Guid id);
    }
}
