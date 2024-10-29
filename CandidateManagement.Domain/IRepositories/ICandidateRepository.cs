
using CandidateManagement.Domain.Entities;

namespace CandidateManagement.Domain.IRepositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetCandidateByEmailAsync(string email);
        Task AddCandidateAsync(Candidate candidate);
        Task UpdateCandidateAsync(Candidate candidate);
    }
}
