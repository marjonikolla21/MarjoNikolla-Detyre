
using CompaniesApp.API.Data;
using MarjoNikollaProjekt.API.Data.Models;
using MarjoNikollaProjekt.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //Marrim te gjithe Studentet nga databaza
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var allStudentFromDb = FakeDb.StudentsDb.ToList();
            return Ok(allStudentFromDb);
        }
        [HttpGet("{id}")]
        public IActionResult GetstudentId(int id)
        {
            var StudentFromDb = FakeDb.StudentsDb.FirstOrDefault(x => x.Id == id);

            if (StudentFromDb == null)
            {
                return NotFound($"Student with id = {id} not found");
            }
            else
            {
                return Ok(StudentFromDb);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudentById(int id)
        {
            var StudentFromDb = FakeDb.StudentsDb.FirstOrDefault(x => x.Id == id);

            if (StudentFromDb == null)
            {
                return NotFound($"Student with id = {id} not found");
            }
            else
            {
                FakeDb.StudentsDb.Remove(StudentFromDb);

                var latestList = FakeDb.StudentsDb.ToList();
                return Ok($"Student with id = {id} was removed");
            }
        }
        [HttpPost]
        public IActionResult PostStudent([FromBody] PostStudentDto payload)
        {
            //1. Krijohet objekti
            var newStudent = new Student()
            {
                //Do te gjeneroj id e Studenteve nga 10-99
                Id = new Random().Next(10, 100),

                StName = payload.StName,
                LsName = payload.StName,
                DOB = payload.DOB,

            };

            //2. Shtohet objekti ne DB
            FakeDb.StudentsDb.Add(newStudent);

            return Ok("PostStudent");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody] PutStudentDto newData, int id)
        {
            //1. Merr te dhenat e vjetra nga db
            var StudentFromDb = FakeDb.StudentsDb.FirstOrDefault(x => x.Id == id);

            if (StudentFromDb == null)
            {
                return NotFound("Student could not be updated");
            }

            //2. Perditeso te dhenat
            StudentFromDb.StName = newData.StName;
            StudentFromDb.LsName = newData.LsName;
            StudentFromDb.DOB = newData.DOB;

            //3. Ruaj te ne database


            return Ok("Student updated");
        }


    }
}
