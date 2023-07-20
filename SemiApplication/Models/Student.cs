using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiApplication.Models
{
    public class Student : BaseEntity
    {
        private static int _counter = 0;

        public decimal Grade { get; set; }

        public Student(string name, string surname, decimal grade, DateTime birthday) : base(name, surname, birthday)
        {
            Grade = grade;
            Id = _counter++;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Surname} -- {this.Grade} | BirthDate: {$"{this.BirthDay.Month}/{this.BirthDay.Day}/{this.BirthDay.Year}"}";
        }
    }
}