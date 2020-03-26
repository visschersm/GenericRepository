using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ViewModels.Todo.Detailed), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _todoService.GetById<ViewModels.Todo.Detailed>(id);

            if (result == null)
                return NotFound($"TodoItem with {nameof(id)}: {id} not found");

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ViewModels.Todo.List), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _todoService.Get<ViewModels.Todo.List>();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ViewModels.Todo.Create toCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _todoService.Create<ViewModels.Todo.Detailed>(toCreate);

            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }
    }
}