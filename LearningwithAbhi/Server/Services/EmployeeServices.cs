

namespace LearningwithAbhi.Server.Services
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
                existing.FullName = employee.FullName;
                existing.Email = employee.Email;
                existing.Phone = employee.Phone;
                existing.Department = employee.Department;
                existing.Age = employee.Age;
                existing.Address = employee.Address;
                existing.Skills = employee.Skills;
                existing.EmploymentDetails = employee.EmploymentDetails;
                existing.IsActive = employee.IsActive;
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
