using ConsoleApp.Innehåll;
using ConsoleApp.Moduler.Enheter;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ConsoleApp.Services;

    internal class StatusService
    {
        private readonly DataKontext _context = new();

        public async Task CreateStatusTypeAsync()
        {
             if (!await _context.Statuses.AnyAsync())
            {

            string[] _statuses = new string[] { "Ej Aktiva Ärenden", "Aktiva Ärenden", "Avklarade Ärenden" };

            foreach (var status in _statuses)
            {
                await _context.AddAsync(new StatusEntity { StatusNamn = status });
                await _context.SaveChangesAsync();
            }

          }
        }
}



