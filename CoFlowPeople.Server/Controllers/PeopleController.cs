using CoFlowPeople.Server.Models.Dtos;
using CoFlowPeople.Server.Models.Service;
using CoFlowPeople.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoFlowPeople.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleService _peopleService;

        public PeopleController(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        /// <summary>
        ///     Gets a List Of all People
        /// </summary>
        /// <returns> A list of person models</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PersonModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<PersonModel>>> GetPeople()
        {
            var people = await _peopleService.GetPeople();
            return Ok(people);
        }

        /// <summary>
        ///     Gets a person by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> the person model</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonModel>> GetPerson(int id)
        {
            var person = await _peopleService.GetById(id);
            return Ok(person);
        }

        /// <summary>
        ///     Updates a person
        /// </summary>
        /// <param name="id">person id </param>
        /// <param name="person">person model</param>
        /// <returns> the updated person model</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<PersonModel>> UpdatePerson(int id, PersonDto person)
        {
            return Accepted(await _peopleService.UpdatePerson(id, person));
        }

        /// <summary>
        ///  Creates a new person
        /// </summary>
        /// <param name="person">person model</param>
        /// <returns>the new person model</returns>
        [HttpPost]
        public async Task<ActionResult<PersonModel>> CreatePerson(PersonDto person)
        {

            return Accepted(await _peopleService.CreatePerson(person));
        }

        /// <summary>
        ///     Deletes a person
        /// </summary>
        /// <param name="id">person id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            await _peopleService.DeletePerson(id);

            return NoContent();
        }

    }
}
