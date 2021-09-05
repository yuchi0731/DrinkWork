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
        public string OrderTime { get; set; }
        public string OrderEndTime { get; set; }
        public string RequiredTime { get; set; }
        public string SupplierName { get; set; }
        public string TotalPrice { get; set; }
        public string TotalCups { get; set; }
    }
}
