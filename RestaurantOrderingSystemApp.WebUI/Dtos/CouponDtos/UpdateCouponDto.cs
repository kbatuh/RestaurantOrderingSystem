using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.WebUI.Dtos.CouponDtos
{
    public class UpdateCouponDto
    {
        public int CouponID { get; set; }
        public string CouponCode { get; set; }
        public int Amount { get; set; }
        public bool Status { get; set; }
    }
}
