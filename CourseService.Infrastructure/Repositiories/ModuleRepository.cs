using CourseService.Application.Common.Interfaces;
using CourseService.Domain.Entites;
using CourseService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseService.Infrastructure.Repositiories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDbContext _context;
        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;   
        }
        public async Task AddAsync(Modules module, CancellationToken cancellationToken)
        {
            await _context.Modules.AddAsync(module, cancellationToken);
        }

        public void DeleteAsync(Modules module)
        {
            _context.Modules.Remove(module);
        }

        public async Task<List<Modules>> GetByCourseIdAsync(Guid courseId, CancellationToken cancellationToken)
        {
            return await _context.Modules.AsNoTracking().
                Where(x => x.CourseId == courseId)
                .OrderBy(x => x.OrderIndex)
                .ToListAsync(cancellationToken);
        }

        public async Task<Modules> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Modules.AsNoTracking().
                FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void UpdateAsync(Modules module)
        {
            _context.Modules.Update(module);
        }
    }
}
