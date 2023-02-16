﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_P201.Entity
{
    public class Manager
    {
        public Guid Id { get; set; }
        public String Surname { get; set; }
        public String Name { get; set; }
        public String Secname { get; set; }
        public Guid IdMainDep { get; set; } //Guid - ValueType, вживається для полів з модифікатором NOT NULL
        public Guid? IdSecDep { get; set; } // Якщо NULL не забронений, Guid використовується з Nullable(?)
        public Guid? IdChief { get; set; } //Gguid? - скорочення від Nullable<Guid>

        public Manager()
        {
            Id = Guid.NewGuid();
            Surname = null;
            Name = null;
            Secname = null;
        }
    }
}
