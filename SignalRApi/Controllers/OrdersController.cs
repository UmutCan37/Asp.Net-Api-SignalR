using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;

			
		}
		[HttpGet("TotalOrderCount")]
		public IActionResult TotalOrderCount()
		{
			return Ok(_orderService.TTotalOrderCount());
		}
		[HttpGet("ActiviteOrderCount")]
		public IActionResult ActiviteOrderCount()
		{
			return Ok(_orderService.TActiviteOrderCount());
		}
		[HttpGet("LastOrderPrice()")]
		public IActionResult LastOrderPrice()
		{
			return Ok(_orderService.TLastOrderPrice());
		}
		[HttpGet("LastOrderPrice")]
		public IActionResult TodayTotalPrice()
		{
			return Ok(_orderService.TTodayTotalPrice());
		}

	}
}
