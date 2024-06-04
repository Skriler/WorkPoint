using Microsoft.EntityFrameworkCore;
using WorkPoint.Models.Entities;

namespace WorkPoint.SL.DAL;

public class SpecialityRepository
{
    private readonly WorkPointDbContext db;

    public SpecialityRepository(WorkPointDbContext context)
    {
        db = context;
    }

    public async Task<List<Speciality>> GetSpecialityListAsync()
    {
        return await db.Specialities
            .Include(s => s.RequiredSoftSkills)
            .Include(s => s.RequiredHardSkills)
            .ThenInclude(hs => hs.ProgrammingSkills)
            .Include(s => s.RequiredHardSkills)
            .ThenInclude(hs => hs.DBSkills)
            .Include(s => s.RequiredHardSkills)
            .ThenInclude(hs => hs.MSOfficeSkills)
            .Include(s => s.RequiredHardSkills)
            .ThenInclude(hs => hs.OSSkills)
            .Include(s => s.RequiredHardSkills)
            .ThenInclude(hs => hs.GESkills)
            .Include(s => s.RequiredHardSkills)
            .ThenInclude(hs => hs.ExtraSkills)
            .AsNoTracking()
            .ToListAsync();
    }
}
