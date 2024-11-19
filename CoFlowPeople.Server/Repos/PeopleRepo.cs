using AutoMapper;
using CoFlowPeople.Server.Data.Base;
using CoFlowPeople.Server.Data.Context;
using CoFlowPeople.Server.Models.Data;
using CoFlowPeople.Server.Models.Service;
using Microsoft.EntityFrameworkCore;
using Opw.HttpExceptions;
using System.Net;

namespace CoFlowPeople.Server.Repos
{
    public class PeopleRepo : DbRepsitoryBase<AppDbContext>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PeopleRepo(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonModel>> GetPeople()
        {
            var people = await _context.Person.ToListAsync();

            return _mapper.Map<IEnumerable<PersonModel>>(people);

        }

        public async Task<PersonModel> GetById(int id)
        {
           var person =  await _context.Person.FindAsync(id);
           return _mapper.Map<PersonModel>(person);
        }

        public async Task<PersonModel> UpdatePerson(int id, PersonModel person)
        {
            var ent = await _context.Person.FindAsync(id) ?? throw new HttpException(HttpStatusCode.NotFound);
            var target = _mapper.Map<Person>(person);
            target.DateCreated = ent.DateCreated;
            target.Id = ent.Id;

            await UpdateRecord(ent, target);
            return _mapper.Map<PersonModel>(target);

        }

        public async Task<PersonModel> CreatePerson(PersonModel person)
        {
            var ent = _mapper.Map<Person>(person);
            ent.DateCreated = DateTime.Now;
			_context.Person.Add(ent);
			await _context.SaveChangesAsync();
            return _mapper.Map<PersonModel>(ent);
		}


        public async Task DeletePerson(int id)
        {
			var person = await _context.Person.FindAsync(id) ?? throw new HttpException(HttpStatusCode.NotFound);
            _context.Person.Remove(person);
			await _context.SaveChangesAsync();
		}

    }
}
