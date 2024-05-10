using Microsoft.AspNetCore.SignalR;
using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DtoLayer.OrderDto;
using System;

namespace RestaurantOrderingSystemApp.Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        private readonly IMessageService _messageService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService, IMessageService messageService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
            _messageService = messageService;
        }

        public static int clientCount { get; set; } = 0;

        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByDrink();
            await Clients.All.SendAsync("ReceiveProductCountByDrink", value5);

            var value6 = _productService.TProductCountByDessert();
            await Clients.All.SendAsync("ReceiveProductCountByDessert", value6);

            var value7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00") + "₺");

            var value8 = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8);

            var value9 = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);

            var value10 = _productService.TProductAvgPriceByDessert();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByDessert", value10.ToString("0.00") + "₺");

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

            var value13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.ToString("0.00") + "₺");

            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00") + "₺");

            var value15 = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", value15.ToString("0.00") + "₺");

            var value16 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value16);
        }

        public async Task SendProgress()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", Math.Round(value, 2));

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);

            var value3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value3);

            var value4 = _menuTableService.TTotalMenuTableCount();
            await Clients.All.SendAsync("ReceiveTotalMenuTableCount", value4);

            var value5 = _productService.TProductPriceAvg(); 
            await Clients.All.SendAsync("ReceiveProductPriceAvg", Math.Round(value5,2));

            var value6 = _productService.TProductAvgPriceByDessert();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByDessert", Math.Round(value6, 2));

            var value7 = _productService.TProductCountByDrink();
            await Clients.All.SendAsync("ReceiveProductCountByDrink", value7);

            var value8 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value8);

            var value9 = _productService.TProductPriceByAdanaKebap();
            await Clients.All.SendAsync("ReceiveProductPriceByAdanaKebap", Math.Round(value9, 2));
        
            var value10 = _productService.TTotalPriceByDrinkCategory();
            await Clients.All.SendAsync("ReceiveTotalPriceByDrinkCategory", Math.Round(value10, 2));

            var value11 = _productService.TTotalPriceBySaladCategory();
            await Clients.All.SendAsync("ReceiveTotalPriceBySaladCategory", Math.Round(value11, 2));

            var value12 = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value12);

            var value13 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value13);

            var value14 = _bookingService.TTotalBookingCount();
            await Clients.All.SendAsync("ReceiveBookingCount", value14);

            var value15 = _productService.TTotalProductsPrice();
            await Clients.All.SendAsync("ReceiveTotalProductsPrice", value15);
            
            var value16 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", Math.Round(value16, 2));

        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task GetBookingListByStatusToIncoming()
        {
            var values = _bookingService.TFindList(x => x.Description == "Rezervasyon Alındı");
            await Clients.All.SendAsync("ReceiveBookingListByStatusToIncoming", values);
        }


        public async Task SendNotification()
        {
            var value = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);


            var notificationListByFalse = _notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse",notificationListByFalse);  
        }

        public async Task SendMessageUI()
        {
            var value = _messageService.TMessageCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveMessageCountByFalse", value);


            var messageListByFalse = _messageService.TGetAllMessageByFalse();
            await Clients.All.SendAsync("ReceiveMessageListByFalse", messageListByFalse);
        }

        public async Task GetMenuTableStatus()
        {
            var values = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", values);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task GetOrderList()
        {
            var values = _orderService.TGetOrdersWithMenuTableNames();
            List<ResultOrderWithMenuTableNameDto> orderValues = new List<ResultOrderWithMenuTableNameDto>();
            foreach (var value in values)
            {
                orderValues.Add(new ResultOrderWithMenuTableNameDto()
                {
                    MenuTableID = value.MenuTableID,
                    OrderID = value.OrderID,
                    FinalPrice = value.FinalPrice,
                    MenuTableName = value.MenuTable.Name,
                    OrderDate = value.OrderDate,
                    Status = value.Status,
                    TotalDiscount = value.TotalDiscount,
                    TotalPrice = value.TotalPrice,
                });
            }
            await Clients.All.SendAsync("ReceiveOrderList", orderValues);
        }
    }
}
