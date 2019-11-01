using CrudBlazorServer.Models;
using Employee;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CrudBlazorServer.Service
{
    public class EmployeesService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly EmployeeManage.EmployeeManageClient _grpcClient;


        public EmployeesService(IHttpClientFactory clientFactory, EmployeeManage.EmployeeManageClient grpcClient)
        {
            _clientFactory = clientFactory;
            _grpcClient = grpcClient;
        }

        public async Task<IEnumerable<Models.Employee>> GetAsync()
        {
            var _httpClient = _clientFactory.CreateClient("backendApi");
            var result = await _httpClient.GetAsync("api/Employees/");
            result.EnsureSuccessStatusCode();
            var obj = JsonSerializer.Deserialize<IEnumerable<Models.Employee>>(await result.Content.ReadAsStringAsync(),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return obj;

            // Call gRPC Sample
            //using var call = _grpcClient.GetAllAsync(new Empty());            
            //var obj = await call.ResponseAsync;
            //return obj.Items.Select(m => new Models.Employee() { Id = m.Id, FirstName = m.FirstName, LastName = m.LastName });
            
        }

        public async Task<Models.Employee> GetAsync(int id)
        {
            var _httpClient = _clientFactory.CreateClient("backendApi");
            var result = await _httpClient.GetAsync($"api/Employees/{id}");
            result.EnsureSuccessStatusCode();
            var obj = JsonSerializer.Deserialize<Models.Employee>(await result.Content.ReadAsStringAsync(),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return obj;
        }

        public async Task<Models.Employee> Add(Models.Employee employee)
        {
            var _httpClient = _clientFactory.CreateClient("backendApi");

            var postContent = new StringContent(
                JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync($"api/Employees/", postContent);
            result.EnsureSuccessStatusCode();
            var obj = JsonSerializer.Deserialize<Models.Employee>(await result.Content.ReadAsStringAsync(),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return obj;
        }

        public async Task<bool> Update(int id, Models.Employee employee)
        {
            
            var _httpClient = _clientFactory.CreateClient("backendApi");

            var putContent = new StringContent(
              JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            var result = await _httpClient
                .PutAsync($"api/Employees/{id}", putContent);
            result.EnsureSuccessStatusCode();
            return true;
        }

        public async Task<bool> Del(int id)
        {
            var _httpClient = _clientFactory.CreateClient("backendApi");
            var result = await _httpClient
                .DeleteAsync($"api/Employees/{id}");
            result.EnsureSuccessStatusCode();
            return true;
        }
    }
}
