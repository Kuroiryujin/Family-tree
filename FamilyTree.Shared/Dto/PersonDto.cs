using FamilyTree.Shared.Entity;

namespace FamilyTree.Shared.Dto;

public class PersonDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public int? MotherId { get; set; }
    public int? FatherId { get; set; }

    public PersonDto()
    {
    }

    public PersonDto(PersonEntity personEntity)
    {
        Id = personEntity.Id;
        MotherId = personEntity.MotherId;
        FatherId = personEntity.FatherId;        
        FirstName = personEntity.FirstName;
        LastName = personEntity.LastName;
        BirthDate = personEntity.BirthDate;
        DeathDate = personEntity.DeathDate;
    }
}