using Bogus;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace API_WithoutDB.Models
{
    public class FakeData
    {
        // Uygulama açık kaldığı süre boyunca BOGUS kütüphanesinden aldığımız veriler bize veritabanı görevi görecek



        private static List<Employee> _employees;


            public static List<Employee> GetEmployees(int id)
        {
            if (_employees==null)
            {
                _employees = new Faker<Employee>().RuleFor(a => a.ID, faker => faker.IndexFaker + 1)
                                                  .RuleFor(a => a.FirstNAme, faker => faker.Name.FirstName())
                                                  .RuleFor(a => a.LastName, faker => faker.Name.LastName())
                                                  .RuleFor(a => a.Department, faker => faker.Name.JobTitle())
                                                  .Generate(id);

            }
            return _employees;
        }

    }
}
