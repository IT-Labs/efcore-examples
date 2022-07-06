using Contracts;
using Contracts.Managers;
using Contracts.Requests;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Booster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookManager _bookManager;

        public BooksController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        [HttpGet("{id}")]
        public Response<Book> Get([FromRoute] int id)
        {
            return _bookManager.Get(id);
        }

        [HttpGet]
        public PagedResponse<Book> Get([FromQuery] PageRequest reqest)
        {
            return _bookManager.Get(reqest);
        }

        [HttpPost]
        public Response<int> Post([FromBody] SaveBookRequest request)
        {
            return _bookManager.Save(request);
        }

        [HttpPut("{id}")]
        public Response<int> Put([FromRoute] int id, [FromBody] SaveBookRequest request)
        {
            request.SetId(id);
            return _bookManager.Save(request);
        }
    }
}
