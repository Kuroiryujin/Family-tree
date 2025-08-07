using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FamilyTree.Shared.Dto;

namespace FamilyTree.Shared.Entity
{
    [Table("People")]
    public class PersonEntity
    {
        [Key] public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public Gender Gender { get; set; }

        public ICollection<PersonEntity> Parents { get; set; } = new List<PersonEntity>();
        public ICollection<PersonEntity> Children { get; set; } = new List<PersonEntity>();


        public PersonEntity()
        {
        }

        public PersonEntity(PersonDto personDto)
        {
            Id = personDto.Id;
            FirstName = personDto.FirstName;
            LastName = personDto.LastName;
            BirthDate = personDto.BirthDate;
            DeathDate = personDto.DeathDate;
            Gender = personDto.Gender;
        }
    }
}