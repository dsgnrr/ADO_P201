﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_P201.EFCore
{
    public class Department
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime? DeleteDt { get; set; }

        public override string ToString()
        {
            return Id.ToString()[..5] + "..." + Name;
        }


        // NAVIGATION PROPERTIES /////////////////

        public List<Manager> Workers { get; set; }
        public List<Manager> SubWorkers { get; set; }
    }
}
