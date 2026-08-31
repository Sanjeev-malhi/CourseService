using CourseService.Application.Common.Interfaces;
using CourseService.Domain.Entites;
using CourseService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseService.Infrastructure.Repositiories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Course course, CancellationToken cancellationToken)
        {
             await _context.Courses.AddAsync(course, cancellationToken);
        }

        public void DeleteAsync(Course course)
        {
             _context.Courses.Remove(course);
        }

        public async Task<List<Course>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Courses.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Course> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Courses.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
        }
    }
}
