using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class soru4
    {
        public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary,
        DateTime HireDate)> employees)
        {
            if (employees == null)
                return "{}";

           
            var filter = employees
                .Where(e => e.Age >= 25 && e.Age <= 40
                         && (e.Department == "IT" || e.Department == "Finance")
                         && e.Salary >= 5000 && e.Salary <= 9000
                         && e.HireDate.Year > 2017)
                
                .OrderByDescending(e => e.Name.Length)
                .ThenBy(e => e.Name)
                .ToList();


            decimal sumSalary = filter.Sum(e => e.Salary);
            decimal averageSalary = filter.Count > 0 ? filter.Average(e => e.Salary) : 0;
            decimal minSalary = filter.Count > 0 ? filter.Min(e => e.Salary) : 0;
            decimal maxSalary = filter.Count > 0 ? filter.Max(e => e.Salary) : 0;
            int count = filter.Count;

            var result = new
            {
                Names = filter.Select(e => e.Name).ToList(), 
                TotalSalary = sumSalary,
                AverageSalary = Math.Round(averageSalary, 2), 
                MinSalary = minSalary,
                MaxSalary = maxSalary,
                Count = count
            };

            return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = false });
        }

    }
}
