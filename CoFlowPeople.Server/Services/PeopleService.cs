using AutoMapper;
using CoFlowPeople.Server.Models.Dtos;
using CoFlowPeople.Server.Models.Service;
using CoFlowPeople.Server.Repos;
using Opw.HttpExceptions;
using System.Net;

namespace CoFlowPeople.Server.Services
{
	public class PeopleService
	{
        private readonly IMapper _mapper;

        private PeopleRepo _peopleRepo { get; }

		public PeopleService(PeopleRepo peopleRepo, IMapper mapper)
		{
			_peopleRepo = peopleRepo;
            _mapper = mapper;
        }


		public async Task<IEnumerable<PersonModel>> GetPeople()
		{
			return await _peopleRepo.GetPeople();
		}

		public async Task<PersonModel> GetById(int id)
		{
			var person = await _peopleRepo.GetById(id);
			return person ?? throw new HttpException(HttpStatusCode.NotFound);
		}

		public async Task<PersonModel> UpdatePerson(int id, PersonDto person)
		{
			var res = await _peopleRepo.UpdatePerson(id, _mapper.Map<PersonModel>(person));
			return res;
		}

		public async Task<PersonModel> CreatePerson(PersonDto person)
		{
			var res = await _peopleRepo.CreatePerson(_mapper.Map<PersonModel>(person));
			return res;
		}

		public async Task DeletePerson(int id)
		{
			await _peopleRepo.DeletePerson(id);
		}


	}
}
