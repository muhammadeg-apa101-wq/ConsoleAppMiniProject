using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Student : BaseEntity
    {
        public string Surname { get; set; }
        public Group group { get; set; }
        public int Age { get; set; }
    }
}
