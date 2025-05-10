
# Blazor WebAssembly Hosted App – Create Employee CRUD Flow

## Project Structure
This solution contains 3 projects:

1. **Client** – Blazor WebAssembly app (UI)
2. **Server** – ASP.NET Core Web API and host
3. **Shared** – Shared models between Client and Server

---

## 1. Shared Project – Define Employee Model

**File:** `Shared/Employee.cs`

```csharp
namespace YourApp.Shared
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }
}
````

---

## 2. Server Project – API & Service Layer

### A. In-Memory Employee Service

**File:** `Server/Services/EmployeeService.cs`

```csharp
using YourApp.Shared;

namespace YourApp.Server.Services
{
    public class EmployeeService
    {
        private List<Employee> _employees = new();
        private int _nextId = 1;

        public List<Employee> GetAll() => _employees;

        public Employee? GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

        public void Add(Employee employee)
        {
            employee.Id = _nextId++;
            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var existing = GetById(employee.Id);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Email = employee.Email;
                existing.Department = employee.Department;
            }
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
                _employees.Remove(employee);
        }
    }
}
```

### B. Register the Service in `Program.cs`

```csharp
builder.Services.AddSingleton<EmployeeService>();
```

### C. Employee Controller

**File:** `Server/Controllers/EmployeeController.cs`

```csharp
using Microsoft.AspNetCore.Mvc;
using YourApp.Server.Services;
using YourApp.Shared;

namespace YourApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _service;

    public EmployeeController(EmployeeService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var employee = _service.GetById(id);
        return employee == null ? NotFound() : Ok(employee);
    }

    [HttpPost]
    public IActionResult Add(Employee employee)
    {
        _service.Add(employee);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(Employee employee)
    {
        _service.Update(employee);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok();
    }
}
```

---

## 3. Client Project – UI & API Interaction

### A. EmployeeService (API Interaction)

**File:** `Client/Services/EmployeeService.cs`

```csharp
using System.Net.Http.Json;
using YourApp.Shared;

namespace YourApp.Client.Services
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
```

### B. Register Service in `Program.cs`

```csharp
builder.Services.AddScoped<EmployeeService>();
```

### C. Employees.razor (List View)

**File:** `Client/Pages/Employees.razor`

```razor
@page "/employees"
@inject EmployeeService EmployeeService
@inject NavigationManager NavigationManager

<h3 class="text-2xl font-bold mb-4">Employee List</h3>

<button class="btn btn-primary mb-3" @onclick="CreateEmployee">Add Employee</button>

@if (employees == null)
{
    <p><em>Loading...</em></p>
}
else if (!employees.Any())
{
    <p>No employees found.</p>
}
else
{
    <table class="table table-striped">
        <thead>
            <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Department</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var emp in employees)
            {
                <tr>
                    <td>@emp.Name</td>
                    <td>@emp.Email</td>
                    <td>@emp.Department</td>
                    <td>
                        <button class="btn btn-sm btn-secondary me-2" @onclick="() => EditEmployee(emp.Id)">Edit</button>
                        <button class="btn btn-sm btn-danger" @onclick="() => DeleteEmployee(emp.Id)">Delete</button>
                    </td>
                </tr>
            }
        </tbody>
    </table>
}

@code {
    private List<Employee>? employees;

    protected override async Task OnInitializedAsync()
    {
        employees = await EmployeeService.GetAllAsync();
    }

    private void CreateEmployee() => NavigationManager.NavigateTo("/employees/add");

    private void EditEmployee(int id) => NavigationManager.NavigateTo($"/employees/edit/{id}");

    private async Task DeleteEmployee(int id)
    {
        await EmployeeService.DeleteAsync(id);
        employees = await EmployeeService.GetAllAsync();
    }
}
```

### D. AddEditEmployee.razor (Add/Edit Form)

**File:** `Client/Pages/AddEditEmployee.razor`

```razor
@page "/employees/add"
@page "/employees/edit/{Id:int}"
@inject EmployeeService EmployeeService
@inject NavigationManager NavigationManager

<h3 class="text-xl font-bold mb-4">@((Id == 0) ? "Add New Employee" : "Edit Employee")</h3>

<EditForm Model="employee" OnValidSubmit="HandleSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <div class="mb-3">
        <label>Name:</label>
        <InputText class="form-control" @bind-Value="employee.Name" />
    </div>

    <div class="mb-3">
        <label>Email:</label>
        <InputText class="form-control" @bind-Value="employee.Email" />
    </div>

    <div class="mb-3">
        <label>Department:</label>
        <InputText class="form-control" @bind-Value="employee.Department" />
    </div>

    <button class="btn btn-success me-2" type="submit">Save</button>
    <button class="btn btn-secondary" type="button" @onclick="Cancel">Cancel</button>
</EditForm>

@code {
    [Parameter] public int Id { get; set; }
    private Employee employee = new();

    protected override async Task OnInitializedAsync()
    {
        if (Id != 0)
        {
            var existing = await EmployeeService.GetByIdAsync(Id);
            if (existing != null)
                employee = existing;
        }
    }

    private async Task HandleSubmit()
    {
        if (Id == 0)
            await EmployeeService.AddAsync(employee);
        else
            await EmployeeService.UpdateAsync(employee);

        NavigationManager.NavigateTo("/employees");
    }

    private void Cancel() => NavigationManager.NavigateTo("/employees");
}
```

### E. Add Route Link in NavMenu.razor

```razor
<NavLink href="employees" class="nav-link" Match="NavLinkMatch.All">
    <span class="oi oi-people"></span> Employees
</NavLink>
```

---

## 4. Running the App

> **Run this command from the Server project directory:**

```bash
cd YourSolution/Server
```

Then run the app:

```bash
dotnet run
```
