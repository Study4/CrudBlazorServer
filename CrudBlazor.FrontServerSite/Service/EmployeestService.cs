using CrudBlazor.FrontServerSite.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
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
            return await result.Content.ReadAsAsync<IEnumerable<Employee>>();
        }

        public async Task<Employee> GetAsync(int id)
        {
            var _httpClient = _clientFactory.CreateClient("backendApi");
            var result = await _httpClient.GetAsync($"api/Employees/{id}");
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadAsAsync<Employee>();
        }

        public async Task<Employee> Add(Employee employee)
        {
            var _httpClient = _clientFactory.CreateClient("backendApi");
            var result = await _httpClient
                .PostAsync<Employee>($"api/Employees/", employee, new JsonMediaTypeFormatter());
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadAsAsync<Employee>();
        }

        public async Task<bool> Update(int id, Employee employee)
        {
            var _httpClient = _clientFactory.CreateClient("backendApi");
            var result = await _httpClient
                .PutAsync<Employee>($"api/Employees/{id}", employee, new JsonMediaTypeFormatter());
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
