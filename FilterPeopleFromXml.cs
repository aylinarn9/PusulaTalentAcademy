using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    public class soru3
    {
        public static string FilterPeopleFromXml(string xmlData)
        {
            if (string.IsNullOrEmpty(xmlData))
                return "{}";

           
            XDocument document = XDocument.Parse(xmlData);
            var people = new List<dynamic>();

            foreach (var p in document.Descendants("Person"))
            {
                int age = (int)p.Element("Age");
                string department = (string)p.Element("Department");
                decimal salary = (decimal)p.Element("Salary");
                DateTime hireDate = DateTime.ParseExact((string)p.Element("HireDate"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                if (age > 30 && department == "IT" && salary > 5000 && hireDate.Year < 2019)
                {
                    people.Add(new
                    {
                        Name = (string)p.Element("Name"),
                        Age = age,
                        Department = department,
                        Salary = salary,
                        HireDate = hireDate
                    });
                }
            }

            var alfabetik_sira = people.Select(p => p.Name).OrderBy(name => name).ToList();
            int totalCount = people.Count;

            decimal sum_Salary = 0;
            decimal max_Salary = decimal.MinValue;
            

            foreach (var person in people)
            {
                sum_Salary += person.Salary;
                if (person.Salary > max_Salary)
                    max_Salary = person.Salary;
                
            }

            
            decimal avg_Salary = totalCount > 0 ? sum_Salary / totalCount : 0;

            var result = new
            {
                Names = alfabetik_sira,
                TotalSalary = sum_Salary,
                AverageSalary = avg_Salary,
                MaxSalary = max_Salary,
                Count = totalCount
            };

            return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
