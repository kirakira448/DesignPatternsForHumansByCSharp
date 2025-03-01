namespace Structural
{
    class Composite
    {
        public interface IEmployee
        {
            string Name { get; set; }
            float Salary { get; set; }
            List<string> Roles { get; set; }
        }

        public class Developer : IEmployee
        {
            public string Name { get; set; }
            public float Salary { get; set; }
            public List<string> Roles { get; set; }

            public Developer(string name, float salary)
            {
                Name = name;
                Salary = salary;
                Roles = new List<string>();
            }
        }

        public class Designer : IEmployee
        {
            public string Name { get; set; }
            public float Salary { get; set; }
            public List<string> Roles { get; set; }

            public Designer(string name, float salary)
            {
                Name = name;
                Salary = salary;
                Roles = new List<string>();
            }
        }

        class Organization
        {
            private List<IEmployee> employees = new();

            public void AddEmployee(IEmployee employee)
            {
                employees.Add(employee);
            }

            public float GetNetSalary()
            {
                float totalSalary = 0;
                foreach (var employee in employees)
                {
                    totalSalary += employee.Salary;
                }
                return totalSalary;
            }
        }

        public static void DemonstrateComposite()
        {
            var organization = new Organization();
            organization.AddEmployee(new Developer("John", 10000));
            organization.AddEmployee(new Designer("Jane", 8000));
            Console.WriteLine($"Net Salary: {organization.GetNetSalary()}");
        }
    }
}
