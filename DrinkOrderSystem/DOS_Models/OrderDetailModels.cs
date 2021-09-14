using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_Models
{


    public class OrderDetailModels
    {
        public Guid OrderDetailsID { get; set; }

        public string OrderNumber { get; set; }

        public string Account { get; set; }

        public DateTime OrderTime { get; set; }

        public DateTime OrderEndTime { get; set; }

        public DateTime RequiredTime { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public string Toppings { get; set; }

        public decimal ToppingsUnitPrice { get; set; }

        public string Suger { get; set; }

        public string Ice { get; set; }

        public string SupplierName { get; set; }    
        
        public int Quantity { get; set; }

        public decimal SubtotalAmount
        {
            get
            {
                return this.Quantity * (this.UnitPrice + this.ToppingsUnitPrice);
            }
        }
        public string OtherRequest { get; set; }

        public string Established { get; set; }
    }
}
