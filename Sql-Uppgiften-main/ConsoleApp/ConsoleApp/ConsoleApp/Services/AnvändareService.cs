using ConsoleApp.Innehåll;
using ConsoleApp.Moduler.Enheter;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace ConsoleApp.Services;

internal class AnvändareService
{
    private readonly DataKontext _context = new();

    public async Task<AnvändareEntity> CreateAsync(AnvändareEntity entity)
    {
        var _entity = await _context.Users.FirstOrDefaultAsync(x => x.Email == entity.Email);
        if (_entity == null)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        return _entity;
    }

    public async Task<AnvändareEntity> GetAsync(Expression<Func<AnvändareEntity, bool>> predicate)
    {
        var _entity = await _context.Users.FirstOrDefaultAsync(predicate);
        return _entity!;
    }

    public async Task<IEnumerable<AnvändareEntity>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }
}