using ConsoleApp.Innehåll;
using ConsoleApp.Moduler.Enheter;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ConsoleApp.Services;

internal class ÄrendeService
{
    private readonly DataKontext _context = new();

    public async Task CreateAsync(ÄrendeEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ÄrendeEntity>> GetAllActiveAsync()
    {
        return await _context.Cases
            .Include(x => x.Kommentarer)
            .Include(x => x.User)
            .Include(x => x.Status)
            .Where(x => x.StatusId != 3)
            .OrderByDescending(x => x.Created)
            .ToListAsync();
    }

    public async Task<IEnumerable<ÄrendeEntity>> GetAllAsync()
    {
        return await _context.Cases
            .Include(x => x.Kommentarer)
            .Include(x => x.User)
            .Include(x => x.Status)
            .OrderByDescending(x => x.Created)
            .ToListAsync();
    }

    public async Task<ÄrendeEntity> GetAsync(Expression<Func<ÄrendeEntity, bool>> predicate)
    {
        var _entity = await _context.Cases
            .Include(x => x.Kommentarer)
            .Include(x => x.User)
            .Include(x => x.Status)
            .FirstOrDefaultAsync(predicate);

        return _entity!;
    }

    public async Task UpdateCaseStatusAsync(int caseId, int statusId)
    {
        var _entity = await _context.Cases.FindAsync(caseId);
        if (_entity != null)
        {
            _entity.Modified = DateTime.Now;
            _entity.StatusId = statusId;
            _context.Update(_entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task CreateCommentAsync(KommentarEntity comment)
    {
        await _context.AddAsync(comment);
        await _context.SaveChangesAsync();
        await UpdateCaseStatusAsync(comment.CaseId, 2);
    }
}