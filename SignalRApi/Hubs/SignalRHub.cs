﻿using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;


namespace SignalRApi.Hubs
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
		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService , INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
			_notificationService= notificationService;
		}
		public int clientCount { get; set; } = 0;
        public async Task SendStatistic()
		{
			var value = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategory", value);

			var value2 = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value2);

			var value3 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiviteCategoryCount", value3);


			var value4 = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

			var value5 = _productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5);

			var value6 = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value6);

			var value7 = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00") + "$");

			var value8 = _productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8);


			var value9 = _productService.TProductNameByMinPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);

			var value10 = _productService.TProductPriceByHmaburger();
			await Clients.All.SendAsync("ReceiveProductPriceByHmaburger", value10.ToString("0.00") + "$");

			var value11 = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

			var value12 = _orderService.TActiviteOrderCount();
			await Clients.All.SendAsync("ReceiveActiviteOrderCount", value12);


			var value13 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", value13);

			var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00") + "$");

			var value15 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value15);


		}



		public async Task SendProgress()
		{

			var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00") + "$");

			var value = _orderService.TActiviteOrderCount();
			await Clients.All.SendAsync("ReceiveActiviteOrderCount", value);


			var value2 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value2);



		}
		public async Task GetBookingList()
		{
			var value = _bookingService.TGetAll();
			await Clients.All.SendAsync("ReceiveBookingList", value);
		}

		public async Task SendNotification()
		{
			var value = _notificationService.TNotificationCountBySatatusFalse();
			await Clients.All.SendAsync("ReceiveTNotificationCountBySatatusFalse", value);

			var notificationListByFalse=_notificationService.TGetAllNotificationsByFalse();
			await Clients.All.SendAsync("ReceiveNotificationsByFalse",notificationListByFalse);
		}

		public async Task GetMenuTable()
		{
			var value= _menuTableService.TGetAll();
			await Clients.All.SendAsync("ReceiveMenuTable", value);
		}

		public async Task SendMessage(string user,string message)
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
    }
}
