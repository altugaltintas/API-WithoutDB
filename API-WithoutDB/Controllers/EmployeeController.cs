using API_WithoutDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API_WithoutDB.Controllers
{
    [Route("api/[controller]")]    // [controller] => contorller ad ıneyse yani burada sadece empolye
    [ApiController]
    public class EmployeeController : ControllerBase   // localHost/api/employee çağırdığında bu gelir
    {

        //[HttpGet]

        //public string Get()
        //{

        //    return "Merhabalar burasi ilk api projesi geti";

        //}


        //[HttpGet]

        //public string GetEmployee()

        //{
        //    return "merhaba get empoye metodu burada";

        //}


        // Yukarıdaki iki metod açıken çalıştırılıp , httpget kullanılmak istenirse multiple, endPoint hatası alınır çünkü hangi httpget gideceğini bilmez

        // Defaultta bir api kontroller içerisinde yalnızca birer tane http get /put / delete / post olduğu kabul edilir bu yüzden   birden fazla aynı metodu kullanmak istediğimzde onların yollarını değiştirmelyiz ki karışıklık olması

        //   tarayıcımız sadece httpget isteklerine karşılık verebilir bunun dışındaki metodlar için postman,  swagger, vb gib uygulamaları kullanarak metotlarımızı test ederiz


        private List<Employee> _employeesList = FakeData.GetEmployees(50);

        [HttpGet]     // getirme işlemini yapar

        public List<Employee> Get()
        {
            return _employeesList;

        }

        [HttpGet("{id}")]   // parametre adı neyse uri için burada da onu kullanmak gerekir
        public Employee GetById(int id)   //htt p://localhost:10160/api/employee/3   id si 3 olanı döndürüyor 

        {
            return _employeesList.FirstOrDefault(a => a.ID == id);
        }



        [HttpPost]  // gönderir

        public Employee Create([FromBody]Employee employee) 
        {
            _employeesList.Add(employee);
            return employee;
        }




        [HttpPut] //güncellemek demek 

        public Employee Put([FromBody]Employee employee)   //güncelde olmasını istediğimmiz nesle
        {
           Employee Updated=_employeesList.FirstOrDefault(a=> a.ID ==employee.ID);

            Updated.FirstNAme = employee.FirstNAme;
            Updated.LastName = employee.LastName;
            Updated.Department = employee.Department;
            return employee;
        
        }


        [HttpDelete("{id}")]  //remove etme

        public void Detete(int id)   // eğer metodum id alıyorsa  [HttpDelete("{id}") şeklinde id bilgisi eklenmeli
        {

            Employee employee = _employeesList.FirstOrDefault(a=> a.ID == id);

            _employeesList.Remove(employee);


        }
    }
}
