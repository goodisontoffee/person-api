namespace PersonApi.Web.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IPersonRepository
    {
        Task<int> InsertPerson(Guid id, Person person);
        
        Task<int> InsertPerson(Person person);

        Task<IEnumerable<Person>> GetAllPeople();

        Task<Person> SelectPersonById(Guid id);

        Task<int> DeletePersonById(Guid id);

        Task<int> UpdatePersonById(Guid id, Person newPerson);
    }
}