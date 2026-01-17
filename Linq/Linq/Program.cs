using System.Text;

namespace Linq
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var today = DateTime.Today;


            // Згенеровано ШІ 

            var emp1 = new Employee("Іван Іванов", "Manager", "+380991112233", "ivan@mail.com", 1500);
            var emp2 = new Employee("Діана Принс", "Manager", "+380992223344", "diana@mail.com", 2500);
            var emp3 = new Employee("Lionel Messi", "Forward", "2300011122", "messi@mail.com", 5000000);
            var emp4 = new Employee("Lionel Richie", "Musician", "2355566677", "hello@music.com", 4000);
            var emp5 = new Employee("Diego Costa", "Logist", "+380995556677", "diego@mail.com", 1200);
            var emp6 = new Employee("Дмитро Козак", "IT Support", "+380998889900", "dimas@mail.com", 1100);
            var emp7 = new Employee("Сара Коннор", "Security", "+380990000000", "sarah@sky.net", 3000);

            var firms = new List<Firma>
            {
                new Firma("Healthy Food Ltd", new DateTime(2020, 5, 20), "Marketing", "John White", 150, "123 Baker St, London",
                    new List<Employee> { emp1, emp3 }),

                new Firma("Tech Solutions", new DateTime(2018, 1, 10), "IT", "Alice Smith", 400, "New York, USA",
                    new List<Employee> { emp4, emp7 }),

                new Firma("Bright Marketing", new DateTime(2023, 3, 15), "Marketing", "Bob Brown", 50, "Kyiv, Ukraine",
                    new List<Employee> { emp2 }),

                new Firma("White Star Inc", new DateTime(2021, 6, 01), "Construction", "Jack Black", 200, "Liverpool, UK",
                     new List<Employee> { emp6 }),

                new Firma("Fast Food Tech", today.AddDays(-123), "IT", "Sarah Connor", 120, "London, UK"),

                new Firma("Global Trade", today.AddYears(-1), "Logistics", "Walter White", 250, "Warsaw, Poland",
                    new List<Employee> { emp5 }),


                new Firma{Name = "Creative Minds",
                    DateOfEstablishment = new DateTime(2019, 11, 5),
                    BusinessProfile = "Marketing",
                    PIB_Director = "Emma Green",
                    NumberOfEmployees = 80,
                    Address = "Berlin, Germany",
                    Employees = new List<Employee>() {emp1, emp2} }

            };

            Console.WriteLine("=== Перевірка структури (Фірми + Працівники) ===");
            firms.Print();

            Console.WriteLine("Усі фірми:");
            var allFirms = firms.ToList();
            allFirms.Print();


            Console.WriteLine("Фірми із 'Food' у назві:");
            var foodInName = firms.Where(f => f.Name.Contains("Food")).ToList();
            foodInName.Print();


            Console.WriteLine("Маркетингові фірми:");
            var marketingFirms = firms.Where(f => f.BusinessProfile == "Marketing").ToList();
            marketingFirms.Print();


            Console.WriteLine("Фірми з маркетингу або IT:");
            var marketingOrIT = firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT").ToList();
            marketingOrIT.Print();


            Console.WriteLine("Кількість працівників > 100:");
            var more100 = firms.Where(f => f.NumberOfEmployees > 100).ToList();
            more100.Print();


            Console.WriteLine("Кількість працівників від 100 до 300:");
            var more100less300 = firms.Where(f => f.NumberOfEmployees >= 100 && f.NumberOfEmployees <= 300).ToList();
            more100less300.Print();


            Console.WriteLine("Фірми в Лондоні:");
            var londonFirms = firms.Where(f => f.Address.Contains("London")).ToList();
            londonFirms.Print();


            Console.WriteLine("Прізвище директора White:");
            var directorWhite = firms.Where(f => f.PIB_Director.Contains("White")).ToList();
            directorWhite.Print();


            Console.WriteLine("Засновані більше 2 років тому:");
            var oldFirms = firms.Where(f => f.DateOfEstablishment < DateTime.Today.AddYears(-2)).ToList();
            oldFirms.Print();


            Console.WriteLine("123 дні з моменту заснування:");
            var days123 = firms.Where(f => (today - f.DateOfEstablishment.Date).TotalDays == 123).ToList();
            days123.Print();


            Console.WriteLine("Директор Black і назва White:");
            var blackWhite = firms.Where(f => f.PIB_Director.Contains("Black") && f.Name.Contains("White")).ToList();
            blackWhite.Print();

            Console.WriteLine("\n---------------------------");
            Console.WriteLine("ТЕПЕР ЗАПИТИ НА ПРАЦІВНИКІВ");
            Console.WriteLine("---------------------------\n");

            Console.WriteLine("Список усіх працівників фірми 'Healthy Food Ltd':");
            var firm1Employees = firms.FirstOrDefault(f => f.Name == "Healthy Food Ltd")?.Employees;
            if (firm1Employees != null) firm1Employees.Print();
            else Console.WriteLine("Фірму не знайдено");

            Console.WriteLine("Працівники фірми 'Tech Solutions', у яких зарплата > 3500:");
            var salary3500 = firms.FirstOrDefault(f => f.Name == "Tech Solutions")?.Employees.Where(e => e.Salary > 3500).ToList();
            if (salary3500 != null) salary3500.Print();
            else Console.WriteLine("Фірму не знайдено");

            Console.WriteLine("Працівники всіх фірм з посадою 'Manager':");
            var managers = firms.SelectMany(f => f.Employees).Where(e => e.Position == "Manager").ToList();
            managers.Print();

            Console.WriteLine("Працівники, у яких Email починається з 'di':");
            var emailDI = firms.SelectMany(f => f.Employees).Where(e => e.Email.StartsWith("di")).ToList();
            emailDI.Print();

            Console.WriteLine("Працівники з ім'ям Lionel:");
            var lionels = firms.SelectMany(f => f.Employees).Where(e => e.PIB.Contains("Lionel")).ToList();
            lionels.Print();







        }
    }
}