using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_Models
{
    public class OrderListModels
    {
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public string Account { get; set; } 
        public DateTime OrderTime { get; set; }
        public DateTime OrderEndTime { get; set; }
        public DateTime RequiredTime { get; set; }
        public string SupplierName { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalCups { get; set; }
        public string Established { get; set; }
    }
}
