using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ToDoListBlazorWasm.Services;
using ToDoListModels;

namespace ToDoListBlazorWasm.Pages
{
    public partial class TodoList
    {
        [Inject] private ITaskApiClient TaskApiClient { get; set; }
        private List<TaskDto> Tasks;

        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskApiClient.GetTaskList();
        }
    }
}
