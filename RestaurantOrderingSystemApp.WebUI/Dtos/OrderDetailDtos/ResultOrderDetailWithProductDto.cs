using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.WebUI.Dtos.OrderDetailDtos
{
    public class ResultOrderDetailWithProductDto
    {
        public int OrderDetailID { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }
        public string CustomerCode { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
    }
}
