
using MarjoNikollaProjekt.Data.Base;

namespace MarjoNikollaProjekt.API.Data.Models
{
    public class Student : EntityBase
    {
        public string StName { get; set; }
        public string LsName { get; set; }
        public DateTime DOB { get; set; }

    }
}