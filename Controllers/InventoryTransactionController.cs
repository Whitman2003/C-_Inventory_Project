using Microsoft.AspNetCore.Mvc;
using InventoryService.Models;
using InventoryService.Services;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryTransactionController : ControllerBase
    {
        private readonly InventoryItemService _service;

        public InventoryTransactionController(InventoryItemService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(CreateInventoryTransactionRequest request)
        {
            _service.AddTransaction(request);
            return Ok();
        }
    }
}
