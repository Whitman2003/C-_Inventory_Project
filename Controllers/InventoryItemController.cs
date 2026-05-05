using Microsoft.AspNetCore.Mvc;
using InventoryService.Domain;
using InventoryService.Services;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryItemController : ControllerBase
    {
        private readonly InventoryItemService _service;

        public InventoryItemController(InventoryItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllItems());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var items = _service.GetItemById(id);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }
    }
}
