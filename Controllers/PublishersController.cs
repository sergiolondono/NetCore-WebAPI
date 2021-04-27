using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_books.Data.Services;
using My_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublisherService _publisherrService;

        public PublishersController(PublisherService publisherrService)
        {
            _publisherrService = publisherrService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddBook([FromBody]PublisherVM publisher)
        {
            _publisherrService.AddPublisher(publisher);
            return Ok();
        }
    }
}
