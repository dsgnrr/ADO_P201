using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_P201.EFCore
{
    public class Sale
    {
        public Guid Id { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid ManagerId { get; set; }
        public DateTime? DeleteDt { get; set; }

        // NAVIGATION PROPERTIES /////////////////

        public Manager Manager { get; set; }
        public Product Product { get; set; }
    }
}
