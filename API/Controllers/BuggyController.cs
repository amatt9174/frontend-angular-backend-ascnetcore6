using System;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly AppDBContext _context;
        public BuggyController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet("notfounduuid")]
        public ActionResult GetNotFoundRequestGuid()
        {
            var thing = _context.Attachments.Find(new Guid());

            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("notFoundint")]
        public ActionResult GetNotFoundRequestInt()
        {
            var thing = _context.Products.Find(42);

            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("servererroruuid")]
        public ActionResult GetServerErrorGuid()
        {
            var thing = _context.Attachments.Find(new Guid());
            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("servererrorint")]
        public ActionResult GetServerErrorInt()
        {
            var thing = _context.Products.Find(42);

            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequestuuid/{id}")]
        public ActionResult GetNotFoundRequest(Guid id)
        {
            return Ok();
        }
        [HttpGet("badrequestint/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}