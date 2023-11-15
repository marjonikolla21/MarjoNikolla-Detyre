using MarjoNikollaProjekt.API.Data.Models;


namespace CompaniesApp.API.Data
{
    public static class FakeDb
    {
       
        public static List<Student> StudentsDb = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                StName = "Student 01",
                LsName = "LN01",
                DOB = DateTime.UtcNow,

            },
           new Student()
            {
                Id = 2,
                StName = "Student 02",
                LsName = "LN02",
                DOB = DateTime.UtcNow,

            },

           new Student()
            {
                Id = 2,
                StName = "Student 03",
                LsName = "LN03",
                DOB = DateTime.UtcNow,

            },
            new Student()
            {
                Id = 4,
                StName = "Student 04",
                LsName = "LN04",
                DOB = DateTime.UtcNow,
            }
        };

        public static List<Student> GetAllStudent()
        {
            return StudentsDb;
        }
    }
}