using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp.Moduler.Enheter;

internal class AnvändareEntity
{
    public int Id { get; set; }
    public string Förnamn { get; set; } = null!;
    public string Efternamn { get; set; } = null!;
    public string Email { get; set; } = null!;

    public ICollection<ÄrendeEntity> Cases { get; set; } = new List<ÄrendeEntity>();
}
