using System;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    public class Employee
    {
        public string PIB { get; set; }
        public string Position { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public float Salary { get; set; }
        public Employee(string pib, string position, string contactPhone, string email, float salary)
        {
            PIB = pib;
            Position = position;
            ContactPhone = contactPhone;
            Email = email;
            Salary = salary;
        }
        public override string ToString()
        {
            return $"  --→ {PIB} ({Position}), Тел: {ContactPhone}, Email: {Email}, Зарплата: {Salary}$";
        }

    }
}
