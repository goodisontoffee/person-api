namespace PersonApi.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Service;

    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService personService;

        public PersonController(PersonService personService)
        {
            this.personService = personService;
        }

        [HttpPost]
        public async Task AddPerson([FromBody]Person person)
        {
            if (ModelState.IsValid)
            {
                await this.personService.AddPerson(person);
            }
        }
        
        [HttpGet]
        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await personService.GetAllPeople();
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<Person> GetPersonById(Guid id)
        {
            return await personService.GetPersonById(id);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task DeletePersonById(Guid id)
        {
            await personService.DeletePerson(id);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task UpdatePerson(Guid id, [FromBody] Person newPerson)
        {
            await personService.UpdatePerson(id, newPerson);
        }
    }
}