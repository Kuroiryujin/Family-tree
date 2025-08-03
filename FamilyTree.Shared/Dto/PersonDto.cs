using FamilyTree.Shared.Entity;

namespace FamilyTree.Shared.Dto;

public class PersonDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public int? ParentId { get; set; }

    public PersonDto? Parent { get; set; } 
    
    public ICollection<PersonDto> Children { get; set; } = new List<PersonDto>();
    
    public PersonDto()
    {
    }

    public PersonDto(PersonEntity personEntity)
    {
        Id = personEntity.Id;
        ParentId = personEntity.ParentId;
        FirstName = personEntity.FirstName;
        LastName = personEntity.LastName;
        BirthDate = personEntity.BirthDate;
        DeathDate = personEntity.DeathDate;
        Parent = personEntity.Parent != null ? new PersonDto(personEntity.Parent) : null;
        Children = personEntity.Children
            .Select(child => new PersonDto(child))
            .ToList();
    }
}