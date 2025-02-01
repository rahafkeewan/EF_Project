using EF_Project.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project
{
    public class LinqQueries
    {
        private readonly PurchasingContext _context;

        public LinqQueries(PurchasingContext context)
        {
            _context = context;
        }

        public void ListEmployeesWithDepartments()
        {
            var query = from emp in _context.Set<Employee>()
                        join dept in _context.Set<Department>()
                        on emp.DepartmentId equals dept.DepartmentId
                        select new { emp.FirstName, emp.LastName, dept.DepartmentName, emp.HireDate };

            foreach (var result in query)
            {
                Console.WriteLine($"{result.FirstName} {result.LastName} - {result.DepartmentName} - {result.HireDate}");
            }
        }
    }
}
