using GavrilovDmitryKT_41_20.Database;
using GavrilovDmitryKT_41_20.Models;
using Microsoft.EntityFrameworkCore;

namespace GavrilovDmitryKT_41_20.Interfaces.SubjectInterfaces
{
    public interface ISubjectService
    {
        public Task<Subject[]> GetSubjectAsync(CancellationToken cancellationToken);
        public Task<Subject> GetSubjectAsync(int id, CancellationToken cancellationToken);
        public Task AddSubjectAsync(Subject subject, CancellationToken cancellationToken);
        public Task UpdateSubjectAsync(Subject subject, CancellationToken cancellationToken);
        public Task DeleteSubjectAsync(Subject subject, CancellationToken cancellationToken);
    }
    public class SubjectService : ISubjectService
    {
        public readonly SubjectDbContext _dbContext;
        public SubjectService(SubjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Subject[]> GetSubjectAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Subjects.ToArrayAsync();
        }

        public async Task<Subject> GetSubjectAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Subjects.FindAsync(id);
        }

        public async Task AddSubjectAsync(Subject subject, CancellationToken cancellationToken = default)
        {
            
            _dbContext.Subjects.Add(subject);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateSubjectAsync(Subject subject, CancellationToken cancellationToken = default)
        {
            
            _dbContext.Subjects.Update(subject);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSubjectAsync(Subject subject, CancellationToken cancellationToken = default)
        {
            _dbContext.Subjects.Remove(subject);
            await _dbContext.SaveChangesAsync();
        }
    }
}
