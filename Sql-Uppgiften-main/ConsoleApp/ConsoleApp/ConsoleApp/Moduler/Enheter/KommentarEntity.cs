using System;

namespace ConsoleApp.Moduler.Enheter
{
    internal class KommentarEntity
    {
        public int Id { get; set; }
        public string Kommentar { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.Now;
        public string Auktor { get; set; } = null!; 

        public int CaseId { get; set; }
        public ÄrendeEntity Case { get; set; } = null!;
        
    }
}
