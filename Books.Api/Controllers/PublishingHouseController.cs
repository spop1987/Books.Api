using BooksService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishingHouseController : ControllerBase
    {
        private readonly IServices _service;

        public PublishingHouseController(IServices service)
        {
            _service = service;
        }

        [HttpGet("publishingHouse/{publishingHouseId}")]
        public async Task<IActionResult> GetPublishingHouse(int publishingHouseId)
        {
            return Ok(await _service.GetPublishingById(publishingHouseId));
        }
    }
}
