namespace PersonApi.Web.Service
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Repositories;

    public class PersonService
    {
        private readonly IPersonRepository personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task AddPerson(Person person)
        {
            await personRepository.InsertPerson(person);
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await personRepository.GetAllPeople();
        }

        public async Task<Person> GetPersonById(Guid id)
        {
            return await personRepository.SelectPersonById(id);
        }

        public async Task DeletePerson(Guid id)
        {
            await personRepository.DeletePersonById(id);
        }

        public async Task UpdatePerson(Guid id, Person newPerson)
        {
            await personRepository.UpdatePersonById(id, newPerson);
        }
    }
}