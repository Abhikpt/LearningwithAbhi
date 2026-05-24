using System.Net.Http.Json;
using LearningwithAbhi.Shared;

namespace LearningwithAbhi.Client.Services
{
   
       public class EmployeeService
    {
        private readonly HttpClient _http;

        public EmployeeService(HttpClient http) => _http = http;

        public async Task<List<Employee>> GetAllAsync() =>
            await _http.GetFromJsonAsync<List<Employee>>("api/employee") ?? new();

        public async Task<Employee?> GetByIdAsync(int id) =>
            await _http.GetFromJsonAsync<Employee>($"api/employee/{id}");

        public async Task AddAsync(Employee employee) =>
            await _http.PostAsJsonAsync("api/employee", employee);

        public async Task UpdateAsync(Employee employee) =>
            await _http.PutAsJsonAsync("api/employee", employee);

        public async Task DeleteAsync(int id) =>
            await _http.DeleteAsync($"api/employee/{id}");
    }
    
}
