using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_P201.EFCore
{
    public class Manager
    {
        public Guid Id { get; set; }
        [Required]
        public String Surname { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Secname { get; set; }
        public Guid IdMainDep { get; set; } 
        public Guid? IdSecDep { get; set; } 
        public Guid? IdChief { get; set; } 
        public DateTime? DeleteDt { get; set; }

        // NAVIGATION PROPERTIES /////////////////
        public Department MainDep { get; set; }
        public Department SecDep { get; set; }

        // колекція продажів(чеків)
        public List<Sale> Sales { get; set; }

        // колекція проданих товарів
        public List<Product> Products { get; set; }
    }
}
