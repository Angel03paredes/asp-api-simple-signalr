using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;

namespace SignalR.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BeerController : ControllerBase
	{
		private IHubContext<MessageHub> _hubContext;


		public BeerController(IHubContext<MessageHub> hubContext)
		{
			_hubContext = hubContext;
		}

	    [HttpGet]
		public async Task<IActionResult> Send(string Message)
		{
			await _hubContext.Clients.All.SendAsync("SendMessage",Message);
			return Ok();
		}
		[HttpPost]
		public async Task<IActionResult> Guardar(string Nombre)
		{
			await _hubContext.Clients.All.SendAsync("SendMessage", Nombre);
			return Ok();

		}
	}
}
