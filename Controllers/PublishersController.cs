using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using My_books.Data.Models;
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
        private readonly ILogger<PublishersController> _logger;

        public PublishersController(PublisherService publisherrService, ILogger<PublishersController> logger)
        {
            _publisherrService = publisherrService;
            _logger = logger;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                _logger.LogInformation("This is just al og in GetAllPublishers");
                var _result = _publisherrService.GetAllPublishers(sortBy, searchString, pageNumber);
                return Ok(_result);
            }
            catch (Exception)
            {
                return BadRequest("Sorry, we could not load the publishers");
            }
        }

        [HttpPost("add-publisher")]
        public IActionResult AddBook([FromBody]PublisherVM publisher)
        {
            var newPublisher = _publisherrService.AddPublisher(publisher);
            return Created(nameof(AddBook), newPublisher);
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publisherrService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public ActionResult<Publisher> GetPublisherById(int id)
        {
            var _response = _publisherrService.GetPublisherById(id);
            if (_response == null)
            {
                return NotFound();
            }

            return _response;
        }

        [HttpDelete("delete-publisher/{id}")]
        public IActionResult DeletePublisher(int id)
        {
            _publisherrService.DeletePublisher(id);
            return Ok();
        }

    }
}
