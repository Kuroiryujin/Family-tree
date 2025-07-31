using FamilyTree.Shared.Entity;

namespace FamilyTree.Shared.Dto;

public class PersonDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }

    public PersonDto(PersonEntity personEntity)
    {
        Id = personEntity.Id;
        FirstName = personEntity.FirstName;
        LastName = personEntity.LastName;
        BirthDate = personEntity.BirthDate;
        DeathDate = personEntity.DeathDate;
    }
}