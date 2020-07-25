namespace PersonApi.Web.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;

    public class FakePersonRepository : IPersonRepository
    {
        private readonly IDictionary<Guid, Person> people = new Dictionary<Guid, Person>();

        public Task<int> InsertPerson(Guid id, Person person)
        {
            people.Add(id, new Person(id, person.Name));
            return Task.FromResult(1);
        }

        public Task<int> InsertPerson(Person person)
        {
            var id = Guid.NewGuid();
            return InsertPerson(id, person);
        }

        public Task<IEnumerable<Person>> GetAllPeople()
        {
            return Task.FromResult(people.Values.AsEnumerable());
        }

        public Task<Person> SelectPersonById(Guid id)
        {
            return Task.FromResult(people.FirstOrDefault(kvp => kvp.Key == id).Value);
        }

        public Task<int> DeletePersonById(Guid id)
        {
            if (people.ContainsKey(id))
            {
                people.Remove(id);
                return Task.FromResult(1);
            }

            return Task.FromResult(0);
        }

        public Task<int> UpdatePersonById(Guid id, Person newPerson)
        {
            if (people.ContainsKey(id))
            {
                people[id] = new Person(id, newPerson.Name);
                return Task.FromResult(1);
            }

            return Task.FromResult(0);
        }
    }
}