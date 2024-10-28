using CandidateManagement.Domain.Entities;
using CandidateManagement.Domain.IRepositories;
using CandidateManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagement.Infrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Candidate?> GetCandidateByEmailAsync(string email)
        {
            string email2 = email;
            return await _context.Candidates.FirstOrDefaultAsync((Candidate c) => c.Email == email2);
        }

        public async Task AddCandidateAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCandidateAsync(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();
        }
    }
}