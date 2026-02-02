using System;
using System.Collections.Generic;
using System.Text;
using VideoGameDB_relationship.Entities;
public class DeveloperEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;

    public ICollection<GameEntity> Games { get; set; } = new List<GameEntity>();
}
