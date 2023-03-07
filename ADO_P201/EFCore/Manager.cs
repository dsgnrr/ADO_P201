using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_P201.EFCore
{
    public class Manager
    {
        public Guid Id { get; set; }
        public String Surname { get; set; }
        public String Name { get; set; }
        public String Secname { get; set; }
        public Guid IdMainDep { get; set; } 
        public Guid? IdSecDep { get; set; } 
        public Guid? IdChief { get; set; } 
        public DateTime? DeleteDt { get; set; }
    }
}
