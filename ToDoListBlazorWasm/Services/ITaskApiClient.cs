using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListModels;

namespace ToDoListBlazorWasm.Services
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTaskList(); 
    }
}
