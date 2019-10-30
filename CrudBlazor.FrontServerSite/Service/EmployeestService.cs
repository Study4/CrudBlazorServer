using CrudBlazor.FrontServerSite.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CrudBlazor.FrontServerSite.Service
{
    public class EmployeesService
    {
        private readonly IHttpClientFactory _clientFactory;

        public EmployeesService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<Employee>> GetAsync()
        {
            var _httpClient = _clientFactory.CreateClient("backendApi");
            var result = await _httpClient.GetAsync("api/Employees/");
            result.EnsureSuccessStatusCode();
            var obj = JsonSerializer.Deserialize<IEnumerable<Employee>>(await result.Content.ReadAsStringAsync());
            return obj;
        }

        public async Task<Employee> GetAsync(int id)
        {
            var _httpClient = _clientFactory.CreateClient("backendApi");
            var result = await _httpClient.GetAsync($"api/Employees/{id}");
            result.EnsureSuccessStatusCode();
            var obj = JsonSerializer.Deserialize<Employee>(await result.Content.ReadAsStringAsync());
            return obj;
        }

        public async Task<Employee> Add(Employee employee)
        {
            var _httpClient = _clientFactory.CreateClient("backendApi");

            var postContent = new StringContent(
                JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync($"api/Employees/", postContent);
            result.EnsureSuccessStatusCode();
            var obj = JsonSerializer.Deserialize<Employee>(await result.Content.ReadAsStringAsync());
            return obj;
        }

        public async Task<bool> Update(int id, Employee employee)
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
