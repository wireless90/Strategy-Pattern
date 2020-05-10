using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Application.PersonContext.Queries.SearchPerson;
using CA.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CA.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;    
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            return  await _mediator.Send(new SearchPersonQuery() { Name = "RAZALI", Identification = "12345", IdentificationType = "T" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
