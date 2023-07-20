using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiApplication.Models
{
    public class Teacher : BaseEntity
    {
        private static int _counter = 0;

        public Teacher(string name, string surname, DateTime birthDay)  : base(name, surname, birthDay)
        {
            Id = _counter++;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Surname} | BirthDate: {$"{this.BirthDay.Month}/{this.BirthDay.Day}/{this.BirthDay.Year}"}";
        }
    }
}
