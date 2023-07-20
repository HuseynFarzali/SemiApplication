using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiApplication.Models
{
    public class BaseEntity : IComparable<BaseEntity>
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }

        public BaseEntity(string name, string surname, DateTime birthDay)
        {
            Name = name;
            Surname = surname;
            BirthDay = birthDay;
        }

        public int CompareTo(BaseEntity? other)
        {
            if (other == null) return 1;

            return this.Id.CompareTo(other.Id);
        }
    }
}
