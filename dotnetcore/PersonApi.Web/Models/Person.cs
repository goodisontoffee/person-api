namespace PersonApi.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        public Person()
        {
        }
        
        public Person(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}