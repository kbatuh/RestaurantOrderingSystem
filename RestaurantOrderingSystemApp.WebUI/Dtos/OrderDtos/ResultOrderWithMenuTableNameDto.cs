using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.WebUI.Dtos.OrderDtos
{
    public class ResultOrderWithMenuTableNameDto
    {
        public int OrderID { get; set; }
        //[Column(TypeName = "Date")]
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal FinalPrice { get; set; }
        public bool Status { get; set; }
        public string MenuTableName { get; set; }
        public int MenuTableID { get; set; }
    }
}
