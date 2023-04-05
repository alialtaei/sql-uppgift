using System;
using System.Collections.Generic;

namespace ConsoleApp.Moduler.Enheter;

internal class ÄrendeEntity
{
    public int Id { get; set; }
    public string KundNamn { get; set; } = null!;
    public string KundEmail { get; set; } = null!;
    public string? KundTelefonNummer { get; set; }
    public string? KundCompany { get; set; }
    public string Beskrivning { get; set; } = null!;

    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Modified { get; set; } = DateTime.Now;

    public int StatusId { get; set; } = 1;
    public StatusEntity Status { get; set; } = null!;
    
    public int UserId { get; set; }
    public AnvändareEntity User { get; set; } = null!;
    public ICollection<KommentarEntity> Kommentarer { get; set; } = new List<KommentarEntity>();
}
