namespace PersonApi.Web.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dapper;
    using Microsoft.Extensions.Options;
    using Models;
    using Npgsql;

    public class PostgreSqlRepository : IPersonRepository
    {
        private readonly IOptions<PostgreSqlOptions> postgreSqlOptions;

        public PostgreSqlRepository(IOptions<PostgreSqlOptions> postgreSqlOptions)
        {
            this.postgreSqlOptions = postgreSqlOptions;
        }
        
        public async Task<int> InsertPerson(Guid id, Person person)
        {
            const string sql = "INSERT INTO person (id, name) VALUES (@id, @name)";
            
            using (var connection = new NpgsqlConnection(postgreSqlOptions.Value.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                parameters.Add("@name", person.Name);
                var command = new CommandDefinition(sql, parameters);

                await connection.ExecuteAsync(command);
                return 1;
            }
        }

        public Task<int> InsertPerson(Person person)
        {
            return InsertPerson(Guid.NewGuid(), person);
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            const string sql = "SELECT id, name FROM person";

            using (var connection = new NpgsqlConnection(postgreSqlOptions.Value.ConnectionString))
            {
                var command = new NpgsqlCommand();
                return await connection.QueryAsync<Person>(sql);
            }
        }

        public async Task<Person> SelectPersonById(Guid id)
        {
            const string sql = "SELECT id, name FROM person WHERE id = @id";

            using (var connection = new NpgsqlConnection(postgreSqlOptions.Value.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                var command = new CommandDefinition(sql, parameters);

                return await connection.QueryFirstAsync<Person>(command);
            }
        }

        public async Task<int> DeletePersonById(Guid id)
        {
            const string sql = "DELETE FROM person WHERE id = @id";

            using (var connection = new NpgsqlConnection(postgreSqlOptions.Value.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                var command = new CommandDefinition(sql, parameters);

                await connection.ExecuteAsync(command);
                return 1;
            }
        }

        public async Task<int> UpdatePersonById(Guid id, Person newPerson)
        {
            const string sql = "UPDATE person SET name = @name WHERE id = @id";
            
            using (var connection = new NpgsqlConnection(postgreSqlOptions.Value.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                parameters.Add("@name", newPerson.Name);
                var command = new CommandDefinition(sql, parameters);

                await connection.ExecuteAsync(command);
                return 1;
            }
        }
    }
}