﻿using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ToDoListModels;

namespace ToDoListBlazorWasm.Services
{
    public class TaskApiClient : ITaskApiClient
    {
        public HttpClient _httpClient;

        public TaskApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TaskDto>> GetTaskList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<TaskDto>>("/api/tasks");
            return result;

        }
    }
}
