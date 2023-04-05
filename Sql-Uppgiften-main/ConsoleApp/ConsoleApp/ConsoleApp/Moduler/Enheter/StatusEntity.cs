using System.Collections.Generic;

namespace ConsoleApp.Moduler.Enheter;

internal class StatusEntity
{
    public int Id { get; set; }
    public string StatusNamn { get; set; } = null!;
    public ICollection<ÄrendeEntity> Cases { get; set; } = new List<ÄrendeEntity>();
}
