using CRUDAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @"
             select Stu_ID,Stu_name,Stu_role from Students
             ";

            DataTable table = new();
            string sqlDataSource = _configuration.GetConnectionString("StudentsCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using MySqlCommand myCommand = new MySqlCommand(query, mycon);
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);

                myReader.Close();
                mycon.Close();
            }
            return new JsonResult(table);
        }
        }
    /*
        public IActionResult Gets()
        {
            if (_oStudents.Count == 0)
            {
                return NotFound("No list was found");

            }
            return Ok(_oStudents);

    }
        [HttpPost]

        public IActionResult Save(Model.Student oStudent )
        {
            _oStudents.Add(oStudent);
            if(_oStudents.Count == 0)
            {
                return NotFound("No list was found");

            }
            return Ok(_oStudents);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x => x.Id  == id);
            if(_oStudents == null)
            {
                return NotFound("No Student Found");

               
            }
            _oStudents.Remove(oStudent);
            if (_oStudents.Count == 0)
            {
                return NotFound("No was list was found");

            }
            return Ok(_oStudents);
        }
         
   

    } */

}
