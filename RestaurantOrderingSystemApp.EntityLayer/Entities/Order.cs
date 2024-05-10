using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantOrderingSystemApp.EntityLayer.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        //[Column(TypeName = "Date")]
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal FinalPrice { get; set; }
        public bool Status { get; set; }
        public int MenuTableID { get; set; }
        public MenuTable MenuTable { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
