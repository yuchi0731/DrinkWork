using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_Models
{
    public class OrderDetailModels
    {
        public string OrderDetailsID { get; set; }
        public string OrderNumber { get; set; }
        public string Account { get; set; }
        public string OrderTime { get; set; }
        public string OrderEndTime { get; set; }
        public string RequiredTime { get; set; }
        public string ProductName { get; set; }
        public string UnitPrice { get; set; }
        public string Toppings { get; set; }
        public string ToppingsUnitPrice { get; set; }
        public string Suger { get; set; }
        public string Ice { get; set; }
        public string SupplierName { get; set; }        
        public string Quantity { get; set; }
        public string SubtotalAmount { get; set; }
        public string OtherRequest { get; set; }
    }
}
