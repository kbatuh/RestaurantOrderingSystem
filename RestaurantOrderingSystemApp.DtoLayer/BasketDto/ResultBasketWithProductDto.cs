using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.DtoLayer.BasketDto
{
    public class ResultBasketWithProductDto
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductName { get; set; }
        public string CustomerCode { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
    }
}
