using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FamilyTree.Shared.Dto;

namespace FamilyTree.Shared.Entity

{
    [Table( "Person" )]
    public class PersonEntity
    {
        [Key]
        public int Id { get; set; } // Primary Key
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        
        public PersonEntity(PersonDto personDto)
        {
            Id = personDto.Id;
            FirstName = personDto.FirstName;
            LastName = personDto.LastName;
            BirthDate = personDto.BirthDate;
            DeathDate = personDto.DeathDate;
        }
    }
}