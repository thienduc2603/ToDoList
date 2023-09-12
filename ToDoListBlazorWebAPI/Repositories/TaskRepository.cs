using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListBlazorWebAPI.Data;
using Task = ToDoListBlazorWebAPI.Entities.Task;
using System.Linq;
using ToDoListBlazorWebAPI.Entities;
using ToDoListModels;

namespace ToDoListBlazorWebAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoListDbContext _context;
        public TaskRepository(ToDoListDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task>> GetTaskList()
        {
            return await _context.Tasks.Include(x=>x.Assignee).ToListAsync();
        } 

        public async Task<Task> CreateTask(Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Task> UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Task> DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Task> GetTaskById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }
    }
}
