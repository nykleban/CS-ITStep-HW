using System;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    public class Firma
    {

        public string Name { get; set; }
        public DateTime DateOfEstablishment { get; set; }
        public string BusinessProfile { get; set; }
        public string PIB_Director { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set; }
        public Firma(string name, DateTime dateOfEstablishment, string businessProfile, string pibDirector, int numberOfEmployees, string address, List<Employee> employees = null)
        {
            Name = name;
            DateOfEstablishment = dateOfEstablishment;
            BusinessProfile = businessProfile;
            PIB_Director = pibDirector;
            NumberOfEmployees = numberOfEmployees;
            Address = address;
            Employees = employees ?? new List<Employee>();
        }
        public override string ToString()
        {
            return $"➡️ Назва: {Name}, Профіль: {BusinessProfile}, Директор: {PIB_Director}, Працівників: {NumberOfEmployees}, Дата: {DateOfEstablishment:dd.MM.yyyy}";
        }
    }
}
